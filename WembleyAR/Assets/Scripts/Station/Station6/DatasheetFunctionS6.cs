using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasheetFunctionS6 : MonoBehaviour
{
    public GameObject contentMR0101, contentMK5343, datasheetUI;

    // Start is called before the first frame update
    void Start()
    {
        datasheetUI.SetActive(true);
        contentMK5343.SetActive(false);
        contentMR0101.SetActive(false);

    }

    public void onValueChange(int value)
    {
        contentMK5343.SetActive(false);

        contentMR0101.SetActive(false);
        switch (value)
        {
            case 1:
                contentMK5343.SetActive(true);
                break;
            case 2:
                contentMR0101.SetActive(true);
                break;

            default: break;
        }
    }

}
