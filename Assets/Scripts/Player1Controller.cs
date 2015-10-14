using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour
{
	public float Speed;
	public float Gravity;
	public float JumpStrenght;
	public int player = 1;

	private CharacterController motor { get; set; }

	// Use this for initialization
	void Start()
	{
		motor = GetComponent<CharacterController>() as CharacterController;
	}

	// Update is called once per frame
	void Update()
	{
		var direction = new Vector3(
				Input.GetAxis("Horizontal_Player" + player),
				0,
				Input.GetAxis("Vertical_Player" + player)
			);
		motor.Move(new Vector3(
				direction.x * Speed,
				0,
				direction.z * Speed) * Time.deltaTime
			);


		//Fall to the ground when in the air
		if (!motor.isGrounded)
		{
			motor.Move(new Vector3(0, -1*Gravity*Time.deltaTime, 0));
		}
	}
}
