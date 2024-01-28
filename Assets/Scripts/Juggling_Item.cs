using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggling_Item : MonoBehaviour
{

    [SerializeField]
    private AK.Wwise.Event sound = null;

    private string itemName;
    [SerializeField]
    private float mass;
    private GameObject obj;

    public string ItemName { get { return itemName; }  set { itemName = value; } }
    public float Mass { get { return mass; } set { mass = value; } }
    public GameObject Obj { get { return obj; } set { obj = value; } }

    private Transform a_Transform;
    private Rigidbody2D a_RigidBody;

    const int leftBound = -50;
    const int rightBound = 1830;
    const int bottomBound = -50;
    const int topBound = 1150;

    // Start is called before the first frame update
    void Start()
    {
        a_Transform = gameObject.transform;
        a_RigidBody = gameObject.GetComponent<Rigidbody2D>();
        a_RigidBody.gravityScale = 1;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="mass">1 is a standard value</param>
    public Juggling_Item(string itemName, GameObject obj, float mass)
    {
        this.itemName = itemName;
        this.obj = obj;
        this.mass = mass;
    }


    void Update()
    {
        a_RigidBody.mass = mass;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 direction = transform.position - collision.transform.position;
        //a_RigidBody.AddForce(direction * Time.deltaTime * 2000);
        a_RigidBody.velocity = direction * Time.deltaTime * 50;
        sound.Post(this.gameObject);
        if (collision.tag == "Player")
        {
            a_Transform.parent.parent.Find("GameUI").GetComponent<GameUI>().AddScore(0.01f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        sound.Post(this.gameObject);
    }
}
