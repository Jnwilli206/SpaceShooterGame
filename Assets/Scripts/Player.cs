using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject laser;

    float xMin, xMax, yMin, yMax;

    void Start()
    {
        
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
        if (Input.GetButtonDown("PrimaryWeapon"))
        {
            Instantiate(laser, transform.position, Quaternion.identity);
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

    void OnDestroy()
    {
        GameManager.instance.GameOver();
    
    }
}
