using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealChicken : MonoBehaviour
{
    //The chicken randomly flies to a direction every some time
    private Transform a_Transform;
    private Rigidbody2D a_RigidBody;
    
    void Start()
    {
        a_Transform = gameObject.transform;
        StartCoroutine("ChickFly");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ChickFly()
    {
        while(true)
        {
            yield return new WaitForSeconds(3.0f);
            Vector2 direction = new Vector2(0, 0);
            switch(Random.Range(0,4))
            {
                case 0:
                    direction = Vector2.up;
                    break;
                case 1:
                    direction = Vector2.down;
                    break;
                case 2:
                    direction = Vector2.left;
                    break;
                case 3:
                    direction = Vector2.right;
                    break;
            }
            a_RigidBody.velocity += direction * 5;
        }
    }
}
