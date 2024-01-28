using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private Transform a_Transform;
    private Transform a_GamePanel;
    private Transform a_EndPanel;

    private Image timer_Image;
    private Image num1_Image;
    private Image num2_Image;

    private int timeLeft;
    private bool gameStop;

    private Scrollbar performance_Bar;


    private List<Sprite> numbers;


    private void Awake()
    {
    }

    void Start()
    {
        a_Transform = gameObject.transform;
        a_GamePanel = a_Transform.parent;
        a_EndPanel = a_GamePanel.parent.Find("EndPanel");

        timer_Image = a_Transform.Find("Time").GetComponent<Image>();
        num1_Image = timer_Image.transform.Find("Num1").GetComponent<Image>();
        num2_Image = timer_Image.transform.Find("Num2").GetComponent<Image>();

        performance_Bar = a_Transform.Find("Performance").GetComponent<Scrollbar>();

        numbers = new List<Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>("Numbers");
        for(int i = 0; i < sprites.Length; i++)
        {
            numbers.Add(sprites[i]);
        }
        StartCoroutine("TimeElapse");


    }

    private void OnEnable()
    {
        timeLeft = 60;
        gameStop = false;
        performance_Bar.size = 0;
        StartCoroutine("TimeElapse");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J))
        {
            performance_Bar.size += 0.001f;
        }
        if (Input.GetKey(KeyCode.K))
        {
            performance_Bar.size -= 0.001f;
        }
    }

    IEnumerator TimeElapse()
    {
        while(timeLeft > 0 && !gameStop)
        {
            //Debug.Log("Hello?");
            yield return new WaitForSeconds(1.0f);
            timeLeft = timeLeft - 1;
            TimeToImage(timeLeft);
        }
        gameStop = true;
        a_EndPanel.gameObject.SetActive(true);
        if(timeLeft <= 0)
        {
            a_EndPanel.GetComponent<EndUI>().DisplayLost();
        }
        
    }

    private void TimeToImage(int time)
    {
        int num1 = time / 10;
        int num2 = time % 10;
        //Debug.Log(num1 + "  " + num2);
        num1_Image.sprite = numbers[num1];
        num2_Image.sprite = numbers[num2];
    }

    public void AddScore(float value)
    {
        if(timeLeft > 0 && !gameStop)
        {
            performance_Bar.size += value;
            if (performance_Bar.size >= 1.0f)
            {
                gameStop = true;
                a_EndPanel.gameObject.SetActive(true);
                a_EndPanel.GetComponent<EndUI>().DisplayWin();
                StopCoroutine("TimeElapse");
                //a_GamePanel.gameObject.SetActive(false);
            }
        }        
    }
}
