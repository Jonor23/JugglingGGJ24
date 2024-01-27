using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggling_Item : MonoBehaviour
{
    
    private string itemName;
    private float gravity = 1;
    private GameObject obj;

    public string ItemName { get { return itemName; }  set { itemName = value; } }
    public float Gravity { get { return gravity; } set { gravity = value; } }
    public GameObject Obj { get { return obj; } set { obj = value; } }

    const int leftBound = -50;
    const int rightBound = 1950;
    const int bottomBound = -50;
    const int topBound = 1150;

    // Start is called before the first frame update
    void Start()
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="gravity">0.0003f is a standard value</param>
    public Juggling_Item(string itemName, GameObject obj, float gravity)
    {
        this.itemName = itemName;
        this.obj = obj;
        this.gravity = gravity;
    }


    void Update()
    {
        if(transform.position.y <= bottomBound)
        {
            transform.position += Vector3.up * 1200;
        }
        if(transform.position.y >= topBound)
        {
            transform.position -= Vector3.up * 1200;
        }
        if(transform.position.x < leftBound)
        {
            transform.position = Vector3.right * rightBound;
        }
        if(transform.position.x > rightBound)
        {
            transform.position = Vector3.right * leftBound;
        }
    }
}
