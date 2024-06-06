using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_9 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation9 = new List<string> {
         //  ,
        $"{GlobalVariable.basedTopic}/S9_MAXIMUM_HEIGHT_VALUE_TR2" ,
         $"{GlobalVariable.basedTopic}/S9_MINIMUN_HEIGHT_VALUE_TR2" ,
         $"{GlobalVariable.basedTopic}/S9_OFF_SET_TR2" ,
         $"{GlobalVariable.basedTopic}/S9_CURRENT_HEIGHT_TR2" ,
         $"{GlobalVariable.basedTopic}/S9_TOTAL_HEIGHT_TR2" ,
         $"{GlobalVariable.basedTopic}/S9_MAXIMUM_HEIGHT_VALUE_TR4" ,
         $"{GlobalVariable.basedTopic}/S9_MINIMUN_HEIGHT_VALUE_TR4" ,
         $"{GlobalVariable.basedTopic}/S9_OFF_SET_TR4" ,
         $"{GlobalVariable.basedTopic}/S9_CURRENT_HEIGHT_TR4" ,
         $"{GlobalVariable.basedTopic}/S9_TOTAL_HEIGHT_TR4" , };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation9);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation9);
    }
}

