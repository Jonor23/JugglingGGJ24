using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class All_Items : MonoBehaviour
{
    private List<Juggling_Item> itemList;
    public List<Juggling_Item> ItemList { get { return itemList; } set { itemList = value; } }

    private GameObject juggling_Pin_Blue;
    private GameObject juggling_Pin_Green;
    private GameObject juggling_Pin_Red;
    private GameObject juggling_Ball;
    private GameObject Bowing_Ball_1;
    private GameObject Bowing_Ball_2;
    private GameObject Bowing_Ball_3;


    public static All_Items Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        itemList = new List<Juggling_Item>();

        juggling_Pin_Blue = Resources.Load<GameObject>("Juggling_Pin_Blue");
        juggling_Pin_Green = Resources.Load<GameObject>("Juggling_Pin_Green");
        juggling_Pin_Red = Resources.Load<GameObject>("Juggling_Pin_Red");
        juggling_Ball = Resources.Load<GameObject>("Juggling_Ball");
        Bowing_Ball_1 = Resources.Load<GameObject>("Bowing_Ball_1");
        Bowing_Ball_2 = Resources.Load<GameObject>("Bowing_Ball_2");
        Bowing_Ball_3 = Resources.Load<GameObject>("Bowing_Ball_3");




        itemList.Add(new Juggling_Item("juggling_Pin_Blue", juggling_Pin_Blue, 0.0003f));
        itemList.Add(new Juggling_Item("juggling_Pin_Green", juggling_Pin_Green, 0.0003f));
        itemList.Add(new Juggling_Item("juggling_Pin_Red", juggling_Pin_Red, 0.0003f));
        itemList.Add(new Juggling_Item("Juggling_Ball", juggling_Ball, 0.00026f));
        itemList.Add(new Juggling_Item("Bowing_Ball_1", Bowing_Ball_1, 0.0005f));
        itemList.Add(new Juggling_Item("Bowing_Ball_2", Bowing_Ball_2, 0.0005f));
        itemList.Add(new Juggling_Item("Bowing_Ball_3", Bowing_Ball_3, 0.0005f));
    }

    public Juggling_Item FindItemByName(string name)
    {
        for(int i = 0; i < itemList.Count; i++)
        {            
            if(itemList[i].ItemName == name)
            {
                return itemList[i];
            }
        }
        return null;
    }
}
