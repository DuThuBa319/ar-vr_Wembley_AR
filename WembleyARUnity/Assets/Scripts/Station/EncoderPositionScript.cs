using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EncoderPositionScript : MonoBehaviour
{
    public TMP_Text encoderPositionText;
    void Update()
    {
        encoderPositionText.text = GlobalVariable.encoderPosition.ToString();
    }
}
