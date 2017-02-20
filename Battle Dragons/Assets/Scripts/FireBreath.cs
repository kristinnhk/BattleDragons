using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : MonoBehaviour {

	public float maxSpeed = 20.0f;
	private float lastThrowDate;
	public float DelayBetweenThrows = 0.5f;

	public Transform FireSpawn;
	public GameObject fireball;

	DragonController dragonControl;
	//Animator anim;


	// Use this for initialization
	void Start () {
		lastThrowDate = Time.time;
	}

	void Awake(){
		//anim = transform.root.gameObject.GetComponent<Animator> ();
		dragonControl = transform.root.GetComponent<DragonController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (Input.GetButton("Joy A") && (Time.time - lastThrowDate > DelayBetweenThrows) && dragonControl.canFireball()) {
			Debug.Log ("Joy AAAA is pressed");
			SpawnFireball ();

		}
	}


	void SpawnFireball(){
		// maybe if i have time?
		//anim.SetTrigger ("Shoot");
		if (dragonControl.facingRight) {
			GameObject newFireball = Instantiate (fireball, FireSpawn.position, Quaternion.Euler(new Vector3(0,0,0)));
			newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed,0);

		} else {
			GameObject newFireball = Instantiate (fireball, FireSpawn.position, Quaternion.Euler(new Vector3(0,0,180f)));
			newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed,0);

		}

		lastThrowDate = Time.time;
	}
}
