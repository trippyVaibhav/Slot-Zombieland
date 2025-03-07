using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource bg_adudio;
    [SerializeField] internal AudioSource audioPlayer_wl;
    [SerializeField] internal AudioSource audioPlayer_button;
    [SerializeField] private AudioClip[] clips;


    private void Start()
    {
        if (bg_adudio) bg_adudio.Play();
        audioPlayer_button.clip = clips[clips.Length-1];
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {

            bg_adudio.Pause();
            audioPlayer_wl.Pause();
            audioPlayer_button.Pause();
        }
        else
        {
            if (!bg_adudio.mute) bg_adudio.Play();
            if (!audioPlayer_wl.mute) audioPlayer_wl.Play();
            if (!audioPlayer_button.mute) audioPlayer_button.Play();

        }
    }

    internal void PlayWLAudio(string type)
    {
        
        int index = 0;
        switch (type)
        {
            case "spin":
                index = 0;
                break;
            case "win":
                index = UnityEngine.Random.Range(1, 2);
                break;
            case "lose":
                index = 3;
                break;
        }
        StopWLAaudio();
        audioPlayer_wl.clip = clips[index];
        audioPlayer_wl.loop = true;
        audioPlayer_wl.Play();

    }

    internal void PlayButtonAudio() {
        StopButtonAudio();
        audioPlayer_button.Play();
        Invoke("StopButtonAudio", audioPlayer_button.clip.length);

    }

    internal void StopWLAaudio()
    {
        audioPlayer_wl.Stop();
        audioPlayer_wl.loop = false;
    }

    internal void StopButtonAudio() {

        audioPlayer_button.Stop();

    }

    internal void StopBgAudio() {
        bg_adudio.Stop();

    }

    internal void ToggleMute(bool toggle, string type="all") {

        switch (type)
        {
            case "bg":
                bg_adudio.mute = toggle;
                break;
            case "button":
                audioPlayer_button.mute=toggle;
                break;
            case "wl":
                audioPlayer_wl.mute=toggle;
                break;
            case "all":
                audioPlayer_wl.mute = toggle;
                bg_adudio.mute = toggle;
                audioPlayer_button.mute = toggle;
                break;
        }
    }

    internal void ChangeVolume(string type, float vol) {
        switch (type)
        {
            case "bg":

                    bg_adudio.mute = (vol==0);
                    bg_adudio.volume=vol;
                break;
            case "button":
                    audioPlayer_button.mute = (vol == 0);
                    audioPlayer_button.volume = vol;
                break;
            case "wl":
                    audioPlayer_wl.mute = (vol == 0);
                    audioPlayer_wl.volume = vol;
                break;
            case "all":

                    audioPlayer_wl.mute = (vol == 0);
                    bg_adudio.mute = (vol == 0);
                    audioPlayer_button.mute = (vol == 0);
                    audioPlayer_wl.volume = vol;
                    bg_adudio.volume = vol;
                    audioPlayer_button.volume = vol;
                break;
        }

    }

}
