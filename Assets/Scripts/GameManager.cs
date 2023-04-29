using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] GameInput input;

    private bool paused;

    public event EventHandler<OnPauseEventArgs> OnPause;
    public class OnPauseEventArgs : EventArgs
    {
        public bool Paused;
    }
    

    private void Awake()
    {
        input.OnPauseToggle += Input_OnPauseToggle;
    }

    private void Start()
    {
        paused = false;
    }

    private void Input_OnPauseToggle(object sender, System.EventArgs e)
    {
        paused = !paused;
        
        if(paused)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }

        OnPause?.Invoke(this, new OnPauseEventArgs { Paused = paused });

    }

}
