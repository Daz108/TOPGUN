using UnityEngine;
using System.Collections;

public class waypoint : MonoBehaviour
{
    private Vector3 newPosition;
    Vector3 lookDirection;
    float velocity = 20.0f;
    float turnSpeed = 10.0f;

    void Awake()
    {
        Debug.Log("Awake called.");
        newPosition = transform.position;
    }

    void Update()
    {
        Debug.Log("Update called.");
        PositionChanging();
    }

    void PositionChanging()
    {
        Debug.Log("PositionChanging called.");
        Vector3 positionA = new Vector3(-1, 4, 500);
        Vector3 positionB = new Vector3(-1, 8, 150);
        if (newPosition != positionA)
            Debug.Log("Heading for Vector A");
             newPosition = positionA;
             //transform.forward = positionA;
         if (newPosition == positionA)
             Debug.Log("Vector A Reached");
             lookDirection = positionB - transform.position;
            // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection.normalized), Time.time * turnSpeed);  
             newPosition = positionB;
             

        transform.position =
            Vector3.Lerp(transform.position, newPosition, Time.deltaTime );
    }

    void Yaw(float angle)
    {
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
        transform.rotation = rot * transform.rotation;
    }

    void Roll(float angle)
    {
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rot * transform.rotation;
    }

    void Pitch(float angle)
    {
        float invcosTheta1 = Vector3.Dot(transform.forward, Vector3.up);
        float threshold = 0.95f;
        if ((angle > 0 && invcosTheta1 < (-threshold)) || (angle < 0 && invcosTheta1 > (threshold)))
        {
            return;
        }

        // A pitch is a rotation around the right vector
        Quaternion rot = Quaternion.AngleAxis(angle, transform.right);

        transform.rotation = rot * transform.rotation;
    }
}


