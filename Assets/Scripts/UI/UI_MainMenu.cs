using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UI_MainMenu : MonoBehaviour
{
    public const string QuitButton = "Quit";

    [SerializeField]
    private UIDocument UI;

    private void Start()
    {
        if (UI == null)
        {
            UI = GetComponent<UIDocument>();
        }

        Button quitButton = UI.rootVisualElement.Q<Button>(QuitButton);
        if (quitButton != null )
        {
            quitButton.clicked += OnQuit;
        }
    }

    private void OnQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
