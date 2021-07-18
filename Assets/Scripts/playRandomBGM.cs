using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playRandomBGM : MonoBehaviour
{
    private AudioSource audioSrc2;
    public AudioClip[] stressfulSounds;
    private int randomStressfulBGM;
    private void Awake()
    {
        audioSrc2 = GetComponent<AudioSource>();
    }
    void Start()
    {
        
        randomStressfulBGM = Random.Range(0, 6);
        audioSrc2.clip = stressfulSounds[randomStressfulBGM];
        audioSrc2.Play();
        //audioSrc2.PlayOneShot(stressfulSounds[randomStressfulBGM]);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
