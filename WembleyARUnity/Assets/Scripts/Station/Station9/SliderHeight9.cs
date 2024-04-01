using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class SliderHeight9 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject highLimit;
    public GameObject slider, offsetText, minText, maxText; //? 3 text này là GameObject chứ ghi chú và value

    public TMP_Text offsetValueText, minValueText, maxValueText;
    public GameObject valueBar;
    Image valueBarImg;
    float barHeight = 0, offsetHeight, minHeight, maxHeight;
    public float measuredHeight;

    void Start()
    {
        //get API
        offsetHeight = 20.95f;
        minHeight = 21.00f;
        maxHeight = 21.4f;
        // measuredHeight = 21.12f;
        //tắt cho chắc
        offsetText.SetActive(false);
        minText.SetActive(false);
        maxText.SetActive(false);
        // lấy chiều cao của Slider 
        barHeight = highLimit.GetComponent<RectTransform>().anchoredPosition.y;
        // lấy hình ảnh của heightBar
        valueBarImg = valueBar.GetComponent<Image>();
        valueBarImg.color = Color.green;
        // Set up
        SetUpSlider(slider, offsetHeight, minHeight, maxHeight, offsetText, minText, maxText, offsetValueText, minValueText, maxValueText);
    }
    void Update()
    {
        UpdateHeightValue(measuredHeight);
    }
    void SetUpSlider(GameObject slider, float offsetValue, float minValue, float maxValue, GameObject offsetText, GameObject minText, GameObject maxText, TMP_Text offsetValueText, TMP_Text minValueText, TMP_Text maxValueText)
    {
        //! lấy maxSlider là giá trị max của Slider
        float maxSlider = slider.GetComponent<Slider>().maxValue;
        //? gấn giá trị vào text với 2 chữ số thập phân
        offsetValueText.text = offsetValue.ToString("F2");
        minValueText.text = minValue.ToString("F2");
        maxValueText.text = maxValue.ToString("F2");
        //? 
        float offsetTextPosX = offsetText.GetComponent<RectTransform>().anchoredPosition.x;
        float minTextPosX = minText.GetComponent<RectTransform>().anchoredPosition.x;
        float maxTextPosX = maxText.GetComponent<RectTransform>().anchoredPosition.x;
        //! minSlider là giá trị min của Slider => Tìm minSlider= min(offsetValue,minValue)
        float minSlider = 21.0f;
        if (minValue < offsetValue)
        {
            minSlider = minValue;
            slider.GetComponent<Slider>().minValue = minSlider;
            //? minValue giữ nguyên vị trí => chuẩn hóa (normalize) để xác định vị trí của offsetText 
            //?=> do thanh slider là chiều dọc => PosX giữ nguyên, tìm PosY
            float offsetTextPosY = barHeight * (offsetValue - minSlider) / (maxSlider - minSlider);
            offsetText.GetComponent<RectTransform>().anchoredPosition = new Vector3(offsetTextPosX, offsetTextPosY, 0);
            
            minText.SetActive(true);
        }
        else if (minValue > offsetValue)
        {
            minSlider = offsetValue;
            slider.GetComponent<Slider>().minValue = minSlider;
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
    public void UpdateHeightValue(float value)
    {
        slider.GetComponent<Slider>().value = value;
        if (value <= maxHeight && value >= minHeight)
        {
            valueBarImg.color = Color.green;
        }
        else
        {
            valueBarImg.color = Color.red;
        }
    }




}
