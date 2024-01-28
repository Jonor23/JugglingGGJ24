using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    private Transform a_Transform;
    private Button startButton;
    private Button helpButton;
    private Button quitButton;

    private Transform helpPanel_Transform;
    private Transform gameScene_Transform;
    private Transform endPanel_Transform;

    void Start()
    {
        a_Transform = gameObject.transform;
        helpPanel_Transform = a_Transform.parent.Find("HelpPanel");
        gameScene_Transform = a_Transform.parent.Find("Game Scene");
        endPanel_Transform = a_Transform.parent.Find("EndPanel");

        startButton = a_Transform.Find("StartButton").GetComponent<Button>();
        helpButton = a_Transform.Find("HelpButton").GetComponent<Button>();
        quitButton = a_Transform.Find("QuitButton").GetComponent<Button>();

        startButton.onClick.AddListener(StartButtonClick);
        helpButton.onClick.AddListener(HelpButtonClick);
        quitButton.onClick.AddListener(QuitButtonClick);

        helpPanel_Transform.gameObject.SetActive(false);
        gameScene_Transform.gameObject.SetActive(false);
        endPanel_Transform.gameObject.SetActive(false);
    }


    void Update()
    {
        
    }

    private void StartButtonClick()
    {
        gameScene_Transform.gameObject.SetActive(true);
        a_Transform.gameObject.SetActive(false);
    }

    private void HelpButtonClick()
    {
        helpPanel_Transform.gameObject.SetActive(true);
    }

    private void QuitButtonClick()
    {
        Application.Quit();
    }
}
