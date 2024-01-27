using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [HideInInspector] public ScoreSystem scoreSystem;
    [HideInInspector] public Timer timer;
    [HideInInspector] public SoundManager soundManager;
    [HideInInspector] public GameObject cat;

    //Do not destroy on load
    protected void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if(GameObject.FindGameObjectsWithTag("GameManager").Length > 1)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(soundManager == null)
        {
            soundManager = GetComponentInChildren<SoundManager>();
        }
    }

    public void StartLevel()
    {

    }

    public void GameStart()
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
