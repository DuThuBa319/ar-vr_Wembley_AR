using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProductCountOverviewScript : MonoBehaviour
{
    public TMP_Text productCountText, goodProductText, badProductText, operationTimeText, effectiveText;
    public GameObject effSlider;

    // Update is called once per frame
    void Update()
    {
        productCountText.text = GlobalVariable.productCount.ToString();
        goodProductText.text = GlobalVariable.goodProductCount.ToString();
        badProductText.text = GlobalVariable.badProductCount.ToString();
        operationTimeText.text = GlobalVariable.operationTime.ToString();
        effectiveText.text = GlobalVariable.effective.ToString() + "%";
        effSlider.GetComponent<Slider>().value = (float)GlobalVariable.effective;
    }


}
