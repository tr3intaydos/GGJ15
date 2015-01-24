using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public string PowerUpName;

	void OnTriggerEnter(Collider col){
		Debug.Log (PowerUpName);
		if (col.tag == "Player"){
			col.GetComponent<CharacterPowerUps>().RegisterPowerUp(PowerUpName);
		}
	}
}