using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int pelletValue=1;
    public int pelletTotal=0;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ScoreTextScript.coinAmount += pelletValue;
            pelletTotal++;
            Destroy(gameObject);
            SoundManager.sndMan.PlayCoinSound();
        }
            
    }
}
