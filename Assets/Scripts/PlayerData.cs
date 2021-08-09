using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerData
{
    public string playerName = BrainFramework.Profile;
    public string playerScore = ScoreTextScript.coinAmount.ToString();
    public int smileCount = PlayerMovement.smileCount;
    public string difficultyLevel = MainMenuController.gameMode;


}
