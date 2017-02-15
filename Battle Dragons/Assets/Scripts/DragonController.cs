using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour {

	public float maxSpeed = 10.0f;
	private bool facingRight = true;
	Animator thisAnimator;
	private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		foreach(String cont in Input.GetJoystickNames()){
			Debug.Log(cont);
		}
		Debug.Log ("empty??");

		rigidBody = GetComponent<Rigidbody2D> ();
		thisAnimator = GetComponent<Animator> ();
		if (rigidBody == null)
			Debug.Log ("rigidbody is null");

		if (thisAnimator == null)
			Debug.Log ("Animator is null");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//float h = Input.GetAxis ("Horizontal");
		//Debug.Log (h);
		//if(Input.GetButton(
		/*if (Input.GetAxis ("Horizontal") != 0) {
			Debug.Log (Input.GetAxis ("Horizontal"));
		}
		if (Input.GetAxis ("Vertical") != 0) {
			Debug.Log (Input.GetAxis ("Vertical"));
		}*/

		//if (Input.GetAxis ("nesHorizontal") != 0) {
			Debug.Log ("nes horizontal: " + Input.GetAxis ("nesHorizontal"));
			float movement = Input.GetAxis ("nesHorizontal");

			thisAnimator.SetFloat("Speed",Math.Abs(movement));

			rigidBody.velocity = new Vector2 (movement * maxSpeed, rigidBody.velocity.y);
			if (movement > 0 && (!facingRight)) {
				flipObject ();
				
			}
			else if (movement < 0 && facingRight) {
				flipObject ();

			}
		//}
		if (Input.GetAxis ("nesVertical") != 0) {
			Debug.Log ("nes vertical: " + Input.GetAxis ("nesVertical"));
		}

		if (Input.GetButton("Joy A")) {
			Debug.Log ("Joy AAAA is pressed");
		}
		if (Input.GetButton("Joy B")) {
			Debug.Log ("Joy BBB is pressed");
		}

		if (Input.GetButton("Select")) {
			Debug.Log ("Joy select is pressed");
		}
		if (Input.GetButton("Start")) {
			Debug.Log ("Joy start is pressed");
		}
	}

	void flipObject(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
