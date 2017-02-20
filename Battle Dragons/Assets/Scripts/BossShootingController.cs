using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShootingController : MonoBehaviour {

	public float maxSpeed = 10.0f;
	public GameObject NormalBossFireball;

	public Transform offScreenPool;

	public List<GameObject> normalFireballPool = new List<GameObject>();

	// Use this for initialization
	void Start () {
		instantiateNormalFireballs ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void shootNormalFireballs(bool facingRight){
		Quaternion quat;
		float xVelocity;
		int yVelocity = -3;
		if (!facingRight) {
			quat = Quaternion.Euler (new Vector3 (0, 0, 0));
			xVelocity = maxSpeed;
		} else {
			quat = Quaternion.Euler (new Vector3 (0, 0, 180f));
			xVelocity = -maxSpeed;
		}
		foreach (GameObject fireball in normalFireballPool) {
			fireball.transform.position = transform.position;
			fireball.transform.rotation = quat;
			yVelocity += 3;
			fireball.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xVelocity, yVelocity);
			fireball.SetActive (true);
		}
			//quat = new Quaternion.Euler (new Vector3 (0, 0, 0));
		/*if(!facingRight) {
			GameObject newFireball = Instantiate (NormalBossFireball,transform.position , Quaternion.Euler(new Vector3(0,0,0)));
			newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed,1);
			newFireball = Instantiate (NormalBossFireball,transform.position , Quaternion.Euler(new Vector3(0,0,0)));
			newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed,0);
			newFireball = Instantiate (NormalBossFireball,transform.position , Quaternion.Euler(new Vector3(0,0,0)));
			newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed,-1);

		} else {
			GameObject newFireball = Instantiate (NormalBossFireball, transform.position, Quaternion.Euler(new Vector3(0,0,180f)));
			newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed,1);
			newFireball = Instantiate (NormalBossFireball, transform.position, Quaternion.Euler(new Vector3(0,0,180f)));
			newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed,0);
			newFireball = Instantiate (NormalBossFireball, transform.position, Quaternion.Euler(new Vector3(0,0,180f)));
			newFireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed,-1);

		}*/

	}
	void instantiateNormalFireballs(){
		normalFireballPool.Add (Instantiate (NormalBossFireball,offScreenPool.position,Quaternion.Euler(new Vector3(0,0,0))));
		normalFireballPool.Add (Instantiate (NormalBossFireball,offScreenPool.position,Quaternion.Euler(new Vector3(0,0,0))));
		normalFireballPool.Add (Instantiate (NormalBossFireball,offScreenPool.position,Quaternion.Euler(new Vector3(0,0,0))));
		foreach (GameObject fireball in normalFireballPool) {
			//fireball.SetActive (false);
		}
	}

	/*public void shootNormalFireballs(bool facingRight){

	}*/




}
