using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideOut : MonoBehaviour
{
    public bool isFake;
    public bool isEmpty;

    // Start is called before the first frame update
    void Start()
    {
        isFake = (Random.Range(0, 2) != 0 ? true : false);
        isEmpty = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
