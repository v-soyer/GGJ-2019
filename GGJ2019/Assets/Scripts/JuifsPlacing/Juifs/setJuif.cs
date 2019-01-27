using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Sticker
{
    public Sprite enable;
    public Button _button;
    public string time;
    public bool select;
    public bool hasJuif;
    public bool fd;
    public bool canHide;
    public int indexJuif;

}


public class setJuif : MonoBehaviour
{
    public GameObject GameManager;
    public Sticker _sticker;
    public Init _init;

    void foundJuif()
    {

    }

    public void removeJuif(int indexJuif)
    {
        if (_init.all.juifs[indexJuif].button.interactable == false)
        {
            _init.all.juifs[indexJuif].hide = false;
            _init.all.juifs[indexJuif].select = false;

            // enable button juif
            _init.all.juifs[indexJuif].button.interactable = true;

            // change sprites
            _init.all.juifs[indexJuif].button.image.sprite = _init.all.juifs[indexJuif].sprite;
            _init.all.juifs[indexJuif].button.GetComponent<RectTransform>().sizeDelta = new Vector2(160.0f, 73.79f);

        }

    }

    public int HideJuif(Image to_apply)
    {
        
        // on button click hide juif
        for (int i = 0; i < _init.all.juifs.Count; i++)
        {
            if (_init.all.juifs[i].select == true )
            {
                //launch jauge + timer (KEVIN)

                _init.all.juifs[i].select = false;
                _init.all.juifs[i].hide = true;

                // disable button juif
                _init.all.juifs[i].button.interactable = false;

                // change sprites
                _init.all.juifs[i].button.image.sprite = _init.all.juifs[i].onHide;
                to_apply.sprite = _init.all.juifs[i].sticker;
                _init.all.juifs[i].button.GetComponent<RectTransform>().sizeDelta = new Vector2(160.0f, 73.79f);

                return (i);
            }
        }
        return (-1);
    }

    // Start is called before the first frame update
    void Start()
    {
        _init = GameManager.GetComponent<Init>();
    }

    // Update is called once per frame
    void Update()
    {


    }
}