using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavFromSheetToWireS5 : MonoBehaviour
{
    public GameObject  wiringMK5343, wiringDWAS603M8;
    public GameObject currentSheet;

    // Start is called before the first frame update
    void Start()
    {   currentSheet.SetActive(true);
        wiringMK5343.SetActive(false);
        wiringDWAS603M8.SetActive(false);
    }
 
    public void navigateToWiringMK5343()
    {
        currentSheet.SetActive(false);
       
        wiringMK5343.SetActive(true);
    }
    public void navigateToWiringDWAS603M8()
    {
       currentSheet.SetActive(false);
       
       wiringDWAS603M8.SetActive(true);
    }
   
    public void navigatorPop()
    {
      
    {
       currentSheet.SetActive(true);
    
        wiringMK5343.SetActive(false);
        wiringDWAS603M8.SetActive(false);
    }  
   
    }
}
