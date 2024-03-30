using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IOListS5 : MonoBehaviour
{
    public GameObject contentInput, contentOutput;
    public GameObject inputBtn, outputBtn;
    public Sprite inputBtnOn, inputBtnOff;
    public Sprite outputBtnOn, outputBtnOff;
    public GameObject[] inputCheck = new GameObject[5];
    public GameObject[] outputCheck = new GameObject[2];


    // Start is called before the first frame update
    void Start()
    {
        inputBtn.GetComponent<Image>().sprite = inputBtnOn;
        outputBtn.GetComponent<Image>().sprite = outputBtnOff;
        contentInput.SetActive(true);
        contentOutput.SetActive(false);
    }
    void Update()
    {
        for (var i = 0; i < inputCheck.Length; i++)
        {
            if (GlobalVariable.inputStation5[i]) inputCheck[i].SetActive(true);
            else inputCheck[i].SetActive(false);
        }
        for (var i = 0; i < outputCheck.Length; i++)
        {
            if (GlobalVariable.outputStation5[i]) outputCheck[i].SetActive(true);
            else outputCheck[i].SetActive(false);
        }
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
