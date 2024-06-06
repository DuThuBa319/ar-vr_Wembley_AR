using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_8 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation8 = new List<string> {
       //    ,
          $"{GlobalVariable.basedTopic}/S8_MAXIMUM_HEIGHT_VALUE_TR1" ,
         $"{GlobalVariable.basedTopic}/S8_MINIMUN_HEIGHT_VALUE_TR1" ,
         $"{GlobalVariable.basedTopic}/S8_OFF_SET_TR1" ,
         $"{GlobalVariable.basedTopic}/S8_CURRENT_HEIGHT_TR1" ,
         $"{GlobalVariable.basedTopic}/S8_TOTAL_HEIGHT_TR1" ,
         $"{GlobalVariable.basedTopic}/S8_MAXIMUM_HEIGHT_VALUE_TR3" ,
         $"{GlobalVariable.basedTopic}/S8_MINIMUN_HEIGHT_VALUE_TR3" ,
         $"{GlobalVariable.basedTopic}/S8_OFF_SET_TR3" ,
         $"{GlobalVariable.basedTopic}/S8_CURRENT_HEIGHT_TR3" ,
         $"{GlobalVariable.basedTopic}/S8_TOTAL_HEIGHT_TR3" , };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation8);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation8);
    }
}

