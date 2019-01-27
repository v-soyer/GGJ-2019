using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

	public bool TimerEnd = false;
	public float timeLeft = 90f;
     
    public Text time;
    public Image textbox;
    public Text text;

    private void Start()
    {
        textbox = GetComponentInChildren<Image>();
        text = textbox.GetComponentInChildren<Text>();

        time = GetComponentInChildren<Text>();
        time.text = "0.0";
    }
    // Update is called once per frame
    void Update () {
		LaunchBigTimer();
    }

	void LaunchBigTimer() {
		timeLeft -= Time.deltaTime;
        time.text = (int)Mathf.Round(timeLeft) / 60 + ":" + Mathf.Round(timeLeft) % 60;
		if ((int)timeLeft == 70)
        {
            textbox.gameObject.SetActive(true);
            text.text = "Info1";
        }
		if ((int)timeLeft == 40)
        {
            textbox.gameObject.SetActive(true);
            text.text = "Info2";
        }
		if ((int)timeLeft == 10)
        {
            textbox.gameObject.SetActive(true);
            text.text = "Info3";
        }
        if ((int)timeLeft == 0) {
    		TimerEnd = true;
        }
	}
}
