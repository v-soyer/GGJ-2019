using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmallTimer : MonoBehaviour {

	public Text text;
	float timeLeft = 0;

	// Update is called once per frame
	void Update () {
		LaunchSmallTimer(10);
	}
	
	void LaunchSmallTimer(float x) {
		timeLeft = x;
		timeLeft -= Time.deltaTime;
        text.text = Mathf.Round(timeLeft)+ " ";
		if ((int)timeLeft < 0)
    		Debug.Log("CUL");
	}
}

