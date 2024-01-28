using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndUI : MonoBehaviour
{
    private Transform a_Transform;
    private Transform a_StartPanel;
    private Transform a_GamePanel;

    private Image judgement_Image;
    private Image outcome_Image;
    private Button backButton;
    private Button quitButton;

    private Sprite success_judge;
    private Sprite fail_judge;
    private Sprite win_Outcome;
    private Sprite lose_Outcome;

    void Start()
    {
        a_Transform = gameObject.transform;
        a_StartPanel = a_Transform.parent.Find("StartPanel");
        a_GamePanel = a_Transform.parent.Find("Game Scene");

        judgement_Image = a_Transform.Find("Judgement").GetComponent<Image>();
        outcome_Image = a_Transform.Find("Outcome").GetComponent<Image>();

        success_judge = Resources.Load<Sprite>("Judgement/YouSucceeded!");
        fail_judge = Resources.Load<Sprite>("Judgement/YouFailed!");
        win_Outcome = Resources.Load<Sprite>("Judgement/Win");
        lose_Outcome = Resources.Load<Sprite>("Judgement/Lose");

        backButton = a_Transform.Find("BackButton").GetComponent<Button>();
        quitButton = a_Transform.Find("QuitButton").GetComponent<Button>();

        backButton.onClick.AddListener(BackButtonClick);
        quitButton.onClick.AddListener(QuitButtonClick);
    }


    public void DisplayWin()
    {
        Debug.Log(judgement_Image.name);
        Debug.Log(success_judge.name);
        judgement_Image.sprite = success_judge;
        outcome_Image.sprite = win_Outcome;
    }

    public void DisplayLost()
    {
        judgement_Image.sprite = fail_judge;
        outcome_Image.sprite = lose_Outcome;
    }

    private void BackButtonClick()
    {
        a_StartPanel.gameObject.SetActive(true);
        a_GamePanel.gameObject.SetActive(false);
        a_Transform.gameObject.SetActive(false);
    }

    private void QuitButtonClick()
    {
        Application.Quit();
    }
}
