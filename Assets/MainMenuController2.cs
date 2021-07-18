using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEditor;
public class MainMenuController2 : MonoBehaviour
{
    public GameObject Panel;

    //public Toggle MultiplayerToggle;
    //public GameObject DifficultyToggles;
    public void Start()
    {
        Panel.SetActive(false);
        //DifficultyToggles.transform.GetChild((int)Difficulties.Difficulty).GetComponent<Toggle>().isOn = true;
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

    // region Difficulty
    //public void SetBasicDifficulty(bool isOn)
    //{
    //    if (isOn)
    //    {
    //        Difficulties.Difficulty = Difficulties.DifficultyLevels.Basic;
    //    }
    //}

    //public void SetExpertDifficulty(bool isOn)
    //{
    //    if(isOn)
    //    {
    //        Difficulties.Difficulty = Difficulties.DifficultyLevels.Expert;
    //    }
    //}
}

