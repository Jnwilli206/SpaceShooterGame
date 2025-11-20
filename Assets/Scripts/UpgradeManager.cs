using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager instance;

    [SerializeField] GameObject upgradePanel;
    [SerializeField] Button healthButton;
    [SerializeField] Button fireRateButton;

    private bool upgradeChosen = false;

    void Awake()
    {
        instance = this;
        upgradePanel.SetActive(false); 
        healthButton.onClick.AddListener(ChooseHealthUpgrade);
        fireRateButton.onClick.AddListener(ChooseFireRateUpgrade);
    }

    public void ShowUpgradeMenu()
    {
        if (!upgradeChosen)
        {
            upgradePanel.SetActive(true);
            Time.timeScale = 0f; 
        }
    }

    void ChooseHealthUpgrade()
    {
        GameManager.instance.hp += 1;
        GameManager.instance.UpdateHPUI();
        CloseMenu();
    }

    void ChooseFireRateUpgrade()
    {
        Player player = FindFirstObjectByType<Player>();
        if (player != null)
        {
            player.UpgradeFireRate();
        }
        CloseMenu();
    }

    void CloseMenu()
    {
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
        upgradeChosen = true;

    }
}
