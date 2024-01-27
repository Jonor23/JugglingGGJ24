using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private Transform a_Transform;
    private Text timer;
    private int timeLeft;

    private void Awake()
    {
        
    }

    void Start()
    {
        a_Transform = gameObject.transform;
        timer = a_Transform.Find("Time").GetComponent<Text>();
        Debug.Log(timer.name);
        timeLeft = 60;
        StartCoroutine("TimeElapse");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeElapse()
    {
        while(timeLeft > 0)
        {
            yield return new WaitForSeconds(1.0f);
            timeLeft = timeLeft - 1;
            timer.text = "Time: " + timeLeft.ToString();
        }        
    }
}
