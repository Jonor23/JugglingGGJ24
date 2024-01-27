using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    private Transform a_Transform;
    private Button startButton;
    private Button quitButton;

    private Transform gameScene_Transform;

    void Start()
    {
        a_Transform = gameObject.transform;
        gameScene_Transform = a_Transform.parent.Find("Game Scene");

        startButton = a_Transform.Find("StartButton").GetComponent<Button>();
        quitButton = a_Transform.Find("QuitButton").GetComponent<Button>();

        startButton.onClick.AddListener(StartButtonClick);
        quitButton.onClick.AddListener(QuitButtonClick);

        gameScene_Transform.gameObject.SetActive(false);
    }


    void Update()
    {
        
    }

    private void StartButtonClick()
    {
        gameScene_Transform.gameObject.SetActive(true);
        a_Transform.gameObject.SetActive(false);
    }

    private void QuitButtonClick()
    {
        Application.Quit();
    }
}
