using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class OpenStationCanvas : MonoBehaviour
{
    public GameObject targetCanvas, clickBtn;
    public GameObject homeScreen;
    public string tagName;
    public GameObject monitorCanvas;
    public Camera ARCamera;
    // Start is called before the first frame update
    void Start()
    {
        targetCanvas.SetActive(false);
        homeScreen.SetActive(true);
        clickBtn.SetActive(true);

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag(tagName))
            {
                onOpenCanvas();
            }

        }

    }

    void onOpenCanvas()
    {
        targetCanvas.SetActive(true);
        clickBtn.SetActive(false);
        monitorCanvas.SetActive(false);
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = false;
    }
    public void onCloseCanvas()
    {
        targetCanvas.SetActive(false);
        clickBtn.SetActive(true);
        monitorCanvas.SetActive(true);
        ARCamera.GetComponent<VuforiaBehaviour>().enabled = true;
    }
}
