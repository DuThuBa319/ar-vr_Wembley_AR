using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_8 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation8 = new List<string> {
          "HCM/IE-F2-HCA01/Metric/S8_MAXIMUM_HEIGHT_VALUE_TR1" ,
         "HCM/IE-F2-HCA01/Metric/S8_MINIMUN_HEIGHT_VALUE_TR1" ,
         "HCM/IE-F2-HCA01/Metric/S8_OFF_SET_TR1" ,
         "HCM/IE-F2-HCA01/Metric/S8_CURRENT_HEIGHT_TR1" ,
         "HCM/IE-F2-HCA01/Metric/S8_TOTAL_HEIGHT_TR1" ,
         "HCM/IE-F2-HCA01/Metric/S8_MAXIMUM_HEIGHT_VALUE_TR3" ,
         "HCM/IE-F2-HCA01/Metric/S8_MINIMUN_HEIGHT_VALUE_TR3" ,
         "HCM/IE-F2-HCA01/Metric/S8_OFF_SET_TR3" ,
         "HCM/IE-F2-HCA01/Metric/S8_CURRENT_HEIGHT_TR3" ,
         "HCM/IE-F2-HCA01/Metric/S8_TOTAL_HEIGHT_TR3" , };
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

