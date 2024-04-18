using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    AudioSource AudioSource;
    public AudioClip bgmusic;
    // float t = 0.0f;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        audioSource.volume = 0.3f;
        audioSource.clip = this.bgmusic;
        audioSource.Play();
    }

}
