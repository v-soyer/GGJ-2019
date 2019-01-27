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
    public GameObject GameManager;
    public Init _init;

    private void Start()
    {
        time.text = "0.0";
        _init = GameManager.GetComponent<Init>();

    }
    // Update is called once per frame
    void Update () {
		LaunchBigTimer();
    }

	void LaunchBigTimer() {

        if ((int)timeLeft == 90)
        {
            textbox.gameObject.SetActive(true);
            text.text = "The hunter... Is hungry";
        }
        if ((int)timeLeft == 85)
        {
            textbox.gameObject.SetActive(false);
        }
        timeLeft -= Time.deltaTime;
        time.text = "0" +(int)Mathf.Round(timeLeft) / 60 + ":" + Mathf.Round(timeLeft) % 60;

        if ((int)timeLeft == 70)
        {
            text.text = "Put the bird's cage closer to the ground, they seem to be happier";
            textbox.gameObject.SetActive(true);
        }
        if ((int)timeLeft == 65)
        {
            textbox.gameObject.SetActive(false);
        }
        if ((int)timeLeft == 40)
        {
            textbox.gameObject.SetActive(true);

            text.text = "Survey proves that bed are the worst item of the year!";
        }
        if ((int)timeLeft == 35)
        {
            textbox.gameObject.SetActive(false);
        }
        if ((int)timeLeft == 10)
        {
            textbox.gameObject.SetActive(true);
            text.text = "In comparison, the same survey proves that armor are a lot more reliable";
        }
        if ((int)timeLeft == 5)
        {
            textbox.gameObject.SetActive(false);
        }
        if ((int)timeLeft <= 0) {
    		TimerEnd = true;
            time.text = "00.00";
            stopAll();
        }
	}

    public void stopAll()
    {
        for (int i = 0; i < 4; i++)
        {
            _init.all.juifs[i].button.interactable = false;
        }
    }
}
