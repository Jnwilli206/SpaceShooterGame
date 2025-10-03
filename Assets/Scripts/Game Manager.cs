using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{   
    int score = 0;

    public static GameManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
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
}
