using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager 
{

    private static GameObject musicGameObject;
    private static AudioSource musicAudioSource;
    private static AudioClip music;

    public static void InitializeMusic(AudioClip clip)
    {
        musicGameObject = new GameObject("Music " + clip.name);
        musicAudioSource = musicGameObject.AddComponent<AudioSource>();
        music = clip;
    }

    public static void PlayMusic()
    {
        musicAudioSource.PlayOneShot(music);
    }

    public static void PauseMusic()
    {
        musicAudioSource.Pause();
    }

    public static void ResumeMusic() {
        musicAudioSource.UnPause();
    }


    public static void PlaySound(AudioClip clip)
    {
        GameObject soundGameObject = new GameObject(clip.name);
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(clip);

        Object.Destroy(soundGameObject, clip.length);
    }
    

}
