using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	private float tempWait;
	private bool firedLaser = false;
	private bool stillFiring = true;
	public float maxLaserRotation;
	private float currentLaserRotation = 0f;
	private float bossRotationSpeed = 2.0f;
	//public Quaternion maxLaserRotation = new Quaternion(1,1,0,1);

	private BossActionType currentState = BossActionType.Moving;

	bool facingRight = true;
	float facingRightFloat = 1;
	public float bossHealth;

	public float maxBossSpeed = 1.0f;
	public float maxBossHealth = 100f;
	public float minBossHealth = 0f;

	bool start = true;// delete this later

	//public GameObject NormalBossFireball;
	public GameObject laserBreath;
	public List<Transform> BossPointsList = new List<Transform> ();
	public BossShootingController shootingCtrl;
	private int currentPoint = 0;

	Animator thisAnimator;
	//private Rigidbody2D rigidBody;
	private bool firstMovement = true;

	public enum BossActionType{
		Vulnerable,
		Moving,
		Fireball,
		LaserBeam,
		Dead
	}

	public enum BossPhaseType{
		Phase1,
		Phase2//no time for phase 2 :(
	}

	// Use this for initialization
	void Start () {
		//rigidBody = GetComponent<Rigidbody2D> ();
		thisAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log(1/Time.deltaTime);

		switch (currentState) {
		case BossActionType.Vulnerable:
			tempWait += Time.deltaTime;
			if (tempWait > 1) {
				currentState = BossActionType.Moving;
			}

			//HandleIdleState();
			break;

		case BossActionType.Moving:

			if (start == true) {
				thisAnimator.SetBool("Shooting",false);
				start = false;
			}

			if (transform.position != BossPointsList [currentPoint].position) {
				
				//Debug.Log ("Moving");
				//transform.Translate (Vector2.right * maxBossSpeed * Time.deltaTime);
				//transform.position = Vector3.Lerp(transform.position, BossPointsList [currentPoint].position, Time.deltaTime * maxBossSpeed);
				transform.position = Vector3.MoveTowards (transform.position, BossPointsList [currentPoint].position, Time.deltaTime * maxBossSpeed);
			} else {
				if(start == false){
					start = true;
				}
				switch (currentPoint) {
				case 0:
					currentPoint += 1;
					currentState = BossActionType.LaserBeam;
					tempWait = 0f;
					break;
				case 1:
					currentPoint += 1;
					currentState = BossActionType.LaserBeam;
					tempWait = 0f;
					break;
				case 2:
					currentPoint += 1;
					currentState = BossActionType.Fireball;
					break;

				case 3:
					currentPoint = 0;
					currentState = BossActionType.Fireball;
					break;

				}

				//forgive me coding gods #FlagsAreStupidButImRunningOutOfTime
				if (!firstMovement) {
					//Debug.Log ("should flip");
					flipObject ();
				} else {
					firstMovement = false;
				}

			}

			//HandleMovingState();
			break;

		case BossActionType.Fireball:
			// something to set it only once
			//thisAnimator.SetBool("Shooting",false);

			shootingCtrl.shootNormalFireballs (facingRight);
			currentState = BossActionType.Vulnerable;
			tempWait = 0f;

			break;
		case BossActionType.LaserBeam:
			if (!firedLaser) {
				thisAnimator.SetBool("Shooting",true);
				laserBreath.SetActive (true);
				firedLaser = true;
				stillFiring = true;
			}
			if (stillFiring) {
				//Debug.Log ("angle: " +  transform.eulerAngles.z + " < " + maxLaserRotation + " facing: " + facingRightFloat);
				if (Mathf.Abs(transform.eulerAngles.z) < maxLaserRotation || transform.eulerAngles.z > 360f - maxLaserRotation) {
					currentLaserRotation+= Time.deltaTime*bossRotationSpeed*facingRightFloat;// speed
					transform.rotation = Quaternion.Euler (new Vector3 (0, 0, currentLaserRotation*maxBossSpeed));
				} 
				else {
					stillFiring = !stillFiring;
					laserBreath.SetActive (false);
				}
			}
			else {
				//Debug.Log ("angle: " +  transform.eulerAngles.z + " > " + "1.0f" + " facing: " + facingRightFloat);
				//why does this still work after i had to change the other one because of euler doesnt go to minus????
				if (Mathf.Abs(transform.eulerAngles.z) > 1.0f) {
					currentLaserRotation -= Time.deltaTime*bossRotationSpeed*facingRightFloat;//speed + racing right for facing angle 
					transform.rotation = Quaternion.Euler (new Vector3 (0, 0, currentLaserRotation*maxBossSpeed));
				} else {
					transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 0));
					currentState = BossActionType.Moving;
					stillFiring = false;

					//reset for next call
					firedLaser = false;
					currentLaserRotation = 0;


				}

			}
			break;
		case BossActionType.Dead:
			transform.position = Vector3.MoveTowards (transform.position, transform.position+Vector3.up, Time.deltaTime);



			break;
		
		}
	}
	void flipObject(){
		facingRight = !facingRight;
		if (facingRightFloat == 1) {
			facingRightFloat = -1;
		} 
		else {
			facingRightFloat = 1;
		}
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	public void takeDamage(float amount){
		bossHealth = Mathf.Clamp (bossHealth-amount, minBossHealth, maxBossHealth);
		Debug.Log (bossHealth);
		if (bossHealth == minBossHealth) {
			Dead ();

			//Debug.Log ("boss is dead");
		}
	}
	void Dead(){
		thisAnimator.SetBool ("Dead", true);
		laserBreath.SetActive (false);
		currentState = BossActionType.Dead;
	}
	void OnTriggerEnter2D(Collider2D dragon) {
		/*if (dragon.gameObject.tag == "Dragon") {
			dragon.gameObject.GetComponent<DragonController> ().takeDamage (100f);
		} */
	}



}

