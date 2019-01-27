using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nazi : MonoBehaviour
{
    public  List<GameObject> HideOuts;
    private int suspition;
    private List<GameObject> toSearch;

    // Start is called before the first frame update
    void Start()
    {
        suspition = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer == FINI)
        {
            SearchCache();
            SearchJews();
        }
    }

    void SearchCache()
    {
        for (int i = 0; i < HideOuts.Count; i++)
        {
            int mustBeAdd = 0;
            GameObject actual = HideOuts[i];
            if (actual.GetComponent<HideOut>().isEmpty == false)
            {
                mustBeAdd = 1;
                suspition += Random.Range(0, 2) != 0 ? 0 : 5;
            }
            if (actual.GetComponent<HideOut>().letClue)
            {
                mustBeAdd = 1;
                suspition += Random.Range(0, 2) != 0 ? 0 : 15;
            }
            if (mustBeAdd == 1)
            {
                toSearch.Add(actual);
            }
        }
    }

    void    SearchjJews()
    {
        List<GameObject> newList = ShuffleList<GameObject>(toSearch);
        for (int i = 0; i < newList.Count; i++)
        {
            GameObject actual = newList[i];
            if (actual.GetComponent<HideOut>().isEmpty)
            {
                suspition -= 20;
            }
            else
            {

            }

            if (suspition <= 0)
            {
                break;
            }
        }
    }

    private List<E> ShuffleList<E>(List<E> inputList)
    {
        List<E> randomList = new List<E>();

        int randomIndex = 0;
        while (inputList.Count > 0)
        {
            randomIndex = Random.Range(0, inputList.Count); //Choose a random object in the list
            randomList.Add(inputList[randomIndex]); //add it to the new, random list
            inputList.RemoveAt(randomIndex); //remove to avoid duplicates
        }

        return randomList; //return the new random list
    }
}
