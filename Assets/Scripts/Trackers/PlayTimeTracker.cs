using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayTimeTracker
{
    [SerializeField]
    private int perSecondScore = 1;

    public float PlayTime => playTime;
    [NonSerialized]
    private float playTime;
    
    public void TickTimer()
    {
        playTime += Time.deltaTime;
    }

    public int GetTimerScore()
    {
        return Mathf.FloorToInt(playTime) * perSecondScore;
    }

    public void ResetTimer()
    {
        playTime = 0;
    }
}
