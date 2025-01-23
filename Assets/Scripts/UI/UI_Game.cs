using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UI_Game : MonoBehaviour
{
    public const string SCORE_NAME = "Score";
    public const string KILLCOUNT_NAME = "KillCount";

    [SerializeField]
    private UIDocument UI;
    [SerializeField]
    private PlayerScore playerScore;
    [SerializeField]
    private bool ResetHighscoreOnStart = true;

    private Label scoreLabel;
    private Label killCountLabel;

    private string highscoreSuffix = "";
    private string killHighscoreSuffix = "";

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

        playerScore.OnScored += UpdateScoreLabel;
        playerScore.OnKillAdded += UpdateKillCount;
        playerScore.OnNewHighscore += EnableHighscoreUI;
        playerScore.OnNewKillHighscore += EnableKillHighscoreUI;
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
