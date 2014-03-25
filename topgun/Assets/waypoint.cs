using UnityEngine;
using System.Collections;

public class waypoint : MonoBehaviour
{
    private Vector3 newPosition;
    public Transform target;
    public float orbitDistance = 10.0f;
    public float orbitDegreesPerSec = 180.0f;


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
        Vector3 positionA = new Vector3(-1, 4, 90);
    
        if (newPosition != positionA)
            Debug.Log("Heading for Position A");
             newPosition = positionA;

        if (newPosition == positionA)
            Debug.Log("Reached Position A, Begining orbit");
            Orbitship();

        transform.position =
            Vector3.Lerp(transform.position, newPosition, Time.deltaTime / 10);
    }

    void Orbitship()
    {
        if (target != null)
        {
            // Keep plane Distance from target
            transform.position = target.position +
                (transform.position - target.position).normalized * orbitDistance;

            transform.RotateAround(target.position, Vector3.up,
                orbitDegreesPerSec * Time.deltaTime);
        }
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


