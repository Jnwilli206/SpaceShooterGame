using UnityEngine;

public class DiagEnemy : MonoBehaviour
{
    [SerializeField] float diagSpeed;    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 0) 
        {
            transform.position -= new Vector3(-2f, 0, 0) * Time.deltaTime;
        }
        if (transform.position.x > 0) 
        {
            transform.position -= new Vector3(2f, 0, 0) * Time.deltaTime;
        }
    }
}
