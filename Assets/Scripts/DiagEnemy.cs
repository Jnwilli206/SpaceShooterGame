using UnityEngine;

public class DiagEnemy : MonoBehaviour
{
    [SerializeField] float diagSpeed;    
    private bool leftRight;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (transform.position.x < 0) 
        {
            leftRight = true;
        }
        if (transform.position.x > 0) 
        {
            leftRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (leftRight == true) 
        {
            transform.position -= new Vector3(-2f, 0, 0) * Time.deltaTime;
        }
        if (leftRight == false) 
        {
            transform.position -= new Vector3(2f, 0, 0) * Time.deltaTime;
        }
    }
}
