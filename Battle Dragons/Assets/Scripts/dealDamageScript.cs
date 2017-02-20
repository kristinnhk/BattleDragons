using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dealDamageScript : MonoBehaviour {

	public float damageAmount; //set in inspector

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D dragon) {
		if (dragon.gameObject.tag == "Dragon" && gameObject.tag == "BossProjectile") {
			dragon.gameObject.GetComponent<DragonController> ().takeDamage (damageAmount);
		} 
		else if (dragon.gameObject.tag == "Boss" && gameObject.tag == "PlayerProjectile") {
			dragon.gameObject.GetComponent<BossController> ().takeDamage (damageAmount);
		}
	}


}
