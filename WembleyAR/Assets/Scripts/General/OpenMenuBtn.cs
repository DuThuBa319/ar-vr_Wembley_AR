using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuBtn : MonoBehaviour
{
    public GameObject menuContainer;
    bool isOpened = false;
    void Start()
    {
        menuContainer.SetActive(false);
    }

    public void OpenMenu()
    {
        if (isOpened)
        {
            menuContainer.SetActive(false);
            isOpened = false;
        }
        else
        {
            menuContainer.SetActive(true);
            isOpened = true;
        }
    }
}
