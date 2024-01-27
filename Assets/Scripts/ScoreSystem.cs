using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int score = 0;

    private void Start()
    {
        GameManager.Instance.scoreSystem = this;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(1);
        }
    }

    public int GetScore()
    {
        return score;
    }
    
    public void AddScore(int amount)
    {
        score += amount;
    }
}
