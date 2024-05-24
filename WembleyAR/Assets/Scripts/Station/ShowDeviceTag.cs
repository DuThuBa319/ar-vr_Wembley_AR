using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ShowDeviceTag : MonoBehaviour
{
    public GameObject stationCanvas, clickBtn;
    public string tagName;
    public GameObject deviceTag;
    public Camera ARCamera;
    void Start()
    {

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
    public void OnShowingDeviceTag()
    {
        stationCanvas.SetActive(false);
        clickBtn.SetActive(true);
        deviceTag.SetActive(true);
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;

    }
    public void ReturnCanvas()
    {
        stationCanvas.SetActive(true);
        clickBtn.SetActive(false);
        deviceTag.SetActive(false);
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = false;
    }
}
