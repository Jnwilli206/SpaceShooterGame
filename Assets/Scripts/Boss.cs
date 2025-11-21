using UnityEngine;

public class Boss : MonoBehaviour
{
    [Header("Boss Stats")]
    public int maxHP = 50;
    private int currentHP;

    [Header("Movement")]
    public float moveSpeed = 2f;
    float startingX;

    [Header("Attacks")]
    public GameObject bossBulletPrefab;
    public float fireRate = 2f;
    private float fireTimer = 0f;


    private float lockedY;
    void Start()
    {
        currentHP = maxHP;
        startingX = transform.position.x;

        
    }

    void Update()
    {
        MovePattern();
        AttackPattern();
        lockedY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.85f, 0)).y;
    }

    void MovePattern()
    {
        float xOffset = Mathf.Sin(Time.time * moveSpeed) * 2f;
        transform.position = new Vector3(startingX + xOffset, lockedY, 0);
    }

    void AttackPattern()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= fireRate)
        {
            Instantiate(bossBulletPrefab, transform.position + new Vector3(0, -1f, 0), Quaternion.identity);
            fireTimer = 0f;
        }
    }

    public void TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Boss Defeated!");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerLaser"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }
}
