using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject pauseUI;

    private void Awake()
    {
        gameManager.OnPause += GameManager_OnPause;
    }

    private void GameManager_OnPause(object sender, GameManager.OnPauseEventArgs e)
    {
        pauseUI.SetActive(e.Paused);
    }
}
