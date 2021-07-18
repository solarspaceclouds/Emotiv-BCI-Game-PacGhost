using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin2 : MonoBehaviour
{
    // Start is called before the first frame update
    public int pelletValue = 3;
    public int pellet3Total=0;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ScoreTextScript.coinAmount += pelletValue;
            pellet3Total +=pelletValue;
            Destroy(gameObject);
            SoundManager.sndMan.PlayCoinSound();
        }

    }
}

