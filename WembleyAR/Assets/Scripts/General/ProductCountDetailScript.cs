using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProductCountDetailScript : MonoBehaviour
{
    public TMP_Text effectiveText;
    public TMP_Text[] detailGoodProductText, detailBadProductText, detailTotalProductText, detailBottomCapRejText, detailSiliconPresenceRejText, detailCoverPresenceRejText, detailHeightChkRejText, detailLeakTestChkOkText;
    public GameObject effSlider;

    // Update is called once per frame
    void Update()
    {
        effectiveText.text = GlobalVariable.effective.ToString() + "%";
        effSlider.GetComponent<Slider>().value = (float)GlobalVariable.effective;
        for (var i = 0; i < 4; i++)
        {
            detailGoodProductText[i].text = GlobalVariable.goodProductCountTR[i].ToString();
            detailBadProductText[i].text = GlobalVariable.badProductCountTR[i].ToString();
            detailTotalProductText[i].text = GlobalVariable.productCountTR[i].ToString();
            detailBottomCapRejText[i].text = GlobalVariable.RejCountS1TR[i].ToString();
            detailSiliconPresenceRejText[i].text = GlobalVariable.RejCountS3TR[i].ToString();
            detailCoverPresenceRejText[i].text = GlobalVariable.RejCountS5TR[i].ToString();
            detailHeightChkRejText[i].text = GlobalVariable.RejCountS89TR[i].ToString();
            detailLeakTestChkOkText[i].text = GlobalVariable.RejCountS10TR[i].ToString();
        }

    }
}
