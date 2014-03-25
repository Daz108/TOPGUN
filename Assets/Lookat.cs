using UnityEngine;
using System.Collections;

public class Lookat : MonoBehaviour {

	Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		target.position = Vector3 (0, 1, 0);
		if (Input.GetKey(KeyCode.Space))
		{
			transform.LookAt(target);	
		}

	}
}
