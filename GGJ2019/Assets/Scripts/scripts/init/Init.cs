using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum type
{
    child,
    adult
};


[System.Serializable]
public class Juif
{

    public type _type;
    public string name;
    public Sprite sprite;
    public Sprite onSelect;
    public Sprite onHide;
    public Sprite onFound;
    public Sprite sticker;
    public Button button;
    public bool select;
    public bool hide;
    public bool found;
}

[System.Serializable]
public class characters
{
    public List<Juif> juifs;
}

public class Init : MonoBehaviour
{
    public characters all;

    public void selectJuif(int i)
    {
        if (all.juifs[i].select == false)
        {
            for (int nb = 0; nb < all.juifs.Count; nb++)
            {
                if (all.juifs[nb].select == true)
                {
                    all.juifs[nb].select = false;
                    all.juifs[nb].button.image.sprite = all.juifs[nb].sprite;
                }
            }
            all.juifs[i].select = true;
            all.juifs[i].button.image.sprite = all.juifs[i].onSelect;
        } else
        {
            all.juifs[i].select = false;
            all.juifs[i].button.image.sprite = all.juifs[i].sprite;
        }
    }

    public void CreateButton()
    {
        for (int i = 0; i < all.juifs.Count; i++)
        {
            if (i < 2) {
                all.juifs[i]._type = type.child;
                if (i%2 == 0)
                    all.juifs[i].name = "Marie";
                else
                    all.juifs[i].name = "Martin";
            } else {
                all.juifs[i]._type = type.adult;

                if (i % 2 == 0)
                    all.juifs[i].name = "Hélène";
                else
                    all.juifs[i].name = "Pierre";
            }
            all.juifs[i].onFound = all.juifs[i].onFound;
            all.juifs[i].sticker = all.juifs[i].sticker;
            all.juifs[i].button.gameObject.SetActive(true);
            all.juifs[i].button.image.sprite = all.juifs[i].sprite;
            all.juifs[i].select = false;

        }
        all.juifs[0].button.onClick.AddListener(() => selectJuif(0));
        all.juifs[1].button.onClick.AddListener(() => selectJuif(1));
        all.juifs[2].button.onClick.AddListener(() => selectJuif(2));
        all.juifs[3].button.onClick.AddListener(() => selectJuif(3));
    }

    void Start()
    {
        CreateButton();
    }
    
    void Update()
    {
        
    }
}
