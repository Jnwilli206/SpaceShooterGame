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
        GameManager.instance.IncreaseScore(10);
        Destroy(gameObject); //destroys this enemy object
        Destroy(collision.gameObject); //destroys what hit it ie:laser
    }
}

