using UnityEngine;
public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, speed, 0) * Time.deltaTime;
        
    }
    
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {   
        
        if (!collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.IncreaseScore(10);
            // Destroy the other object
            Destroy(collision.gameObject);

            // Destroy itself
            Destroy(gameObject);
        } else if (collision.gameObject.CompareTag("Player")){
            GameManager.instance.minusHP();
        }
        
    }
     
}

