using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DragonController : MonoBehaviour {


	//Constants
	public float fireballEnergyCost = 10f;
	public float maxDragonHealth = 100f;
	public float minDragonHealth = 0f;
	public float maxDragonEnergy = 100f;
	public float minDragonEnergy = 0f;
	public float maxSpeed = 10.0f;
	public float maxFlySpeed = 5.0f;
	public float energyRegenRate = 0.4f;

	public float dragonHealth;
	public float dragonEnergy;

	private bool invincible = false;


	public bool facingRight = true;
	Animator thisAnimator;
	private Rigidbody2D rigidBody;




	// Use this for initialization
	void Start () {
		foreach(String cont in Input.GetJoystickNames()){
			Debug.Log(cont);
		}
		Debug.Log ("empty??");


		//Initialization
		rigidBody = GetComponent<Rigidbody2D> ();
		thisAnimator = GetComponent<Animator> ();
		dragonHealth = maxDragonHealth;
		dragonEnergy = maxDragonEnergy;



		if (rigidBody == null)
			Debug.Log ("rigidbody is null");

		if (thisAnimator == null)
			Debug.Log ("Animator is null");
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		//
		regenerateEnergy();



		float movement = Input.GetAxis ("nesHorizontal");
		//vertical movement
		float Vmovement = Input.GetAxis ("nesVertical");
		//Debug.Log (Vmovement);

		//check is pressing down?

			
		thisAnimator.SetFloat("Speed",Math.Abs(movement)+Math.Abs(Vmovement));
		if (Vmovement == 0) {
			rigidBody.velocity = new Vector2 (movement * maxSpeed, -maxFlySpeed);
		} 
		else if (Vmovement == -1){
			rigidBody.velocity = new Vector2 (movement * maxSpeed, Vmovement*maxSpeed);

		}
		else{
			rigidBody.velocity = new Vector2 (movement * maxSpeed, Vmovement*maxFlySpeed);

		}


		if (movement > 0 && (!facingRight)) {
			flipObject ();
		}
		else if (movement < 0 && facingRight) {
			flipObject ();
		
		}

		if (Input.GetAxis ("nesVertical") != 0) {
			Debug.Log ("nes vertical: " + Input.GetAxis ("nesVertical"));
		}

		/*if (Input.GetButton("Joy A") && Time.time - lastThrowDate > DelayBetweenThrows) {
			Debug.Log ("Joy AAAA is pressed");
			SpawnFireball ();

			//IS NOW IN FIREBREATH.CS
		}*/

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

	public bool canFireball(){
		if (dragonEnergy >= fireballEnergyCost) {
			dragonEnergy -= fireballEnergyCost;
			return true;
		}
		//else if (dragonEnergy < fireballEnergyCost) 
		return false;

	}
	public void regenerateEnergy(){
		if (dragonEnergy < maxDragonEnergy) {
			dragonEnergy = Mathf.Clamp (dragonEnergy + energyRegenRate * 1, minDragonEnergy, maxDragonEnergy);
		}
	}

	public void takeDamage(float amount){
		if (!invincible) {
			dragonHealth = Mathf.Clamp (dragonHealth - amount, minDragonHealth, maxDragonHealth);
			if (dragonHealth == minDragonHealth) {
				Debug.Log ("dragon is dead");
			}
			invincible = true;
			Invoke ("invincibilityFrames", 3);
			//Create invincibility display
		}
	}
	private void invincibilityFrames(){
		invincible = false;
	}

}
