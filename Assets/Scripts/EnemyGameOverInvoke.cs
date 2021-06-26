
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGameOverInvoke : MonoBehaviour
{
    //public bool canMove = true;

    //public static bool gameOver = false;
    //public GameObject gameOverPanel;

    //private bool didStartDeath = false;

    //public void StartDeath()
    //{
    //    if (!didStartDeath)
    //    {
    //        didStartDeath = true;

    //        GameObject[] o = GameObject.FindGameObjectsWithTag("Ghost");

    //        foreach (GameObject ghost in o)
    //        {
    //            ghost.transform.GetComponent<NPCMovement>()
    //        }
    //    }
    //
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene("Game Over");
            //ScoreTextScript.coinAmount = 0;
            //GameObject[] o = GameObject.FindGameObjectsWithTag("FakeEnemy(Ghosts)");
            //foreach (GameObject ghost in o)
            //{
            //    ghost.transform.GetComponent<SpriteRenderer>().enabled = false;
            //}
            //Destroy(col.gameObject);
            //Destroy(gameObject);

            //gameOverPanel.SetActive(true);

            //collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //Destroy(collision.gameObject);
        }
    }
    

    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if(hit.transform.tag == "Enemy")
    //    {
    //        PlayerAliveStatus.gameOver = true;
    //    }
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Enemy"))
    //    {
    //        //ANIMATION_PLAYER_DIED
    //        Destroy(gameObject); //destroy player
    //    }
    //}
}