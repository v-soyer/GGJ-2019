using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectHideOutWithCursor : MonoBehaviour
{
    RaycastHit hit = new RaycastHit();
    public Material highlightMaterial;
    public Material highlightMaterialWithClue;
    Material originalMaterial;
    GameObject lastHighlightedObject = null;
    public List<Material> originalChildMaterial;
    
    private Canvas can;
    private int nbFrames;

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
                    if (furniture.GetComponent<HideOut>().isDiscovered == true)
                    {
                        DisplayMenu(furniture);
                    }

                }
                if (furniture.GetComponent<MeshRenderer>())
                {
                    HighlightObject(furniture);
                }
                if (nbFrames > 60)
                {
                    furniture.GetComponent<HideOut>().isDiscovered = true;
                    can = furniture.GetComponentInChildren<Canvas>();
                    can.enabled = true;
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
        Material hlm = highlightMaterialWithClue;
        if (gameObject.GetComponent<HideOut>().letClue)
        {
            hlm = highlightMaterialWithClue;
        }
        else
        {
            hlm = highlightMaterial;
        }
        nbFrames += 1;
        if (lastHighlightedObject != gameObject)
        {
            ClearHighlighted();
            originalMaterial = gameObject.GetComponent<MeshRenderer>().material;
            if (gameObject.GetComponent<MeshRenderer>().materials.Length == 1)
                gameObject.GetComponent<MeshRenderer>().material = hlm;
            else
            {
                var materials = gameObject.GetComponent<MeshRenderer>().materials;

                var mats = new Material[materials.Length];
                for (int i = 0; i < materials.Length; i++)
                    mats[i] = hlm;
                for (int i = 0; i < materials.Length; i++)
                    originalChildMaterial.Add(materials[i]);
                gameObject.GetComponent<MeshRenderer>().materials = mats;
            }
            lastHighlightedObject = gameObject;
        }
    }

    void ClearHighlighted()
    {
        nbFrames = 0;
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
