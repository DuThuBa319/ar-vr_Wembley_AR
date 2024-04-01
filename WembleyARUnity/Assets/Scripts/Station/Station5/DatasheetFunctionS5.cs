using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasheetFunctionS5 : MonoBehaviour
{
    public GameObject contentMK5343, contentDWAS603M8;
    
    // Start is called before the first frame update
    void Start()
    {
        contentMK5343.SetActive(false);
        contentDWAS603M8.SetActive(false);
    }

    public void onValueChange(int value)
    {
        contentMK5343.SetActive(false);
        contentDWAS603M8.SetActive(false);
        switch (value)
        {
            case 1:
                contentMK5343.SetActive(true);
                break;
          
            case 2:
                contentDWAS603M8.SetActive(true);
                break;
            default: break;
        }
    }

}
