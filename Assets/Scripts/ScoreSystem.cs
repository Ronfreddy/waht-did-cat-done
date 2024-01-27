using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int score = 0;

    public int GetScore()
    {
        return score;
    }
    
    public void AddScore(int amount)
    {
        score += amount;
    }
}
