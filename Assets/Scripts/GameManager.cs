using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector] public ScoreSystem scoreSystem;
    [HideInInspector] public Timer timer;
    [HideInInspector] public GameObject cat;

    //Do not destroy on load
    protected void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

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

    public void ResetGame()
    {
        cat = null;
    }
}
