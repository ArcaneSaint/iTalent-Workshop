using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float Speed;
	public float Gravity;
	public int player = 1;

	private CharacterController motor { get; set; }
	private Camera camera { get; set; }

	// Use this for initialization
	void Start()
	{
		motor = GetComponent<CharacterController>() as CharacterController;

		camera = this.GetComponentInChildren<Camera>() as Camera;
		
		//camera = GetComponent<Camera>() as Camera;
	}

	// Update is called once per frame
	void Update()
	{
		var direction = (Input.GetAxis("Horizontal_Player" + player) * transform.right +
						Input.GetAxis("Vertical_Player" + player) * transform.forward).normalized;

		motor.Move(new Vector3(
				direction.x * Speed,
				0,
				direction.z * Speed) * Time.deltaTime
			);


		var rotateX = Input.GetAxis("Rotate_Vertical_Player" + player);
		var rotateY = Input.GetAxis("Rotate_Horizontal_Player" + player);

		this.transform.Rotate(0, rotateY, 0);
		camera.transform.Rotate(rotateX, 0, 0);

		//Fall to the ground when in the air
		if (!motor.isGrounded)
		{
			motor.Move(new Vector3(0, -1*Gravity*Time.deltaTime, 0));
		}
	}
}
