using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		foreach(String cont in Input.GetJoystickNames()){
			Debug.Log(cont);
		}
		Debug.Log ("empty??");
	}
	
	// Update is called once per frame
	void Update () {
		//float h = Input.GetAxis ("Horizontal");
		//Debug.Log (h);
		//if(Input.GetButton(
		if (Input.GetAxis ("Horizontal") != 0) {
			Debug.Log (Input.GetAxis ("Horizontal"));
		}
		if (Input.GetAxis ("Vertical") != 0) {
			Debug.Log (Input.GetAxis ("Vertical"));
		}
		if (Input.GetAxis ("nesHorizontal") != 0) {
			Debug.Log ("nes horizontal: " + Input.GetAxis ("nesHorizontal"));
		}
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
}
