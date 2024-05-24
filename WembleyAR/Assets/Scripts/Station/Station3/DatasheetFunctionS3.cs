using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasheetFunctionS3 : MonoBehaviour
{
    public GameObject contentMR0101, contentMK5343, contentDWAS603M8, datasheetUI, contentHolding;

    // Start is called before the first frame update
    void Start()
    {
        datasheetUI.SetActive(true);
        contentMK5343.SetActive(false);
        contentMR0101.SetActive(false);
        contentDWAS603M8.SetActive(false);
        contentHolding.SetActive(false);
    }

    public void onValueChange(int value)
    {
        contentMK5343.SetActive(false);
        contentDWAS603M8.SetActive(false);
        contentMR0101.SetActive(false);
        contentHolding.SetActive(false);
        switch (value)
        {
            case 3:
                contentMK5343.SetActive(true);
                break;
            case 2:
                contentMR0101.SetActive(true);
                break;
            case 1:
                contentDWAS603M8.SetActive(true);
                break;
            case 4:
                contentHolding.SetActive(true);
                break;
            default: break;
        }
    }

}
