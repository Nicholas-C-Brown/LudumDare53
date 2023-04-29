using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager 
{

    [SerializeField] [Range(0, 1)] private static float volume = 1;

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
        musicAudioSource.PlayOneShot(music, volume);
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
        audioSource.PlayOneShot(clip, volume);

        Object.Destroy(soundGameObject, clip.length);
    }

    public static float GetVolume()
    {
        return volume;
    }

    public static void SetVolume(float level)
    {

        if (level < 0 || level > 1)
        {
            Debug.LogError("Invalid volume level");
        }

        volume = level;

        if(musicAudioSource != null)
        {
            musicAudioSource.volume = volume;
        }

    }
    

}
