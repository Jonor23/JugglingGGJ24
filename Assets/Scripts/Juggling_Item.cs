using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggling_Item : MonoBehaviour
{
    
    private string itemName;
    private float gravity;
    private GameObject obj;


    private Vector3 acceleration = Vector3.zero;

    public string ItemName { get { return itemName; }  set { itemName = value; } }
    public float Gravity { get { return gravity; } set { gravity = value; } }
    public GameObject Obj { get { return obj; } set { obj = value; } }

    const int leftBound = -950;
    const int rightBound = 950;
    const int bottomBound = -50;

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
        acceleration += Vector3.down * gravity;
        transform.position += acceleration;
        if (transform.position.x <= transform.parent.position.x + leftBound)
        {
            acceleration = new Vector3 (Mathf.Abs(acceleration.x), acceleration.y, acceleration.z);
        }
        if (transform.position.x >= transform.parent.position.x + rightBound)
        {
            acceleration = new Vector3 (-Mathf.Abs(acceleration.x), acceleration.y, acceleration.z);
        }
        if(transform.position.y <= bottomBound)
        {
            transform.position += Vector3.up * 1200;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 direction = transform.position - collision.transform.position;
        acceleration = direction * Time.deltaTime * 0.2f;
    }
}
