using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralScreenStation : MonoBehaviour
{
    public GameObject generalPanel, datasheetPanel, plcAdressPanel, dataPanel, generalCanvas;
    // Start is called before the first frame update
    void Start()
    {    generalCanvas.SetActive(true); 
        generalPanel.SetActive(true);
        datasheetPanel.SetActive(false);
        plcAdressPanel.SetActive(false);
        dataPanel.SetActive(false);
    }
    public void navigateToDatasheetPanel()
    {
        generalPanel.SetActive(false);
        datasheetPanel.SetActive(true);
    }
    public void navigateToPlcAdressPanel()
    {
        generalPanel.SetActive(false);
        plcAdressPanel.SetActive(true);
    }
    public void navigateToDataPanel()
    {
        generalPanel.SetActive(false);
        dataPanel.SetActive(true);
    }
    
    public void navigatorPop()
    {
        generalPanel.SetActive(true);
        datasheetPanel.SetActive(false);
        plcAdressPanel.SetActive(false);
        dataPanel.SetActive(false);
    }
}
