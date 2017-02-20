using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBarController : MonoBehaviour {

	public float lerpSpeed = 2f;
	[SerializeField]
	private DragonController dragoncontrol;
	[SerializeField]
	private Image bar;

	private const float fillMin = 0f;
	private const float fillMax = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float convertedAmount = fillAmountConvert (dragoncontrol.dragonEnergy, dragoncontrol.minDragonEnergy, dragoncontrol.maxDragonEnergy);

		bar.fillAmount = Mathf.Lerp (bar.fillAmount, convertedAmount, Time.deltaTime * lerpSpeed);
		//bar.fillAmount = test;
	}

	void FixedUpdate(){
	}

	private float fillAmountConvert(float value,float valueMin,float valueMax, float min=fillMin, float max=fillMax){
		return (value - min) * (max - min) / (valueMax - valueMin) + min;
	}
}
