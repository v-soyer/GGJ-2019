using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeHideOut : MonoBehaviour
{
    public List<GameObject> HideOuts;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < HideOuts.Count; i++)
        {
            GameObject actual = HideOuts[i];
            if (actual.name == "Malle")
            {
                actual.GetComponent<HideOut>().isForAdult = false;
                actual.GetComponent<HideOut>().isForChild = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
