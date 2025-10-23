using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{   
    
    int score = 0;
    

    public static GameManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverText;
    public int hp;
     [SerializeField] TextMeshProUGUI hpDisplay;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }

     public void GameOver()
    {
        gameOverText.enabled = true;
    }
    
    public void minusHP()
    {
        hp -= 1;
        hpDisplay.text = "HP: " + hp.ToString();
    }
}   
    
 