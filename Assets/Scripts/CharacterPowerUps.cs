using UnityEngine;
using System.Collections;

public class CharacterPowerUps : MonoBehaviour {

	public void RegisterPowerUp(string powerUpName){
		if(powerUpName == "Rocket"){
			GetComponent<CharacterMovement>().canSecondJump = true;
		}
	}
}
