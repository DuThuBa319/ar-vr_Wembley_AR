using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasheetFunctionS2 : MonoBehaviour
{
    public GameObject contentMR0101, contentPZG101P, datasheetUI;

    // Start is called before the first frame update
    void Start()
    {
        datasheetUI.SetActive(true);
        contentMR0101.SetActive(false);
        contentPZG101P.SetActive(false);
    }

    public void onValueChange(int value)
    {

        contentPZG101P.SetActive(false);
        contentMR0101.SetActive(false);
        switch (value)
        {

            case 1:
                contentMR0101.SetActive(true);
                break;
            case 2:
                contentPZG101P.SetActive(true);
                break;
            default: break;
        }
    }

}
