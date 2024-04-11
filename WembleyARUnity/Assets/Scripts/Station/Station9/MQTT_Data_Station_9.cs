using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_9 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation9 = new List<string> {
 "HCM/IE-F2-HCA01/Metric/S9_MAXIMUM_HEIGHT_VALUE_TR2" ,
         "HCM/IE-F2-HCA01/Metric/S9_MINIMUN_HEIGHT_VALUE_TR2" ,
         "HCM/IE-F2-HCA01/Metric/S9_OFF_SET_TR2" ,
         "HCM/IE-F2-HCA01/Metric/S9_CURRENT_HEIGHT_TR2" ,
         "HCM/IE-F2-HCA01/Metric/S9_TOTAL_HEIGHT_TR2" ,
         "HCM/IE-F2-HCA01/Metric/S9_MAXIMUM_HEIGHT_VALUE_TR4" ,
         "HCM/IE-F2-HCA01/Metric/S9_MINIMUN_HEIGHT_VALUE_TR4" ,
         "HCM/IE-F2-HCA01/Metric/S9_OFF_SET_TR4" ,
         "HCM/IE-F2-HCA01/Metric/S9_CURRENT_HEIGHT_TR4" ,
         "HCM/IE-F2-HCA01/Metric/S9_TOTAL_HEIGHT_TR4" , };
    void Start()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
        mqtt.SubscribeTopic(topicStation9);
    }
    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation9);
    }
}

