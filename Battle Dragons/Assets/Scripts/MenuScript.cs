﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Joy A")) {
			SceneManager.LoadScene ("Main");

		}
	}

	public void LoadMainScene(){
		SceneManager.LoadScene ("Main");
	}
}
