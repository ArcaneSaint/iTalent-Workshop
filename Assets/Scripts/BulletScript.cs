using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public GameObject splatter;
	public GameObject splatter2;
	//public Material Paint;
	public GameObject Paint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.contacts.Length > 0)
		{
			ContactPoint point = collision.contacts[0];
			//Instantiate(splatter);
			//splatter.transform.position = point.point;

			var rot = Quaternion.FromToRotation(Vector3.up, point.normal);

			//gameObject.AddComponent<Projector>();
			Instantiate(Paint,point.point+1*(transform.up),rot);
			//p.material = Paint;
			

			//var x = Instantiate(splatter2, point.point, rot);
			/*var contact = col.contacts[0]; // get the first contact point info // find the necessary rotation... var rot = Quaternion.FromToRotation(Vector3.up, contact.normal); Instantiate(bloodPrefab, contact.point, rot); // and make the enemy bleed } Destroy(gameObject); // destroy the projectile }*/
		}
		Destroy(gameObject);
	}

}
