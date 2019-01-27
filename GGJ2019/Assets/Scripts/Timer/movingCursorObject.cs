using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCursorObject : MonoBehaviour {
	float x, y, z = 0;
	int SpeedExposant = 150;
	int PowerBar_size = 100;
	bool right = true;
	bool Space = false;

	enum xColor {
		GREEN,
		ORANGE,
		RED
	};

    int Update()
    {
		float tmpX = 0;
		if (Input.GetKeyUp("space"))
			Space = true;
		if (!Space) {
			if (right) {
				tmpX = SpeedExposant*Time.deltaTime;
				x += tmpX;
				transform.position = new Vector3(transform.position.x + tmpX, transform.position.y, transform.position.z);
			} else {
				tmpX = -SpeedExposant*Time.deltaTime;
				x += tmpX;
				transform.position = new Vector3(transform.position.x + tmpX, transform.position.y, transform.position.z);
			}
			if (x >= PowerBar_size / 2)
				right = false;
			else if (x <= -PowerBar_size / 2)
				right = true;
		}
		return (int)x;
		//return chooseColor((int)x);
	}

	/*int chooseColor(int x)
	{
		xColor UIColor;

		if (x > -5 && x < 5) {
			UIColor = xColor.GREEN;
			Debug.Log("GREEN");
		 } else if ((x > -20 && x < -5) || (x > 5 && x < 20)) {
			UIColor = xColor.ORANGE;
			Debug.Log("ORANGE");
		} else if ((x > -50 && x < -20) || (x > 20 && x < 50)) {
			UIColor = xColor.RED;
			Debug.Log("RED");
		}
		return (int)UIColor;
	} */
}