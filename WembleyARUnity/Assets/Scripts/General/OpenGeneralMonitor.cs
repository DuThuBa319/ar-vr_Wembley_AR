using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class OpenGeneralMonitor : MonoBehaviour
{
    public Camera ARCamera;
    public GameObject generalMonitor;
    public GameObject openButton;
    // Start is called before the first frame update
    void Start()
    {
        ApplicationChrome.statusBarState = ApplicationChrome.States.Visible;
        ApplicationChrome.statusBarColor = 0x00000000;//transparent
        ApplicationChrome.navigationBarState = ApplicationChrome.States.Hidden;
        generalMonitor.SetActive(false);
        openButton.SetActive(true);
        // ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
    }

    public void openMonitor()
    {
        openButton.SetActive(false);
        generalMonitor.SetActive(true);
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = false;

    }
    public void closeMonitor()
    {
        generalMonitor.SetActive(false);
        ApplicationChrome.statusBarState = ApplicationChrome.States.Hidden;
        ApplicationChrome.navigationBarState = ApplicationChrome.States.Hidden;
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
        openButton.SetActive(true);
    }

}
