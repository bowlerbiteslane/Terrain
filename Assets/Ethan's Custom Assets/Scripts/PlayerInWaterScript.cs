using UnityEngine;
using System.Collections;

public class PlayerInWaterScript : MonoBehaviour {
	public float underwaterGravity;
	//Create reference for the scene's 'out-of-water' settings
	void Awake(){
		//Hold default underwater settings

	}
	
	
	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			//Change settings for when player is in the water
			Debug.Log ("Player Entered the Water.");
			CharacterMotor motor = other.GetComponent <CharacterMotor>();
			motor.movement.gravity *= .001f;
			motor.movement.velocity = new Vector3(motor.movement.velocity.x * 0.1f, motor.movement.velocity.y * 0.1f, motor.movement.velocity.z * 0.1f);
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player")) {
			//Change settings for when player is out of water
			Debug.Log ("Player Left the Water.");
			CharacterMotor motor = other.GetComponent <CharacterMotor>();
			motor.movement.gravity *= 1000f;
		}
	}
}
