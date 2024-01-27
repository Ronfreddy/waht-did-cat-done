using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float timeLimit = 30f;

    private float currentTime;
    private bool isRunning = false;
    private bool isEnded = false;

    private void Start()
    {
        GameManager.Instance.timer = this;
        StartTimer();
    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            slider.value = (timeLimit - currentTime) / timeLimit;
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
                GameManager.Instance.EndGame();
                return;
            }
            Time.timeScale -= 0.7f * Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        currentTime = timeLimit;
        isRunning = true;
    }
}
