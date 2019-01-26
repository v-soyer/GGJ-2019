using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHideOutWithCursor : MonoBehaviour
{
    RaycastHit hit = new RaycastHit();
    public Material highlightMaterial;
    Material originalMaterial;
    GameObject lastHighlightedObject = null;
    public List<Material> originalChildMaterial;
    private Canvas can;

    private void Start()
    {
        originalChildMaterial = new List<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            GameObject furniture = hit.collider.gameObject;
            if (furniture.tag == "isHideOut")
            {
                if (Input.GetMouseButton(0))
                {
                    if (furniture.GetComponent<HideOut>().isFake)
                    {
                        DisplayFakeMenu(furniture);
                    }
                    else
                    {
                        DisplayMenu(furniture);
                    }
                }
                //can = furniture.GetComponentInChildren<Canvas>();
                //can.enabled = true;
                if (furniture.GetComponent<MeshRenderer>())
                {
                    HighlightObject(furniture);
                }
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
            originalMaterial = gameObject.GetComponent<MeshRenderer>().material;
            if (gameObject.GetComponent<MeshRenderer>().materials.Length == 1)
                gameObject.GetComponent<MeshRenderer>().material = highlightMaterial;
            else
            {
                var materials = gameObject.GetComponent<MeshRenderer>().materials;

                var mats = new Material[materials.Length];
                for (int i = 0; i < materials.Length; i++)
                    mats[i] = highlightMaterial;
                for (int i = 0; i < materials.Length; i++)
                    originalChildMaterial.Add(materials[i]);
                gameObject.GetComponent<MeshRenderer>().materials = mats;
            }
            lastHighlightedObject = gameObject;
        }
    }

    void ClearHighlighted()
    {
        if (lastHighlightedObject != null)
        {
            if (lastHighlightedObject.GetComponent<MeshRenderer>().materials.Length == 1)
                lastHighlightedObject.GetComponent<MeshRenderer>().material = originalMaterial;
            else
            {
                var materials = lastHighlightedObject.GetComponent<MeshRenderer>().materials;
                var mats = new Material[materials.Length];
                for (int i = 0; i < materials.Length; i++)
                    mats[i] = originalChildMaterial[i];
                lastHighlightedObject.GetComponent<MeshRenderer>().materials = mats;
                originalChildMaterial.Clear();
            }
            lastHighlightedObject = null;
        }
    }

    void DisplayMenu(GameObject furniture)
    {
        int count = furniture.transform.childCount;

        for (int i = 0; i < count; i++)
        {
            Transform child = furniture.transform.GetChild(i);
            if (child.name == "HideOutMenu")
            {
                can = child.GetComponent<Canvas>();
                can.enabled = true;
            }
        }
    }

    void DisplayFakeMenu(GameObject furniture)
    {
        int count = furniture.transform.childCount;

        for (int i = 0; i < count; i++)
        {
            Transform child = furniture.transform.GetChild(i);
            if (child.name == "FakeHideOutMenu")
            {
                can = child.GetComponent<Canvas>();
                can.enabled = true;
            }
        }
    }
}
