
using UnityEngine;
using System.Collections;

public class SteeringBehaviours : MonoBehaviour
{
	

			// Use this for initialization
			void Start()
			{
				
			}
			
			// Update is called once per frame
			void Update()
			{
				Vector3 dest = new Vector3(0, 0, 34);
				Vector3 toDest = dest - transform.position;
				if (toDest.magnitude > 0.1f)
				{
					toDest.Normalize();
					float speed = 5.0f;
					transform.position += toDest * speed * Time.deltaTime;
					transform.forward = toDest;
				}

				
			}
		}
	