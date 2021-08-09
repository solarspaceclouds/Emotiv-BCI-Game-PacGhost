using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static bool gameOver = false;

    public float boostTimer;
    public bool boosting;
    public float speed;

    public GameObject smileOnIndicator;
    public GameObject smileOffIndicator;
    public static int smileCount = 0;

    public GameObject fakeEnemyCollection;

    [SerializeField]
    private float minX, maxX, minY, maxY;

    private void Awake()
    {
        if (MainMenuController.gameMode == "Easy")
        {
            fakeEnemyCollection.SetActive(false);
        }
    }
    void Start()
    {
        //speedTrigger.SetActive(false);
        boosting = false;
        speed = 4f;
        boostTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Speed" + speed);
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

        if (!boosting)
        {
            smileOnIndicator.SetActive(false);
            smileOffIndicator.SetActive(true);
            Debug.Log("Boost OFF");
            speed = 4f;
            boostTimer = 0f;
            boosting = false;
        }
        else // if boosting
        {
            Debug.Log("Boost ON");
            speed = 7f;
            smileOnIndicator.SetActive(true);
            smileOffIndicator.SetActive(false);
            boostTimer += Time.deltaTime;
            if (boostTimer >= 5)
            {
                Debug.Log("Boost OFF 2");
                smileCount++;
                speed = 4f;
                boostTimer = 0f;
                boosting = false;
            }
        }

        //if (boosting)
        //{
        //    Debug.Log("Boost ON");
        //    speed = 7f;
        //    boostTimer += Time.deltaTime;
        //    if (boostTimer>=5)
        //    {
        //        Debug.Log("Boost OFF");
        //        speed = 4f;
        //        boostTimer = 0f;
        //        boosting = false;
        //    }
        //}
        //else
        //{
        //    smileOnIndicator.SetActive(false);
        //    smileOffIndicator.SetActive(true);
        //}

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
        else
        {
            // Lost
            ScoreTextScript.gameWon = 2;

        }
    }
}