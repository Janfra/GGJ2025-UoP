using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UI_Game : MonoBehaviour
{
    public const string SCORE_NAME = "Score";

    [SerializeField]
    private UIDocument UI;
    [SerializeField]
    private PlayerScore playerScore;

    private Label score;

    // Start is called before the first frame update
    void Start()
    {
        if (UI == null)
        {
            UI = GetComponent<UIDocument>();
        }

        score = UI.rootVisualElement.Q<Label>(SCORE_NAME);
        playerScore.OnScored += UpdateScoreLabel;
    }

    private void UpdateScoreLabel(int newScore)
    {
        score.text = $"Score: {newScore}";
    }
}
