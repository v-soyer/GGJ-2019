using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsingButtonHide : MonoBehaviour
{
    public Image        toApply;
    public Sprite       Faked;
    public GameObject   obj;
    public Button        butt;

    // Start is called before the first frame update
    void Start()
    {
        butt.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void    TaskOnClick()
    {
        if (obj.GetComponent<HideOut>().letClue == false)
        {
            Debug.Log("CHIBRON");
            obj.GetComponent<HideOut>().letClue = (Random.Range(0, 2) != 0 ? true : false);
        }
        if (obj.GetComponent<HideOut>().isFake)
        {
            toApply.sprite = Faked;
            GetComponent<Button>().enabled = false;
            GetComponent<Image>().color = Color.grey;
        }
    }
}
