using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class HeightS8TR1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject highLimit;
    public GameObject slider, minText, maxText; //? 2 text này là GameObject chứa ghi chú và value

    public TMP_Text minValueText, maxValueText, currentValueText, offsetValueText, measuredValueText;
    public GameObject valueBar;
    Image valueBarImg;
    float barHeight = 0, offsetHeight, minHeight, maxHeight;


    void Start()
    {
        //get API
        offsetHeight = GlobalVariable.S8_offset_1;
        minHeight = GlobalVariable.S8_min_1;
        maxHeight = GlobalVariable.S8_max_1;
        // measuredHeight = 21.12f;
        //tắt cho chắc

        minText.SetActive(false);
        maxText.SetActive(false);
        // lấy chiều cao của Slider 
        barHeight = highLimit.GetComponent<RectTransform>().anchoredPosition.y;
        // lấy hình ảnh của heightBar
        valueBarImg = valueBar.GetComponent<Image>();
        valueBarImg.color = Color.green;
        // Set up
        offsetValueText.text = offsetHeight.ToString("F2");

        SetUpSlider(slider, offsetHeight, minHeight, maxHeight, minText, maxText, offsetValueText, minValueText, maxValueText);
    }
    void Update()
    {
        float measuredHeight = GlobalVariable.S8_measured_1;
        float currentHeight = GlobalVariable.S8_current_1;
        currentValueText.text = currentHeight.ToString("F2");
        measuredValueText.text = measuredHeight.ToString("F2");
        slider.GetComponent<Slider>().value = measuredHeight;
        if (measuredHeight <= maxHeight && measuredHeight >= minHeight)
        {
            valueBarImg.color = Color.green;
        }
        else
        {
            valueBarImg.color = Color.red;
        }
    }
    void SetUpSlider(GameObject slider, float offsetValue, float minValue, float maxValue, GameObject minText, GameObject maxText, TMP_Text offsetValueText, TMP_Text minValueText, TMP_Text maxValueText)
    {
        //! lấy maxSlider là giá trị max của Slider
        float maxSlider = slider.GetComponent<Slider>().maxValue;
        //? gấn giá trị vào text với 2 chữ số thập phân

        minValueText.text = minValue.ToString("F2");
        maxValueText.text = maxValue.ToString("F2");
        //? 

        float minTextPosX = minText.GetComponent<RectTransform>().anchoredPosition.x;
        float maxTextPosX = maxText.GetComponent<RectTransform>().anchoredPosition.x;
        //! minSlider là giá trị min của Slider => Tìm minSlider= min(offsetValue,minValue)
        float minSlider = 21.0f;
        if (minValue < offsetValue)
        {
            minSlider = minValue;
            slider.GetComponent<Slider>().minValue = minSlider;
            minText.SetActive(true);
        }
        else if (minValue > offsetValue)
        {
            minSlider = offsetValue;
            slider.GetComponent<Slider>().minValue = minSlider;
            //? minValue sẽ là offset => chuẩn hóa (normalize) để xác định vị trí của minText 
            //?=> do thanh slider là chiều dọc => PosX giữ nguyên, tìm PosY
            float minTextPosY = barHeight * (minValue - minSlider) / (maxSlider - minSlider);
            minText.GetComponent<RectTransform>().anchoredPosition = new Vector3(minTextPosX, minTextPosY, 0);

            minText.SetActive(true);
        }
        else if (minValue == offsetValue)
        {
            minSlider = minValue;
            slider.GetComponent<Slider>().minValue = minSlider;
            minText.SetActive(true);
        }
        //? tìm vị trí cho maxText
        float maxTextPosY = barHeight * (maxValue - minSlider) / (maxSlider - minSlider);
        maxText.GetComponent<RectTransform>().anchoredPosition = new Vector3(maxTextPosX, maxTextPosY, 0);
        maxText.SetActive(true);
    }





}
