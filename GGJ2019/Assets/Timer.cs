using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

	bool TimerEnd = false;
	float timeLeft = 90f;
     
     public Text text;
     
	// Update is called once per frame
	void Update () {
		LaunchBigTimer();
    }

	void LaunchBigTimer() {
		timeLeft -= Time.deltaTime;
        text.text = (int)Mathf.Round(timeLeft) / 60 + ":" + Mathf.Round(timeLeft) % 60;
		if ((int)timeLeft == 70)
			Debug.Log("info 1");
		if ((int)timeLeft == 40)
			Debug.Log("info 2");
		if ((int)timeLeft == 10)
			Debug.Log("info 3");
        if ((int)timeLeft == 0) {
    		TimerEnd = true;
        }
	}
}
