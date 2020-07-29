using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager s_instance;

    public AudioSource bgAudioSource;
    public AudioSource audioSource;
    public AudioClip shoot;
    public AudioClip push;
    public AudioClip bounce;

    private void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
        }
        else if (s_instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    public void Play(AudioClip _clip)
    {
        audioSource.clip = _clip;
        audioSource.Play();
    }

    public void PlayShoot()
    {
        Play(shoot);
    }

    public void PlayPush()
    {
        Play(push);
    }

    public void PlayBounce()
    {
        Play(bounce);
    }

    public void PlayBG()
    {
        bgAudioSource.Play();
    }
}
