using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_6 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation6 = new List<string> {
  "HCM/IE-F2-HCA01/Metric/S6/in/00" ,
         "HCM/IE-F2-HCA01/Metric/S6/in/01" ,
         "HCM/IE-F2-HCA01/Metric/S6/in/02" ,
         "HCM/IE-F2-HCA01/Metric/S6/in/03" ,
         "HCM/IE-F2-HCA01/Metric/S6/in/04" ,
         "HCM/IE-F2-HCA01/Metric/S6/in/05" ,
         "HCM/IE-F2-HCA01/Metric/S6/in/06" ,
         "HCM/IE-F2-HCA01/Metric/S6/out/00" ,
         "HCM/IE-F2-HCA01/Metric/S6/out/01" ,
         "HCM/IE-F2-HCA01/Metric/S6/out/02" ,
         "HCM/IE-F2-HCA01/Metric/S6/out/03" ,
         "HCM/IE-F2-HCA01/Metric/S6/out/04" ,
         "HCM/IE-F2-HCA01/Metric/S6/out/05" ,
         "HCM/IE-F2-HCA01/Metric/S6/out/06" ,
         "HCM/IE-F2-HCA01/Metric/S6/out/07" ,
         "HCM/IE-F2-HCA01/Metric/S6/out/08" ,
         };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation6);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation6);
    }
}

