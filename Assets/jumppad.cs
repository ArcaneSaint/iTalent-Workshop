using UnityEngine;
using System.Collections;


public class jumppad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter(Collider other){
	
		if (other is CharacterController) {

			CharacterController A = (CharacterController)other;
			

			A.Move(new Vector3(0,20,-10));
			print ("Collision by: "+other.GetType().ToString()+"  ... End of text");

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
