using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] public Sound[] musicSounds, sfxSounds;
    [SerializeField] public AudioSource musicSource, sfxSource;

    [SerializeField] public bool musicIsPlay = true , sfxIsPlay = true;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic("BG");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.sName == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.sClip;
            musicSource.Play();
        }

    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.sName == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.sClip);

        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        if (musicIsPlay == true)
        {
            musicIsPlay = false;
        }
        else
        {
            musicIsPlay = true;
        }

    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
        if (sfxIsPlay == true)
        {
            sfxIsPlay = false;
        }
        else
        {
            sfxIsPlay = true;
        }
    }

    public void MusicVolumn(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolumn(float volume)
    {
        sfxSource.volume = volume;
    }

}
