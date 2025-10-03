using UnityEngine;

public class Player : MonoBehaviour
{   
    float yPos;
    [SerializeField] GameObject laser;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        yPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       transform.position = new Vector3(mousePos.x, yPos, 0);
       if(Input.GetButtonDown("PrimaryWeapon")){
            Instantiate(laser, transform.position, Quaternion.identity);
       }
       

    }
}
