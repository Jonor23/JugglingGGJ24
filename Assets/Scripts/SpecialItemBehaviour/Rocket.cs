using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{
    //The Rocket flies to the heading direction every some time
    private Transform a_Transform;
    private Rigidbody2D a_RigidBody;
    private Image fire;

    void Start()
    {
        a_Transform = gameObject.transform;
        a_RigidBody = gameObject.GetComponent<Rigidbody2D>();
        fire = a_Transform.Find("FireMode").GetComponent<Image>();
        fire.gameObject.SetActive(false);

        StartCoroutine("RocketFly");
    }

    IEnumerator RocketFly()
    {
        while (true)
        {            
            yield return new WaitForSeconds(5.0f);
            //This Debug shall be replaced with code that triggers the sound
            Debug.Log("Dash!");
            fire.gameObject.SetActive(true);
            Vector2 direction = new Vector2(0, 0);
            for(int i = 0; i < 50; i++)
            {
                direction = a_Transform.up;
                a_RigidBody.velocity += direction * 6;
                yield return new WaitForSeconds(0.1f);
            }
            
            fire.gameObject.SetActive(false);
        }
    }
}
