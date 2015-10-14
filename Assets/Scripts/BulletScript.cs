using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	//public GameObject splatter;
	//public GameObject splatter2;
	public GameObject Paint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/*
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			//PlayerController pc = other.gameObject as PlayerController;
			//pc.Kill();
		}
	}*/

	void OnCollisionEnter(Collision collision)
	{
		/*if (collision.contacts.Length > 0)
		{
			ContactPoint point = collision.contacts[0];

			var rot = Quaternion.FromToRotation(Vector3.up, point.normal);

			var p = Instantiate(Paint, point.point, rot);
			
		}*/
		 
		Destroy(gameObject);
	}

}
