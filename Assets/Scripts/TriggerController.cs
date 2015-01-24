using UnityEngine;
using System.Collections;

public class TriggerController : MonoBehaviour {

	private GameObject go;

	void OnTriggerEnter(Collider col){
		go = col.gameObject;
		Debug.Log ("enter");
	}

	void OnTriggerExit(Collider col){
		go = null;
		Debug.Log ("exit");
	}

	void Update(){
		if (go == null)
			return;
		if (Input.GetKeyUp (KeyCode.F)) {
			go.SendMessage ("ExecAction", SendMessageOptions.DontRequireReceiver);
		}
	}
}
