﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        ScoreTextScript.coinAmount = 0;
    }
}
