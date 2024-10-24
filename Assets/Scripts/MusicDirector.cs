using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicDirector : MonoBehaviour
{
    public AudioMixer mixer;
    public AudioSource mainTrack;
    public AudioSource mainMapTrack;
    public Slider masterSlider;
    public Slider sfxSlider;
    public Slider musicSlider;
    public AudioSource milkingMinigameTrack;
    public AudioSource boilingMinigameTrack;
    public AudioSource spinningMinigameTrack;
    public AudioSource farmingMinigameTrack;

    void Start () {
        if(!PlayerPrefs.HasKey("MasterVolume")) {
            PlayerPrefs.SetFloat("MasterVolume", -20f);
            PlayerPrefs.SetFloat("MusicVolume", 0f);
            PlayerPrefs.SetFloat("SFXVolume", 0f);
        }
        mixer.SetFloat("Master", PlayerPrefs.GetFloat("MasterVolume"));
        mixer.SetFloat("SFX", PlayerPrefs.GetFloat("SFXVolume"));
        mixer.SetFloat("Music", PlayerPrefs.GetFloat("MusicVolume"));
        SetSliders();
    }

    public void UpdateMasterVolume () {
        mixer.SetFloat("Master", masterSlider.value);
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
    }

    public void UpdateSFXVolume() {
        mixer.SetFloat("SFX", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }

    public void UpdateMusicVolume() {
        mixer.SetFloat("Music", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    void SetSliders ()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
    }

    public void StartMainBGM() {
        if (!mainMapTrack.isPlaying) {
            mainMapTrack.Play();
        }
        boilingMinigameTrack.Stop();
        spinningMinigameTrack.Stop();
        milkingMinigameTrack.Stop();
        farmingMinigameTrack.Stop();
    }
    public void StartMilkingBGM() {
        mainMapTrack.Stop();
        boilingMinigameTrack.Stop();
        spinningMinigameTrack.Stop();
        farmingMinigameTrack.Stop();
        
        if (!milkingMinigameTrack.isPlaying) {
            milkingMinigameTrack.Play();
        }
    }
    public void StartBoilingBGM() {
        mainMapTrack.Stop();
        spinningMinigameTrack.Stop();
        milkingMinigameTrack.Stop();
        farmingMinigameTrack.Stop();
        
        if (!boilingMinigameTrack.isPlaying) {
            boilingMinigameTrack.Play();
        }
    }
    public void StartSpinningBGM() {
        mainMapTrack.Stop();
        boilingMinigameTrack.Stop();
        milkingMinigameTrack.Stop();
        farmingMinigameTrack.Stop();
        
        if (!spinningMinigameTrack.isPlaying) {
            spinningMinigameTrack.Play();
        }
    }
    public void StartFarmingBGM() {
        mainMapTrack.Stop();
        boilingMinigameTrack.Stop();
        spinningMinigameTrack.Stop();
        milkingMinigameTrack.Stop();
        
        if (!farmingMinigameTrack.isPlaying) {
            farmingMinigameTrack.Play();
        }
    }
}
