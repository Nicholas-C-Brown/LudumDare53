using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] private AudioClip music;

    private void Start()
    {
        SoundManager.PlaySound(music);
    }

}
