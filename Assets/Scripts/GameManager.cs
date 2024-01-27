using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector] public ScoreSystem scoreSystem;
    [HideInInspector] public Timer timer;

    public void StartGame()
    {
        if (timer != null)
        {
            timer.StartTimer();
        }
    }

    public void EndGame()
    {
        if (scoreSystem != null)
        {
            Debug.Log("Game Over! Score: " + scoreSystem.GetScore());
        }
    }
}
