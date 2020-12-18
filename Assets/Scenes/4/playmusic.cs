using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playmusic : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip backgroundMusic;

    void Start()
    {
        
    }

    public void playSound()
    {
        audioPlayer.Stop();
        audioPlayer.clip = backgroundMusic;
        audioPlayer.loop = true;
        audioPlayer.time = 0;
        audioPlayer.Play();
    }
        public void stopSound()
    {
        audioPlayer.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
