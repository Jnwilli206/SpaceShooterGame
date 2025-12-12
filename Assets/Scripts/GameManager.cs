using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    int score = 0;


    public static GameManager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("UI References")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverText;
    [SerializeField] TextMeshProUGUI hpDisplay;


    public int hp = 3;

    [Header("Boss Settings")]           
    public GameObject bossPrefab;       
    public bool bossSpawned = false;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        gameOverText.enabled = false;
        UpdateHPUI();
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();

        if (score == 100)
        {
            UpgradeManager.instance.ShowUpgradeMenu();
        }
        if (score >= 100 && !bossSpawned)
        {
            Debug.Log("Boss Triggered! Score = " + score);
            SpawnBoss();
            bossSpawned = true;
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("End Screen");
    }


    public void minusHP()
    {
        hp -= 1;
        UpdateHPUI();
    }
    public void UpdateHPUI()
    {
        hpDisplay.text = "HP: " + hp.ToString();
    }

    void SpawnBoss()
    {
        Vector3 spawnPos = new Vector3(0f, 7f, 0f);          

        Debug.Log("Spawning Boss at: " + spawnPos);          
        Instantiate(bossPrefab, spawnPos, Quaternion.identity);
    }
}


