using UnityEngine;
using System.Collections;

public class retractwheels : MonoBehaviour {

    float speed = 10.0f;
    float epilson = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(epilson == 1.0f){
        epilson--;
        transform.position -= gameObject.transform.up * Time.deltaTime * epilson;
        }
        Pitch(Time.deltaTime * speed);
	}

    void Pitch(float angle)
    {
        float invcosTheta1 = Vector3.Dot(transform.forward, Vector3.up);
        float threshold = 0.45f;
        if ((angle > 0 && invcosTheta1 < (-threshold)) || (angle < 0 && invcosTheta1 > (threshold)))
        {
            return;
        }

        // A pitch is a rotation around the right vector
        Quaternion rot = Quaternion.AngleAxis(angle, transform.right);

        transform.rotation = rot * transform.rotation;
    }


   
}
