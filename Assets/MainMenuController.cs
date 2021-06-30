using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class MainMenuController : MonoBehaviour
{
    public GameObject Panel;

    public void Start()
    {
        Panel.SetActive(false);
    }
    public void OpenPanel()
    {
        if (Panel != null)
        {
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
        //SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
