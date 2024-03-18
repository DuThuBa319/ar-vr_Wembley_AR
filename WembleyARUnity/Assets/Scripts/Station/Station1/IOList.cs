using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IOList : MonoBehaviour
{
    public GameObject contentInput, contentOutput;
    public GameObject inputBtn, outputBtn;
    public Sprite inputBtnOn, inputBtnOff;
    public Sprite outputBtnOn, outputBtnOff;

    // Start is called before the first frame update
    void Start()
    {
        inputBtn.GetComponent<Image>().sprite = inputBtnOn;
        outputBtn.GetComponent<Image>().sprite = outputBtnOff;


        contentInput.SetActive(true);
        contentOutput.SetActive(false);
    }
    public void onClickInputBtn()
    {
        inputBtn.GetComponent<Image>().sprite = inputBtnOn;
        outputBtn.GetComponent<Image>().sprite = outputBtnOff;
        contentInput.SetActive(true);
        contentOutput.SetActive(false);
    }
    public void onClickOutputBtn()
    {
        inputBtn.GetComponent<Image>().sprite = inputBtnOff;
        outputBtn.GetComponent<Image>().sprite = outputBtnOn;
        contentInput.SetActive(false);
        contentOutput.SetActive(true);
    }
}
