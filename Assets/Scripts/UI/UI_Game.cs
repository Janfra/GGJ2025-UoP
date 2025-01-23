using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UI_Game : MonoBehaviour
{
    public const string SCORE_NAME = "Score";
    public const string KILLCOUNT_NAME = "KillCount";
    public const string TIMER_NAME = "Timer";

    [SerializeField]
    private UIDocument UI;
    [SerializeField]
    private PlayerScore playerScore;
    [SerializeField]
    private bool ResetHighscoreOnStart = true;
    [SerializeField]
    private PlayTimeTracker playTimer;

    private Label scoreLabel;
    private Label killCountLabel;
    private Label timerLabel;

    private string highscoreSuffix = "";
    private string killHighscoreSuffix = "";

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        if (UI == null)
        {
            UI = GetComponent<UIDocument>();
        }

        if (ResetHighscoreOnStart)
        {
            playerScore.ResetHighscores();
        }

        VisualElement root = UI.rootVisualElement;
        scoreLabel = root.Q<Label>(SCORE_NAME);
        killCountLabel = root.Q<Label>(KILLCOUNT_NAME);
        timerLabel = root.Q<Label>(TIMER_NAME);

        playerScore.OnScored += UpdateScoreLabel;
        playerScore.OnKillAdded += UpdateKillCount;
        playerScore.OnNewHighscore += EnableHighscoreUI;
        playerScore.OnNewKillHighscore += EnableKillHighscoreUI;
    }

    private void Update()
    {
        if (!isPaused)
        {
            playTimer.TickTimer();
            TimeSpan timeSpan = TimeSpan.FromSeconds(playTimer.PlayTime);
            timerLabel.text = $"Timer: {timeSpan.ToString("mm\\:ss")}";
        }
    }

    private void OnGameFinished()
    {
        playerScore.AddScore(playTimer.GetTimerScore());
        playTimer.ResetTimer();
    }

    private void UpdateScoreLabel(int newScore)
    {
        scoreLabel.text = $"Score: {newScore}" + highscoreSuffix;
    }

    private void UpdateKillCount(int killCount)
    {
        killCountLabel.text = $"Kills: {killCount}" + killHighscoreSuffix;
    }

    private void EnableHighscoreUI(int newHighscore)
    {
        highscoreSuffix = "!!";
    }

    private void EnableKillHighscoreUI(int newKillHighscore)
    {
        killHighscoreSuffix = "!!";
    }
}
