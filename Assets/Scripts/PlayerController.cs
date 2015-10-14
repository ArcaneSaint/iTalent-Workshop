﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public float Speed;
	public float TurnSpeed;
	public float Gravity;
	public int player = 1;


    private CharacterController motor { get; set; }
	private Camera camera { get; set; }

    public GameObject pauseMenu;

	public float BulletSpeed;

	public GameObject bulletSpawnPoint;
	public GameObject Bullet;
	public float Cooldown;

	// Use this for initialization
	void Start()
	{
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        motor = GetComponent<CharacterController>() as CharacterController;

		camera = this.GetComponentInChildren<Camera>() as Camera;
		//camera = GetComponent<Camera>() as Camera;
	}

	void shoot()
	{
		var bullet = (GameObject)Instantiate(Bullet, bulletSpawnPoint.transform.position, camera.transform.rotation);
		//bullet.AddComponent<Rigidbody>();
		bullet.GetComponent<Rigidbody>().velocity = camera.transform.TransformDirection(Vector3.forward * BulletSpeed);
		
		
		
		//var projectile = new Rigidbody();
		
		//GameObject bullet = (GameObject)Instantiate(Resources.Load("Assets/Prefabs/Bullet.prefab"),transform.position,transform.rotation);
		//bullet.AddComponent<Rigidbody>();

		//(bullet.GetComponent<Rigidbody>() as Rigidbody).velocity = transform.TransformDirection(transform.forward * 20);
		
	}

   
	// Update is called once per frame
	void Update()
	{
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            togglePause();
        }

        if (Input.GetButtonDown("Fire1_Player"+player))
		{
			shoot();
		}

		var direction = (Input.GetAxis("Horizontal_Player" + player) * transform.right +
						Input.GetAxis("Vertical_Player" + player) * transform.forward).normalized;

		motor.Move(new Vector3(
				direction.x * Speed,
				0,
				direction.z * Speed) * Time.deltaTime
			);


		var rotateX = Input.GetAxis("Rotate_Vertical_Player" + player);
		var rotateY = Input.GetAxis("Rotate_Horizontal_Player" + player);

		this.transform.Rotate(0, rotateY * Time.deltaTime * TurnSpeed, 0);
		camera.transform.Rotate(rotateX * Time.deltaTime * TurnSpeed, 0, 0);

		//Fall to the ground when in the air
		if (!motor.isGrounded)
		{
			motor.Move(new Vector3(0, -1*Gravity*Time.deltaTime, 0));
		}


	}
     
      public void togglePause()
     {
         if(Time.timeScale == 0f)
         {
            Time.timeScale = 1f;
            Cursor.visible = false;
            pauseMenu.SetActive(false);
            
         }
         else
         {
            Time.timeScale = 0f;
            Cursor.visible = true;
            pauseMenu.SetActive(true);
            
         }
     }
}
