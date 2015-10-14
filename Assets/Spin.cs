using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
	public float speed = 10f;
		
		
		void Update ()
		{
		transform.Rotate(Vector3.right, speed * Time.deltaTime);
		transform.Rotate(Vector3.up, (float)( speed * 2f) * Time.deltaTime) ;
		}
	}