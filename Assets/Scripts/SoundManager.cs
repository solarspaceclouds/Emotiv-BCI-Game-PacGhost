using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sndMan;
    private AudioSource audioSrc;

    private AudioClip[] coinSounds;
    private int randomCoinSound;
    
    void Start()
    {
        sndMan = this;
        audioSrc = GetComponent<AudioSource>();
        coinSounds = Resources.LoadAll<AudioClip>("CoinSounds");
    }

    // Update is called once per frame
    public void PlayCoinSound()
    {
        randomCoinSound = 0;
        //randomCoinSound = Random.Range(0, 5); # 5 items
        audioSrc.PlayOneShot(coinSounds[randomCoinSound]);
    }
}
