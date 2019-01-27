using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Sticker
{
    public Sprite found;
    public Sprite disable;
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

    void removeJuif()
    {
        if (_init.all.juifs[_sticker.indexJuif].button.interactable == false && _sticker.hasJuif == true)
        {
            // change boolean values
            _sticker.canHide = true;
            _sticker.hasJuif = false;
            _init.all.juifs[_sticker.indexJuif].hide = false;
            _init.all.juifs[_sticker.indexJuif].select = false;

            // enable button juif
            _init.all.juifs[_sticker.indexJuif].button.interactable = true;

            // change sprites
            _init.all.juifs[_sticker.indexJuif].button.image.sprite = _init.all.juifs[_sticker.indexJuif].sprite;
            _sticker._button.image.sprite = _sticker.enable;
        }

    }

    void HideJuif()
    {

        // on button click hide juif
        for (int i = 0; i < _init.all.juifs.Count; i++)
        {
            if (_init.all.juifs[i].select == true && _sticker.hasJuif == false)
            {
                //launch jauge + timer (KEVIN)

                // change boolean values
                _sticker.canHide = false;
                _sticker.hasJuif = true;
                _init.all.juifs[i].select = false;
                _init.all.juifs[i].hide = true;

                // disable button juif
                _init.all.juifs[i].button.interactable = false;

                // change sprites
                _init.all.juifs[i].button.image.sprite = _init.all.juifs[i].onHide;
                _sticker._button.image.sprite = _init.all.juifs[i].sticker;

                // set index juif selected
                _sticker.indexJuif = i;
                return;
            }
        }

        // on button click remove juif
        removeJuif();

    }

    // Start is called before the first frame update
    void Start()
    {
        
        _init = GameManager.GetComponent<Init>();
        _sticker.select = false;
        _sticker.hasJuif = false;
        _sticker.fd = false;
        _sticker.canHide = true;
        _sticker.indexJuif = 0;
        _sticker._button.image.sprite = _sticker.enable;
        _sticker._button.onClick.AddListener(() => HideJuif());

    }

    // Update is called once per frame
    void Update()
    {


    }
}