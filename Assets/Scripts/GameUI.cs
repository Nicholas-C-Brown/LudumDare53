using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameUI : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] TMP_Text scoreTMP;
    [SerializeField] TMP_Text multiplierTMP;
    [SerializeField] TMP_Text speedTMP;

    private int score;

    private void Start()
    {
        score = 0;
        UpdateScoreText();

        player.OnKill += Player_OnKill;
    }

    private void Player_OnKill(object sender, Player.OnKillEventArgs e)
    {
        score += e.Points;
        UpdateScoreText();
    }

    private void Update()
    {
        UpdateSpeedText();   

    }

    private void UpdateSpeedText()
    {
        speedTMP.text = string.Format("{0:0} Km/h", player.GetSpeed());
    }

    private void UpdateScoreText()
    {
        scoreTMP.text = string.Format("Score: {0}", score);
    }


}
