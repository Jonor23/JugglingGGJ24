using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juggler : MonoBehaviour
{

    private const int speed = 250;
    private const float armSpan = 160f;

    private Transform LeftArmBase;
    private Transform LeftArmEnd;
    private Transform LeftHand;
    private Transform RightArmBase;
    private Transform RightArmEnd;
    private Transform RightHand;


    // Start is called before the first frame update
    void Start()
    {
        LeftArmBase = transform.Find("Left Arm Base");
        LeftArmEnd = LeftArmBase.Find("Left Arm End");
        LeftHand = LeftArmEnd.Find("Left Hand");
        RightArmBase = transform.Find("Right Arm Base");
        RightArmEnd = RightArmBase.Find("Right Arm End");
        RightHand = RightArmEnd.Find("Right Hand");
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
        if(Input.GetKey(KeyCode.Mouse0))
        {
            HandMovement(LeftArmBase, LeftArmEnd, LeftHand, 1);
        }
        if(Input.GetKey(KeyCode.Mouse1))
        {
            HandMovement(RightArmBase, RightArmEnd, RightHand, -1);
        }
    }


    void HandMovement(Transform Base, Transform End, Transform Hand, int direction)
    {
        Vector2 relativePositionToPivot = Input.mousePosition - Base.position;
        float lengthFromPivot = Mathf.Sqrt((relativePositionToPivot.x * relativePositionToPivot.x) + (relativePositionToPivot.y * relativePositionToPivot.y));
        if (lengthFromPivot > 160f)
        {
            lengthFromPivot = 160f;
        }
        float armEndRotation = Mathf.Rad2Deg * Mathf.Asin(lengthFromPivot / armSpan);
        armEndRotation = 180 - (armEndRotation * 2);

        float armBaseRotation = Mathf.Rad2Deg * Mathf.Atan(relativePositionToPivot.y / relativePositionToPivot.x);
        if (relativePositionToPivot.x * direction > 0)
        {
            armBaseRotation += 180;
        }

        armBaseRotation -= (180 - armEndRotation * direction) * 0.5f - 90;

        End.rotation = Quaternion.Euler(0, 0, armBaseRotation - armEndRotation * direction);
        Base.rotation = Quaternion.Euler(0, 0, armBaseRotation);
        Hand.rotation = Quaternion.Euler(0, 0, 0);
    }
}
