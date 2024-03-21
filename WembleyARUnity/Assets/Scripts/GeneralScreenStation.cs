using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralScreenStation : MonoBehaviour
{
    public GameObject generalPanel, datasheetPanel, wiringPanel, dataPanel;
    // Start is called before the first frame update
    void Start()
    {
        generalPanel.SetActive(true);
        datasheetPanel.SetActive(false);
        wiringPanel.SetActive(false);
        dataPanel.SetActive(false);
    }
    public void navigateToDatasheetPanel()
    {
        generalPanel.SetActive(false);
        datasheetPanel.SetActive(true);
    }
    public void navigateToWiringPanel()
    {
        generalPanel.SetActive(false);
        wiringPanel.SetActive(true);
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
        wiringPanel.SetActive(false);
        dataPanel.SetActive(false);
    }
}
