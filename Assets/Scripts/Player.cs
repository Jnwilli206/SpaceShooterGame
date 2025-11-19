using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject laser;
    [SerializeField] float fireRate = 0.3f;
    float nextFireTime = 0f;
    bool fireSizeUp;


    float xMin, xMax, yMin, yMax;

    void Start()
    {
        fireSizeUp = false;
    }

    void Update()
    {
        SetUpMoveBoundaries();
        MovePlayer();  
        Shoot();     
        checkHP();
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // arrow keys
        float moveY = Input.GetAxisRaw("Vertical");   //  arrow keys

        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized * moveSpeed * Time.deltaTime;
        transform.position += movement;

        float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float clampedY = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = new Vector3(clampedX, clampedY, 0);
    }

    void checkHP()
    {
        if (GameManager.instance.hp <= 0){
            Destroy(gameObject);
        }
    }


    void Shoot()
    {
        if (Input.GetButton("PrimaryWeapon") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;

            

            Instantiate(laser, transform.position, Quaternion.identity);
            if (fireSizeUp)
            {
                laser.transform.localScale = new Vector3(2, 2, 2);
            }
        }
    }

    void SetUpMoveBoundaries()
    {
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        float padding = 0.5f; 
        xMin = bottomLeft.x + padding;
        xMax = topRight.x - padding;
        yMin = bottomLeft.y + padding;
        yMax = topRight.y - padding;
    }

    public void UpgradeFireRate()
    {
        fireSizeUp = true;

        fireRate = Mathf.Max(0.1f, fireRate - 0.05f);

        Debug.Log("Fire rate upgraded! New fireRate = " + fireRate);
    }


    void OnDestroy()
    {
        GameManager.instance.GameOver();
    
    }
}
