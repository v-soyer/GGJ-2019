using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detectCursor : MonoBehaviour {
    RaycastHit hit = new RaycastHit();
    public Material highlightMaterial;
    Material originalMaterial;
    GameObject lastHighlightedObject = null;
    private Canvas can;

    // Update is called once per frame
    void Update () {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            GameObject furniture = hit.collider.gameObject;
            if (furniture.tag == "isHideOut")
            {
                if (Input.GetMouseButton(0))
                {
                    DisplayMenu(furniture);
                }
                can = furniture.GetComponentInChildren<Canvas>();
                can.enabled = true;
                HighlightObject(furniture);
            }
            else
            {
                ClearHighlighted();
            }
        }
        else
        {
            ClearHighlighted();
        }
    }

    void HighlightObject(GameObject gameObject)
    {
        if (lastHighlightedObject != gameObject)
        {
            ClearHighlighted();
            originalMaterial = gameObject.GetComponent<MeshRenderer>().sharedMaterial;
            gameObject.GetComponent<MeshRenderer>().sharedMaterial = highlightMaterial;
            lastHighlightedObject = gameObject;
        }

    }

    void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            lastHighlightedObject.GetComponent<MeshRenderer>().sharedMaterial = originalMaterial;
            lastHighlightedObject = null;
        }
    }

    void    DisplayMenu(GameObject furniture)
    {
        int count = furniture.transform.childCount;

        for (int i = 0; i < count; i++)
        {
            Transform child = furniture.transform.GetChild(i);
            Debug.Log(child.name);
            if (child.name == "HideOutMenu")
            {
                can = child.GetComponent<Canvas>();
                can.enabled = true;
            }
        }
    }
}
