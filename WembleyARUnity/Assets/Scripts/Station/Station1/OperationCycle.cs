using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OperationCycle : MonoBehaviour
{
    public TMP_Text encoderPositionText;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        encoderPositionText.text = GlobalVariable.encoderPosition.ToString();
    }
}
