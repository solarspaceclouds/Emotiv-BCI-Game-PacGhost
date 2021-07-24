using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static bool gameOver = false;

    public float speedMultiplier = 1.0f; 

    public float speed = 4f;
    // Start is called before the first frame update
    //private string WALL_TAG = "Wall";
    //private string ENEMY_TAG = "Enemy";
    //private string FOOD_TAG = "Food";

    //GameObject speedUpper;
    //SpeedUp speedUpScript;

    [SerializeField]
    private float minX, maxX, minY, maxY;
    void Start()
    {
        //speedUpper = GameObject.Find("SpeedController");
        //speedUpScript = speedUpper.GetComponent<SpeedUp>();
        //SoundManager.sndMan.PlayStressfulBGM();

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //float h = Input.GetAxis("Horizontal") * speedMultiplier;
        //float v = Input.GetAxis("Vertical") * speedMultiplier;

        Vector2 pos = transform.position;
        pos.x += h * speed * Time.deltaTime;
        pos.y += v * speed * Time.deltaTime;

        if (pos.x < minX)
        {
            pos.x = minX;
        }

        if (pos.x > maxX)
        {
            pos.x = maxX;
        }

        if (pos.y < minY)
        {
            pos.y = minY;
        }

        if (pos.y > maxY)
        {
            pos.y = maxY;
        }

        transform.position = pos;
        CheckWin();
    }

    //public IEnumerator StopSpeedUp()
    //{
    //    yield return new WaitForSeconds(6f); // the number corresponds to the number of seconds the speed up will be applied
    //    speedMultiplier = 1.0f; // back to normal !
    //}
    void CheckWin()
    {
        if (ScoreTextScript.coinAmount==300)
        {
            //Debug.Log("Win");
            ScoreTextScript.gameWon = 1;
            SceneManager.LoadScene("Game Over");
        }
        //else
        //{
        //    // Lost
        //    gameWon = 2;

        //}
    }
}