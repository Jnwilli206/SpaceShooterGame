using UnityEngine;

public class Screen : MonoBehaviour
{
    public static float screenSpeed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, screenSpeed, 0) * Time.deltaTime;
    }
}
