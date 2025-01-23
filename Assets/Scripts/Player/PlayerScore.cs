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
    public event ScoreUpdated OnKillAdded;
    public event ScoreUpdated OnNewKillHighscore;

    public int Highscore => highscore;
    private int highscore;

    public int Score => score;
    [NonSerialized]
    private int score;


    public int KillHighscore => killHighscore;
    private int killHighscore;

    public int KillCount => killCount;
    [NonSerialized]
    private int killCount;

    public void ResetHighscores()
    {
        highscore = 0;
        killHighscore = 0;
    }

    public void ClearScore()
    {
        score = 0;
        OnScored?.Invoke(score);
    }

    public void AddKillCount()
    {
        killCount++;
        OnKillAdded?.Invoke(killCount);
        TryUpdateKillHighscore();
    }

    private void TryUpdateKillHighscore()
    {
        if (killCount > killHighscore)
        {
            killHighscore = killCount;
            OnNewKillHighscore?.Invoke(killHighscore);
        }
    }

    public void AddScore(int addScore)
    {
        score += addScore;
        OnScored?.Invoke(score);
        OnScoredGetValue?.Invoke(addScore);
        TryUpdateHighscore();
    }
    
    private void TryUpdateHighscore()
    {
        if (score > highscore)
        {
            // new highscore
            highscore = score;
            OnNewHighscore?.Invoke(highscore);
        }
    }
}
