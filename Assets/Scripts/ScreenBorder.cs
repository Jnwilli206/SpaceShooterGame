using UnityEngine;

public class ScreenBorder : MonoBehaviour
{   
    private Vector3 screenBounds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(UnityEngine.Screen.width, UnityEngine.Screen.height, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position; //get current position
        float clampX = Mathf.Clamp(transform.position.x, -screenBounds.x, screenBounds.x); //set bounds x
        float clampY = Mathf.Clamp(transform.position.y, -screenBounds.y, screenBounds.y); //set bounds y
        pos.x = clampX; // Bound the position x
        pos.y = clampY; // Bound the position y
        transform.position = pos; //Reset position based on bounds
    }
}
