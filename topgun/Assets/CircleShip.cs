using UnityEngine;
using System.Collections;

public class CircleShip : MonoBehaviour {



    private Vector3 newPosition;
    public Transform target;
    public float orbitDistance = 50.0f;
    public float orbitDegreesPerSec = 70.0f;

    // Use this for initialization
    void Awake()
    {
        Debug.Log("Awake called.");
        newPosition = transform.position;
    }

    void Update()
    {
        Debug.Log("Update called.");
       // PositionChanging();
        Circlearoundship();
    }

    //void PositionChanging()
    //{
    //  //  Debug.Log("PositionChanging called.");
    //    Vector3 positionA = new Vector3(-1, 2, 45);

    //    if (newPosition != positionA)
    //        Debug.Log("Heading for Position A");
    //    newPosition = positionA;

    //    if (newPosition == positionA)
    //        Debug.Log("Reached Position A, Begining orbit");
    //        

    //    transform.position =
    //        Vector3.Lerp(transform.position, newPosition, Time.deltaTime / 5);
    //}


    void Circlearoundship()
    {
        if (target != null)
        {

            // Keep plane Distance from target
            transform.position = target.position + 
                (transform.position - target.position).normalized * orbitDistance;
           transform.forward = target.position +
                (transform.position - target.position).normalized * orbitDistance;
            transform.RotateAround(target.position, Vector3.up,
                orbitDegreesPerSec * Time.deltaTime);
        }
    }

    
}
