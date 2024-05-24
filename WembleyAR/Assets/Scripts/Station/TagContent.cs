using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagContent : MonoBehaviour
{
    public string tagName;
    public GameObject tagContent;

    bool isShowingContent = false;
    void Start()
    {
        tagContent.SetActive(false);
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
                if (isShowingContent)
                {
                    tagContent.SetActive(false);
                    isShowingContent = false;
                }
                else
                {
                    tagContent.SetActive(true);
                    isShowingContent = true;
                }
            }


        }
    }
}
