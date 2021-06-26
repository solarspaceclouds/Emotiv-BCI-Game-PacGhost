using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
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
    public void SelectCharacter1()
    {

    }

    public void SelectCharacter2()
    {

    }
}
