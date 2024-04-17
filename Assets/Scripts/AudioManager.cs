using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource AudioSource;
    public AudioClip bgmusic;

    public float t = 0.0f;

    private bool pitchFlag1;
    private bool pitchFlag2;

    // float t = 0.0f;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.3f;
        audioSource.clip = this.bgmusic;
        audioSource.Play();
    }
    //  private void Update()
    //  {
    // t += Time.deltaTime;
    //
    //     if (t > 2.0f && pitchFlag1 == false)
    //    {
    // AudioSource.pitch = 1.5f;
    // pitchFlag1 = true;
    // Debug.Log(1);
    // }
    //    else if (t > 10.0f && pitchFlag2 == false)
    //    {
    //AudioSource.pitch = 2f;
    //pitchFlag2 = true;
    //Debug.Log(2);
    //}
    //}
}
