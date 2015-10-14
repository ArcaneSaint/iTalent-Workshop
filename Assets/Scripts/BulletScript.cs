using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	//public GameObject splatter;
	//public GameObject splatter2;
	public GameObject Paint;
	public AudioClip ImpactSound;
	public int Deathcount = 5;
	private float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime >= Deathcount)
		{
			Destroy(gameObject);
		}
	}

	void OnDestroy()
	{
		AudioSource.PlayClipAtPoint(ImpactSound, transform.position);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			other.gameObject.gameObject.GetComponent<PlayerController>().Kill();
		}
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.contacts.Length > 0)
		{
			ContactPoint point = collision.contacts[0];

			var rot = Quaternion.FromToRotation(Vector3.up, point.normal);

			var p = Instantiate(Paint, point.point, rot);
		}
		 
		Destroy(gameObject);
	}

}
