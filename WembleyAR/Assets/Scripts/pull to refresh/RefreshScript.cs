using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshScript : MonoBehaviour
{
    // Start is called before the first frame update
    float initialPosY;
    public GameObject content;
    bool isPulled;
    float distance;

    ManufacturingInfoScript manufacturingInfoScript;
    void Start()
    {
        initialPosY = content.GetComponent<RectTransform>().anchoredPosition.y;
        manufacturingInfoScript = GameObject.FindWithTag("manufacturingInfoScript").GetComponent<ManufacturingInfoScript>();
    }

    public void OnScroll(Vector2 value)
    {
        distance = initialPosY - content.GetComponent<RectTransform>().anchoredPosition.y;
        if (!isPulled && distance < 300f)
        {
            return;
        }
        else
        {
            isPulled = true;
        }
        if (isPulled && distance < 100)
        {
            isPulled = false;
            //! đừng thêm async/await
            manufacturingInfoScript.UpdateManufacturingInforData();
        }
    }
}
