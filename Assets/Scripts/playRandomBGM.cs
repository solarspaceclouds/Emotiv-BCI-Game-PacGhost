using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playRandomBGM : MonoBehaviour
{
    private AudioSource audioSrc2;
    public AudioClip[] stressfulSounds;
    public AudioClip[] calmSounds;
    private int randomStressfulBGM;
    private int randomCalmBGM;
    private void Awake()
    {
        audioSrc2 = GetComponent<AudioSource>();
    }
    void Start()
    {

        switch (SetDifficultyMode.Difficulty)
        {
            case SetDifficultyMode.Difficulties.Easy:
                randomCalmBGM = Random.Range(0, 6);
                audioSrc2.clip = calmSounds[randomCalmBGM];
                audioSrc2.Play();
                break;

            case SetDifficultyMode.Difficulties.Hard:
                randomStressfulBGM = Random.Range(0, 6);
                audioSrc2.clip = stressfulSounds[randomStressfulBGM];
                audioSrc2.Play();
                break;

            default:
                randomStressfulBGM = Random.Range(0, 6);
                audioSrc2.clip = stressfulSounds[randomStressfulBGM];
                audioSrc2.Play();
                break;
        }
        
        //audioSrc2.PlayOneShot(stressfulSounds[randomStressfulBGM]);        
    }

}
