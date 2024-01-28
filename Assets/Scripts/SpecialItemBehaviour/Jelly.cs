using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    //The chicken randomly flies to a direction every some time
    private Transform a_Transform;
    private Rigidbody2D a_RigidBody;

    void Start()
    {
        a_Transform = gameObject.transform;
        a_RigidBody = gameObject.GetComponent<Rigidbody2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("JellyBounce");
    }

    IEnumerator JellyBounce()
    {
        //This Debug shall be replaced with code that triggers the sound
        Debug.Log("Bounce!");
        a_Transform.localScale = new Vector3(1, 0.5f, 1);
        yield return new WaitForSeconds(1.0f);
        Debug.Log("BounceBack!");
        a_Transform.localScale = new Vector3(1, 1, 1);
    }
}
