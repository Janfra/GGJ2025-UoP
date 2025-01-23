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
    public const string TOWNDIRT_NAME = "TownDirt";
    public const string LOSTPOPUP_NAME = "LostPopup";
    public const string RESTART_NAME = "Restart";

    [SerializeField]
    private UIDocument UI;
    [SerializeField]
    private PlayerScore playerScore;
    [SerializeField]
    private bool ResetHighscoreOnStart = true;
    [SerializeField]
    private PlayTimeTracker playTimer;
    [SerializeField]
    private TownDirtTracker townDirtTracker;

    private Label scoreLabel;
    private Label killCountLabel;
    private Label timerLabel;
    private ProgressBar townDirtProgress;
    private VisualElement lostPopup;
    private Button restartButton;

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
        townDirtProgress = root.Q<ProgressBar>(TOWNDIRT_NAME);
        lostPopup = root.Q<VisualElement>(LOSTPOPUP_NAME);
        restartButton = root.Q<Button>(RESTART_NAME);

        lostPopup.style.opacity = 0.0f;

        playerScore.OnScored += UpdateScoreLabel;
        playerScore.OnKillAdded += UpdateKillCount;
        playerScore.OnNewHighscore += EnableHighscoreUI;
        playerScore.OnNewKillHighscore += EnableKillHighscoreUI;

        townDirtTracker.maxDirtinessReached += OnGameFinished;
        townDirtTracker.dirtinessRemoved += UpdateTownDirtProgress;
        townDirtTracker.dirtinessAdded += UpdateTownDirtProgress;
        townDirtProgress.highValue = townDirtTracker.MaxDirtiness;
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

    private void UpdateTownDirtProgress(float dirtiness)
    {
        townDirtProgress.value = dirtiness;
    }

    private void OnGameFinished(float dirtiness)
    {
        lostPopup.style.opacity = 1.0f;
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
