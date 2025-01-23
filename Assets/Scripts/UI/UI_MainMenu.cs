using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(UIDocument))]
public class UI_MainMenu : MonoBehaviour
{
    public const string QUIT_BUTTON = "Quit";

    [SerializeField]
    private UIDocument UI;

    private void Start()
    {
        if (UI == null)
        {
            UI = GetComponent<UIDocument>();
        }

        Button quitButton = UI.rootVisualElement.Q<Button>(QUIT_BUTTON);
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
