using UnityEngine;
using System.Collections;

public class MovingShip : MonoBehaviour {

    private Vector3 newPosition;

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
            Debug.Log("Heading for Vector A");
             newPosition = positionA;

        transform.position =
            Vector3.Lerp(transform.position, newPosition, Time.deltaTime / 100);
    }
}


