using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;

    public static int gameWon;

    public static int coinAmount;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinAmount.ToString();
    }

    private void CheckWin()
    {
        if (int.Parse(text.text) == 300)
        {
            //Debug.Log("Win");
            gameWon = 1;
            SceneManager.LoadScene("Game Over");
            
        }
        else
        {
            // Lost
            gameWon = 2;
        }
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
        CheckWin();

        
        
    }

}
