using UnityEngine;

public class MP_UIManager : MonoBehaviour
{
    public static MP_UIManager Instance;

    public GameObject winPanel;
    public GameObject losePanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            AssignPanels();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void AssignPanels()
    {
        if (winPanel == null)
        {
            winPanel = GameObject.Find("WinPanel");
            if (winPanel == null)
            {
                Debug.LogError("WinPanel is not assigned and could not be found.");
            }
            else
            {
                Debug.Log("WinPanel assigned.");
            }
        }

        if (losePanel == null)
        {
            losePanel = GameObject.Find("LosePanel");
            if (losePanel == null)
            {
                Debug.LogError("LosePanel is not assigned and could not be found.");
            }
            else
            {
                Debug.Log("LosePanel assigned.");
            }
        }
    }

    public void ShowWinPanel()
    {
        Debug.Log("ShowWinPanel called.");
        if (winPanel != null)
        {
            winPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("WinPanel is not assigned.");
        }
    }

    public void ShowLosePanel()
    {
        Debug.Log("ShowLosePanel called.");
        if (losePanel != null)
        {
            losePanel.SetActive(true);
        }
        else
        {
            Debug.LogError("LosePanel is not assigned.");
        }
    }
}
