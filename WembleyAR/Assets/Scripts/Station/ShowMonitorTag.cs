using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ShowMonitorTag : MonoBehaviour
{
    public GameObject stationCanvas, clickBtn;
    public string tagName;
    public GameObject monitorTag;
    public Camera ARCamera;
    void Start()
    {
        monitorTag.SetActive(false);
        //  externalDeviceTag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag(tagName))
            {
                ReturnCanvas();
            }
        }
    }
    public void OnShowingMonitorTag()
    {
        stationCanvas.SetActive(false);
        clickBtn.SetActive(true);
        monitorTag.SetActive(true);
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;

    }
    public void ReturnCanvas()
    {
        stationCanvas.SetActive(true);
        clickBtn.SetActive(false);
        monitorTag.SetActive(false);
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = false;
    }
}
