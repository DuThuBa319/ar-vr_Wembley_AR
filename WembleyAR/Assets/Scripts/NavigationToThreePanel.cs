using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationToThreePanel : MonoBehaviour
{
    public GameObject initialScreen, destinationScreen_1, destinationScreen_2, destinationScreen_3;
    public string tagName;
    void Start()
    {
        initialScreen.SetActive(true);
        destinationScreen_1.SetActive(false);
        destinationScreen_2.SetActive(false);
        destinationScreen_3.SetActive(false);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag(tagName))
            {
                NavigatePop();
            }

        }
    }

    public void NavigateToScreen_1()
    {
        initialScreen.SetActive(false);
        destinationScreen_1.SetActive(true);
    }
    public void NavigateToScreen_2()
    {
        initialScreen.SetActive(false);
        destinationScreen_2.SetActive(true);
    }
    public void NavigateToScreen_3()
    {
        initialScreen.SetActive(false);
        destinationScreen_3.SetActive(true);
    }
    public void NavigatePop()
    {
        initialScreen.SetActive(true);
        destinationScreen_1.SetActive(false);
        destinationScreen_2.SetActive(false);
        destinationScreen_3.SetActive(false);
    }
}
