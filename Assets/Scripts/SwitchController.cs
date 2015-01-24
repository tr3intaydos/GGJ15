using UnityEngine;
using System.Collections;

public class SwitchController : MonoBehaviour {

	public float timeForRestart = 5f;
	
	private GameObject[] gos;

	void Start(){
		gos = GameObject.FindGameObjectsWithTag ("Plataforms");
	}

	void ExecAction(){
		StopPlatforms();
	}

	void StartPlatforms(){
		Debug.Log ("stoping platforms");
		foreach (GameObject go in gos) {
			Animator a = go.GetComponent<Animator>();
			if(a!=null){
				a.StopPlayback();
			}
		}
	}

	void StopPlatforms(){
		foreach (GameObject go in gos) {
			Animator a = go.GetComponent<Animator>();
			if(a!=null){
				a.StartPlayback();
			}
		}
		Invoke ("StartPlatforms", timeForRestart);
	}
}