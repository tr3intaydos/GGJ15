using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public string PowerUpName;

	void OnTriggerEnter(Collider col){
		if (col.tag == "Player"){
			col.GetComponent<CharacterPowerUps>().RegisterPowerUp(PowerUpName);
		}
		Destroy (gameObject);
	}
}