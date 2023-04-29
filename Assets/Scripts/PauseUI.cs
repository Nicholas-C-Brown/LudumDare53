using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] Slider volumeSlider;

    private void Awake()
    {
        volumeSlider.value = SoundManager.GetVolume();
    }

    public void Resume()
    {
        gameManager.Resume();
    }

    public void ChangeVolume()
    {
        Debug.Log(volumeSlider.normalizedValue);
        SoundManager.SetVolume(volumeSlider.value);
    }


}
