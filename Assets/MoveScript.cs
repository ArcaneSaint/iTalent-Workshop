using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour
{
	public float speed = 10.0f;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		this.transform.position = this.transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
	}
}
