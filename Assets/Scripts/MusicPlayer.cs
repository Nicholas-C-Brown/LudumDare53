using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioClip music;

    private void Awake()
    {
        gameManager.OnPause += GameManager_OnPause;
    }

    private void Start()
    {
        SoundManager.InitializeMusic(music);
        SoundManager.PlayMusic();
    }

    private void GameManager_OnPause(object sender, GameManager.OnPauseEventArgs e)
    {
        if(e.Paused)
        {
            SoundManager.PauseMusic();
        } else
        {
            SoundManager.ResumeMusic();
        }
    }





}
