using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour {

	//private Vector3 origin = new Vector3(-30.4f,0.0f,0.0f); 
	/*public float width = 14.22f; 
	public float height = 0f; 
	private float X; 
	private float Y;*/

	public float scrollSpeed = 0.5f;
	// Use this for initialization
	void Start () {
		//origin = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 offset = new Vector2 (Time.time * scrollSpeed, 0);
		GetComponent<Renderer> ().material.mainTextureOffset = offset;
		/*Debug.Log (this.gameObject.transform.position);
		Debug.Log (this.gameObject.transform.position.x);
		if (this.gameObject.transform.position.x > 30.0f) {
			gameObject.transform.position = origin;
		}*/

	}

	void OnBecameInvisible()
	{
		/*Debug.Log ("became invisible");
		gameObject.transform.position = origin;*/
		//calculate current position
		//backPos = gameObject.transform.position;
		//calculate new position
		/*print (backPos);
		X = backPos.x + width*2;
		Y = backPos.y + height*2;*/
		//move to new position when invisible
		/*gameObject.transform.position = new Vector3 (X, Y, 0f);*/
	}
}
