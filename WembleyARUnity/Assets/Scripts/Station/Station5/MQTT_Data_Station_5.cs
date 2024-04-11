using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_5 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation5 = new List<string> {
 "HCM/IE-F2-HCA01/Metric/S5/in/00" ,
         "HCM/IE-F2-HCA01/Metric/S5/in/01" ,
         "HCM/IE-F2-HCA01/Metric/S5/in/02" ,
         "HCM/IE-F2-HCA01/Metric/S5/in/03" ,
         "HCM/IE-F2-HCA01/Metric/S5/in/04" ,
         "HCM/IE-F2-HCA01/Metric/S5/out/00" ,
         "HCM/IE-F2-HCA01/Metric/S5/out/01" , };
    void Start()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
        mqtt.SubscribeTopic(topicStation5);
    }
    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation5);
    }
}

