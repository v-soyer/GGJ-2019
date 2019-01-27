using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseClean : MonoBehaviour
{
    public Sprite CleanSprite;
    public Sprite DisorderSprite;
    public GameObject obj;
    public Button butt;

    // Start is called before the first frame update
    void Start()
    {
        butt.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.GetComponent<HideOut>().isDiscovered && obj.GetComponent<HideOut>().letClue)
        {
            butt.GetComponent<Image>().sprite = CleanSprite;
        }
        else
        {
            butt.GetComponent<Image>().sprite = DisorderSprite;
        }
    }

    void    TaskOnClick()
    {
        if (obj.GetComponent<HideOut>().letClue)
        {
            obj.GetComponent<HideOut>().letClue = false;
        }
        else
        {
            obj.GetComponent<HideOut>().letClue = true;
        }
    }
}
