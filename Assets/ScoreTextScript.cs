using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;

    public static bool gameWon;

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

    private void CheckWin()
    {
        if (int.Parse(text.text) == 300)
        {
            //Debug.Log("Win");
            gameWon = true;
            SceneManager.LoadScene("Game Over");
        }
        else
        {
            gameWon = false;
        }
    }

}
