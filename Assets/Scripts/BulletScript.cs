using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public GameObject splatter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		//(other as GameObject)
		if (collision.contacts.Length > 0)
		{
			Debug.Log("Testing");
			ContactPoint point = collision.contacts[0];
			Instantiate(splatter);
			splatter.transform.position = point.point;
		}
		Destroy(gameObject);
	}

}
