using UnityEngine;
using System.Collections;



	public class playerController : MonoBehaviour
	{
		
		float speed = 10.0f;
		
		
		// Use this for initialization
		void Start()
		{
			Screen.showCursor = false;
			Screen.lockCursor = true;
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
		
		// Update is called once per frame
		void Update()
		{
			float speed = this.speed;
			
			if (Input.GetKey(KeyCode.LeftShift))
			{
				speed *= 10.0f;
			}
			
			if (Input.GetKey(KeyCode.W))
			{
				transform.position -= gameObject.transform.forward * Time.deltaTime * speed;
				Pitch(Time.deltaTime * speed);
			}
			
			if (Input.GetKey(KeyCode.S))
			{
				transform.position += gameObject.transform.forward * Time.deltaTime * speed;
				Pitch(- Time.deltaTime * speed);
			}
			
			if (Input.GetKey(KeyCode.A))
			{
				transform.position -= gameObject.transform.right * Time.deltaTime * speed;
				Yaw(- Time.deltaTime * speed);
				Roll(+ Time.deltaTime * speed / 2);
			}
			
			if (Input.GetKey(KeyCode.D))
			{
				transform.position += gameObject.transform.right * Time.deltaTime * speed;
				Yaw(+ Time.deltaTime * speed);
				Roll(- Time.deltaTime * speed / 2);
			}
			
			if (Input.GetKey(KeyCode.Space))
			{
				
			}
	
		}
	}

