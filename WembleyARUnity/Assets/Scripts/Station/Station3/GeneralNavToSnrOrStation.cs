using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralNavToSnrOrStation : MonoBehaviour
{
    public GameObject generalPanel, stationPanel, sensorPanel;
    // Start is called before the first frame update
    void Start()
    {
        generalPanel.SetActive(true);
        stationPanel.SetActive(false);
        sensorPanel.SetActive(false);
    }
    public void navigateTostationPanel()
    {
        generalPanel.SetActive(false);
        stationPanel.SetActive(true);
    }
    public void navigateTosensorPanel()
    {
        generalPanel.SetActive(false);
        sensorPanel.SetActive(true);
    }
    public void navigateTo()
    {
        generalPanel.SetActive(false);
    }
    
    public void navigatorPop()
    {
        generalPanel.SetActive(true);
        stationPanel.SetActive(false);
        sensorPanel.SetActive(false);
    }
}
