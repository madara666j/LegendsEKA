using UnityEngine;
using UnityEngine.SceneManagement; // for level transitions

public class XPManager : MonoBehaviour
{
    public static XPManager Instance;

    [SerializeField] private int xpPerKill = 10;
    [SerializeField] private int requiredKills = 6;

    private int currentXP = 0;
    private int currentKills = 0;

    private UIManager uiManager;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    public void AddKillXP()
    {
        currentXP += xpPerKill;
        currentKills++;

        // Update XP bar
        if (uiManager != null)
            uiManager.UpdateXPBar(currentKills / (float)requiredKills);

        if (currentKills >= requiredKills)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        // Either load next scene or show win screen
        Debug.Log("Level Complete!");
        // Example: SceneManager.LoadScene("NextLevel");
    }
}
