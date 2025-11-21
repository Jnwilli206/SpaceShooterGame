using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 4f;

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.minusHP();
            Destroy(gameObject);
        }
    }
}
