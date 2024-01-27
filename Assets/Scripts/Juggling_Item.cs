using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggling_Item : MonoBehaviour
{

    private float gravity = 0.0003f;
    private Vector3 acceleration = Vector3.zero;

    const int leftBound = -950;
    const int rightBound = 950;
    const int bottomBound = -50;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
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
