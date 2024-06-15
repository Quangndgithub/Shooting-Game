using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource backGrndSource;
    public AudioSource sfxSource;
    public AudioClip shootClip;
    public AudioClip deadClip;
    public AudioClip backGrndClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        PlayBackGrndSound();
    }
    void PlayBackGrndSound()
    {
        backGrndSource.clip = backGrndClip;
        backGrndSource.Play();
    }
    public void PlayShootSound()
    {
        sfxSource.PlayOneShot(shootClip);
    }
    public void PlayDeadSound()
    {
        sfxSource.PlayOneShot(deadClip);
    }
}
