using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_11 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation11 = new List<string> {
        $"{GlobalVariable.basedTopic}/Encoder Value" ,
        $"{GlobalVariable.basedTopic}/S11/in/00" ,
         $"{GlobalVariable.basedTopic}/S11/out/00" ,
         $"{GlobalVariable.basedTopic}/S11/out/01" ,
         $"{GlobalVariable.basedTopic}/S11/out/02" ,
         $"{GlobalVariable.basedTopic}/S11/out/03" ,
         $"{GlobalVariable.basedTopic}/S11/out/04" ,
         $"{GlobalVariable.basedTopic}/S11/out/05" ,
         $"{GlobalVariable.basedTopic}/S11/out/06" ,
         $"{GlobalVariable.basedTopic}/S11/out/07" ,
         $"{GlobalVariable.basedTopic}/S11/out/08" ,
         $"{GlobalVariable.basedTopic}/S11/out/09" ,};
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation11);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation11);
    }
}

