using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float speed;
	public float jumpHeight;
	public float maxVelocityChange;
	public bool grounded;
	public GameObject cam;

	
	void FixedUpdate () {
		if (grounded) {
			Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			targetVelocity = cam.transform.TransformDirection(targetVelocity);
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
			grounded=false;
		}
	}
	
	void OnCollisionStay(Collision collision) {
		if (collision.transform.tag != "Not Ground"){
			grounded=true;
		}
	}
}