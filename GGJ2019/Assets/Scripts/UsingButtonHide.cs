using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsingButtonHide : MonoBehaviour
{
    public Image        toApply;
    public Sprite       Faked;
    public Sprite       original;
    public GameObject   obj;
    public Button        butt;
    public setJuif _set;
    public GameObject GameManager;
    private HideOut furniture;
    private int indexJuif;

    // Start is called before the first frame update
    void Start()
    {
        _set = GameManager.GetComponent<setJuif>();
        butt.GetComponent<Button>().onClick.AddListener(TaskOnClick);
        furniture = obj.GetComponent<HideOut>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void    TaskOnClick()
    {

        furniture.letClue = (Random.Range(0, 2) != 0 ? true : false);
        if (furniture.isFake)
        {
            toApply.sprite = Faked;
            GetComponent<Button>().enabled = false;
            GetComponent<Image>().color = Color.grey;
        } else
        {
            if (furniture.isEmpty == true)
            {
                indexJuif = _set.HideJuif(toApply);
                Debug.Log(indexJuif);
                if (indexJuif != -1)
                    furniture.isEmpty = false;
            } else
            {
                toApply.sprite = original;
                _set.removeJuif(indexJuif);
                furniture.isEmpty = true;
            }
                
        }
    }
}
