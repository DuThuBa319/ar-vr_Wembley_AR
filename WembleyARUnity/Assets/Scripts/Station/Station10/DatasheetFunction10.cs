using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasheetFunction10 : MonoBehaviour
{
    public GameObject contentMR0101, contentISE20AT01JA2, contentIR1020, datasheetUI;

    // Start is called before the first frame update
    void Start()
    {
        datasheetUI.SetActive(true);
        contentMR0101.SetActive(false);
        contentISE20AT01JA2.SetActive(false);
        contentIR1020.SetActive(false);
    }

    public void onValueChange(int value)
    {
        contentISE20AT01JA2.SetActive(false);
        contentMR0101.SetActive(false);
        switch (value)
        {
            case 1:
                contentMR0101.SetActive(true);
                break;
            case 2:
                contentISE20AT01JA2.SetActive(true);
                break;
            case 3:
                contentIR1020.SetActive(true);
                break;
            default: break;
        }
    }

}
