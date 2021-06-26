using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;

    //private int totalScore = coinAmount;

    public static int coinAmount;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString();
        Debug.Log("CoinUpdate");
        CheckWin();
    }
    private void WinGame()
    {
        SceneManager.LoadScene("Win Scene");
    }

    private void CheckWin()
    {
        if (int.Parse(text.text) == 300)
        {
            Debug.Log("Win");
            WinGame();
        }
    }


    //void CheckPelletsConsumed()
    //{
    //    if (PlayerPlaying)
    //    {
    //        // Player is playing
    //        if (text == 300)
    //        {
    //            PlayerWin();
    //        }
    //    }
    //}
}
