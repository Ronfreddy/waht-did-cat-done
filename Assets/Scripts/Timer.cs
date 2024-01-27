using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLimit = 30f;

    public float currentTime = 30f;
    public bool isRunning = false;
    public bool isEnded = false;
    public bool isEnteringCutscene = false;

    private void Start()
    {
        GameManager.Instance.timer = this;
    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                isRunning = false;
                isEnded = true;
            }
        }

        if (isEnded)
        {
            if (Time.timeScale <= 0.1f)
            {
                Time.timeScale = 0;
                isEnded = false;
                isEnteringCutscene = true;
                GameManager.Instance.EndGame();
                return;
            }
            Time.timeScale -= 0.7f * Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        Debug.Log("Timer started");
        currentTime = timeLimit;
        isRunning = true;
    }

    public float GetTimePercentage()
    {
        return (timeLimit - currentTime) / timeLimit;
    }

    public void ResetTimer()
    {
        currentTime = timeLimit;
        isRunning = false;
        isEnded = false;
        isEnteringCutscene = false;
    }
}
