using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOpenCanvas : MonoBehaviour
{
    public GameObject targetCanvas, clickBtn;
    public GameObject generalPanel;
    public string tagName;
    // Start is called before the first frame update
    void Start()
    {
        targetCanvas.SetActive(false);
        generalPanel.SetActive(true);
        clickBtn.SetActive(true);

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && (hit.collider.CompareTag(tagName)))
            {
                onOpenCanvas();
            }

        }

    }

    void onOpenCanvas()
    {
        targetCanvas.SetActive(true);
        clickBtn.SetActive(false);
    }
    public void onCloseCanvas()
    {
        targetCanvas.SetActive(false);
        clickBtn.SetActive(true);
    }
}
