using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneralScreenStation2Btn : MonoBehaviour
{
    public GameObject generalPanel,firstPanel, secondPanel, generalCanvas;
    // Start is called before the first frame update
    void Start()
    {    generalCanvas.SetActive(true); 
        generalPanel.SetActive(true);
     
        firstPanel.SetActive(false);
        secondPanel.SetActive(false);
    }
 
    public void navigateTofirstPanel()
    {
        generalPanel.SetActive(false);
        firstPanel.SetActive(true);
    }
    public void navigateTosecondPanel()
    {
        generalPanel.SetActive(false);
        secondPanel.SetActive(true);
    }
    
    public void navigatorPop()
    {
        generalPanel.SetActive(true);
        firstPanel.SetActive(false);
        secondPanel.SetActive(false);
    }
}
