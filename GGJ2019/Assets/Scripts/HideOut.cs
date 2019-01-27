using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOut : MonoBehaviour
{
    public bool isFake;
    public bool isEmpty;
    public bool isDiscovered;
    public bool letClue;
    public bool isForChild;
    public bool isForAdult;

    //public string time;
    // Start is called before the first frame update
    void Start()
    {
        isFake = (Random.Range(0, 2) != 0 ? true : false);
        isEmpty = true;
        isDiscovered = false;
        letClue = false;
        isForAdult = true;
        isForChild = true;

	}

// Update is called once per frame
void Update()
    {
        
    }
}
