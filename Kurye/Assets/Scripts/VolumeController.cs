using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    public Slider bgMusicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        bgMusicSlider.value = PlayerPrefs.GetFloat("BGMusicVolume", 1);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);

        bgMusicSlider.onValueChanged.AddListener(SetBGMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }
    private void SetBGMusicVolume(float volume)
    {
        AudioManager.instance.SetBGMusicVolume(volume);
    }
    private void SetSFXVolume(float volume)
    {
        AudioManager.instance.SetSFXVolume(volume);
    }

}
