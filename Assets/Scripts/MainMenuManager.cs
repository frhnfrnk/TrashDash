using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Settings Panel")]
    public GameObject settingsPanel;

    [Header("Trash Library Panel")]
    public GameObject trashLibraryPanel;

    [Header("How To Play Panel")]
    public GameObject howToPlayPanel;

    void Start()
    {
        // Ensure the panels is hidden at the start
        if (settingsPanel != null)      { settingsPanel.SetActive(false); }
        if (trashLibraryPanel != null)  { trashLibraryPanel.SetActive(false); }
        if (howToPlayPanel != null)     { howToPlayPanel.SetActive(false); }
    }

    // ===== BUTTONS =====
    public void StartGame()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void QuitGame()
    {
        Application.Quit();
    }



    // ===== PANELS =====

    // [1]. Settings Panel
    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }
    public void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    // [2]. Trash Library Panel
    public void OpenTrashLibrary()
    {
        if (trashLibraryPanel != null)
        {
            trashLibraryPanel.SetActive(true);
        }
    }
    public void CloseTrashLibrary()
    {
        if (trashLibraryPanel != null)
        {
            trashLibraryPanel.SetActive(false);
        }
    }

    // [3]. How To Play Panel
    public void OpenHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(true);
        }
    }
    public void CloseHowToPlay()
    {
        if (howToPlayPanel != null)
        {
            howToPlayPanel.SetActive(false);
        }
    }

}
