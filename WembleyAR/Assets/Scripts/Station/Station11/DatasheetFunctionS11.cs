using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasheetFunctionS11 : MonoBehaviour
{
    public GameObject contentMK5343, datasheetUI;

    // Start is called before the first frame update
    void Start()
    {
        datasheetUI.SetActive(true);
        contentMK5343.SetActive(false);

    }

    public void onValueChange(int value)
    {
        contentMK5343.SetActive(false);

        switch (value)
        {
            case 1:
                contentMK5343.SetActive(true);
                break;

            default: break;
        }
    }

}
