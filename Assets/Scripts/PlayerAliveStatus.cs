using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAliveStatus : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    void Start()
    {
        gameOverPanel.SetActive(false);
        //gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameOverPanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}
