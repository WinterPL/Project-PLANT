using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public Toggle _musicToggle, _sfxToggle;

    private void Start()
    {
        _musicSlider.value = SoundManager.Instance.musicSource.volume;
        _sfxSlider.value = SoundManager.Instance.sfxSource.volume;

        if(SoundManager.Instance.musicIsPlay == true)
        {
            _musicToggle.isOn = true;
        }
        else 
        {
            _musicToggle.isOn = false;
            SoundManager.Instance.ToggleMusic();
        }


        if (SoundManager.Instance.sfxIsPlay == true)
        {
            _sfxToggle.isOn = true;
        }
        else
        {
            _sfxToggle.isOn = false;
            SoundManager.Instance.ToggleSFX();
        }

    }

    public void ToggleMusic()
    {
        SoundManager.Instance.ToggleMusic();
    }

    public void ToggleSFX()
    {
        SoundManager.Instance.ToggleSFX();
    }

    public void ToggleAngleGift()
    {
        GameManager.Instance.AngelGift();
    }

    public void MusicVolumn()
    {
        SoundManager.Instance.MusicVolumn(_musicSlider.value);
    }

    public void SFXVolumn()
    {
        SoundManager.Instance.SFXVolumn(_sfxSlider.value);
    }


}
