using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeStart;
    public bool timerRunning = false;

    [SerializeField] private float timeLimit = 60f;


    // Start is called before the first frame update
    void Start()
    {
        // Starts the timer automatically
        timerRunning = true;
        timeStart = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // Slow down the game when the timer is up
        if(Time.time >= timeStart + timeLimit && Time.timeScale > 0.1f)
        {
            timerRunning = false;
            Time.timeScale -= 0.7f * Time.deltaTime;
            Debug.Log(Time.timeScale);
        }
        else if(Time.timeScale <= 0.1f)
        {
            Time.timeScale = 0;
        }
    }
}
