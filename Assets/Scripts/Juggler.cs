using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggler : MonoBehaviour
{

    const int speed = 250;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * Time.deltaTime * speed;
        }
    }
}
