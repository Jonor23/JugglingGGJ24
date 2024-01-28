using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpUI : MonoBehaviour
{
    private Transform a_Transform;
    private Button backButton;

    private Transform startPanel_Transform;

    void Start()
    {
        a_Transform = gameObject.transform;
        startPanel_Transform = a_Transform.parent.Find("StartPanel");

        backButton = a_Transform.Find("BackButton").GetComponent<Button>();

        backButton.onClick.AddListener(BackButtonClick);
    }

    private void BackButtonClick()
    {
        a_Transform.gameObject.SetActive(false);
    }
}
