using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OpenGeneralMonitor : MonoBehaviour
{
    public Camera ARCamera;
    public GameObject generalMonitor;
    // Start is called before the first frame update
    void Start()
    {
        generalMonitor.SetActive(false);
        // ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
    }
    public void openMonitor()
    {
        generalMonitor.SetActive(true);
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = false;
    }
    public void closeMonitor()
    {
        generalMonitor.SetActive(false);
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
    }

}
