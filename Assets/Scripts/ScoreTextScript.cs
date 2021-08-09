using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{

    // Start is called before the first frame update
    public Text text;
    public static int score;
    //public string playerName = BrainFramework.Profile;
    //public Text cloneScoreText;

    public static int gameWon = 2;

    public static int coinAmount;

    //public int finalScore;
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // update score according to coin amount
        text.text = "Player: " + BrainFramework.Profile + "\nScore: " + coinAmount;
        score = coinAmount;
        //PlayerPrefs.SetInt("finalScore", coinAmount);
        //PlayerPrefs.Save();

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

}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.UI;

//public class ScoreTextScript : MonoBehaviour
//{

//    // Start is called before the first frame update
//    public Text text;

//    public static int gameWon=2;

//    public static int coinAmount;
//    void Start()
//    {
//        text = GetComponent<Text>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // update score according to coin amount

//        text.text = "Player: " + BrainFramework.Profile + "\nScore: " + coinAmount;

//        //text.text = coinAmount.ToString();
//    }

//    private void FixedUpdate()
//    {
//        if (Input.GetKeyDown(KeyCode.Escape))
//        {
//            Application.Quit();
//            Debug.Log("Escaped!");
//            //if (Application.isEditor)
//            //{
//            //    UnityEditor.EditorApplication.isPlaying = false;
//            //}
//        }
//    }

//}
