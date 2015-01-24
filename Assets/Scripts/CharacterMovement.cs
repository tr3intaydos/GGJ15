using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {
	public float speed;
	public float rotationSpeed;
	public float jumpHeight;
	public float maxVelocityChange;
	public bool grounded;
	public GameObject cam;

	public bool canSecondJump;

	private int jumpCounter = 0;

	void Start(){
		if(cam == null)
			cam = Camera.main.gameObject;
	}
	
	void FixedUpdate () {
		if (grounded) {

			Vector3 rotation = new Vector3(0,Input.GetAxis("Horizontal"),0);
			rotation *= rotationSpeed;
			transform.Rotate(rotation);

			Vector3 targetVelocity = new Vector3(0, 0, Input.GetAxis("Vertical"));
			//targetVelocity = cam.transform.TransformDirection(targetVelocity);
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= speed;
			var v = rigidbody.velocity;
			var velocityChange = (targetVelocity-v);
			velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
			velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
			velocityChange.y = 0;
			
			rigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
		}
		if(Input.GetButtonDown("Jump") && grounded){
			rigidbody.AddForce(transform.up*jumpHeight);
			if(canSecondJump){
				grounded=false;
			}

			jumpCounter++;
			if(jumpCounter >= 2){
				canSecondJump = false;
				jumpCounter = 0;
			}
		}
		if(!canSecondJump){
			grounded=false;
		}
	}
	
	void OnCollisionStay(Collision collision) {
		if (collision.transform.tag != "Not Ground"){
			grounded=true;
		}
	}
}