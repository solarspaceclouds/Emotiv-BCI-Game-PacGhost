using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameSound : MonoBehaviour
{
    private AudioSource audioSrc;
    public AudioClip[] WinSound;
    public AudioClip[] LoseSound;
    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    void Start()
    {
        if (ScoreTextScript.gameWon == 1)
        {
            audioSrc.clip = WinSound[0];
            audioSrc.Play();
        }
        else if (ScoreTextScript.gameWon == 2)
        {
            audioSrc.clip = LoseSound[0];
            audioSrc.Play();
        }
        

        //audioSrc2.PlayOneShot(stressfulSounds[randomStressfulBGM]);        
    }

    // Update is called once per frame
    void Update()
    {

    }


}
