using UnityEngine;

public class Spawner : MonoBehaviour
{   
    [SerializeField] float spawnRate = 2f;
    [SerializeField] GameObject[] Enemies;

    float xMin;
    float xMax;
    float ySpawn;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        

        InvokeRepeating("SpawnEnemy", 3f, spawnRate); //(methodname, delay in seconds, interval time)
    }

    // Update is called once per frame
    void Update()
    {
        //These are taking the x values from the far left of the camera, far right of the camera, and the y a little above the camera.
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(.1f,0,0)).x; //The numbers in Vector3 might be percentage based
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(.9f,0,0)).x; //Like .9 here the tutorial said means 90%
        ySpawn = Camera.main.ViewportToWorldPoint(new Vector3(0,1.25f,0)).y; //1.25 prob means 125%
    }

    //Spawns an enemy above the screen, at a randX between xMin and xMax with the rotation of the sprite (Thats what quaternion is)
    
    void SpawnEnemy()
    {
        
        float randX = Random.Range(xMin, xMax);
        int randEnemy = Random.Range(0, Enemies.Length);
        Instantiate(Enemies[randEnemy], new Vector3(randX, ySpawn, 0), Quaternion.identity);  
    }
}
