using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEditor;
public class MainMenuController : MonoBehaviour
{
    public GameObject Panel;
    public GameObject DifficultyToggles;
    public static string gameMode = "Hard";

    public void Start()
    {
        Panel.SetActive(false);
        SetDifficultyMode.Difficulty = SetDifficultyMode.Difficulties.Hard;
        DifficultyToggles.transform.GetChild((int)SetDifficultyMode.Difficulty).GetComponent<Toggle>().isOn = true;
        
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
        //if (Application.isEditor)
        //{
        //    UnityEditor.EditorApplication.isPlaying = false;
        //}
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Escaped!");
            //if (Application.isEditor)
            //{
            //    UnityEditor.EditorApplication.isPlaying = false;
            //}
        }
    }

    #region Difficulty
    public void SetEasyDifficulty(bool isOn)
    {
        if (isOn)
        {
            SetDifficultyMode.Difficulty = SetDifficultyMode.Difficulties.Easy;
            gameMode = "Easy";
        }
            
    }
    public void SetHardDifficulty(bool isOn)
    {
        if (isOn)
        {
            SetDifficultyMode.Difficulty = SetDifficultyMode.Difficulties.Hard;
            gameMode = "Hard";
        }
            
    }
    #endregion
}
