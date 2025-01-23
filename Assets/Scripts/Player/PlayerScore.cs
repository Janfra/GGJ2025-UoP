using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Score Tracker", menuName = "Player Score Tracker")]
public class PlayerScore : ScriptableObject
{
    public delegate void ScoreUpdated(int newScore);
    public event ScoreUpdated OnNewHighscore;
    public event ScoreUpdated OnScored;
    public event ScoreUpdated OnScoredGetValue;

    public int Highscore => highscore;
    private int highscore;

    public int Score => score;
    [NonSerialized]
    private int score;

    public void ClearScore()
    {
        score = 0;
        OnScored?.Invoke(score);
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        OnScored?.Invoke(score);
        OnScoredGetValue?.Invoke(addScore);
        TryUpdateHighScore();
    }
    
    private void TryUpdateHighScore()
    {
        if (score > highscore)
        {
            // new highscore
            highscore = score;
            OnNewHighscore?.Invoke(highscore);
        }
    }
}
