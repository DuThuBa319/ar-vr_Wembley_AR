using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_7 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation7 = new List<string> {
"HCM/IE-F2-HCA01/Metric/S7/in/00" ,
       "HCM/IE-F2-HCA01/Metric/S7/in/01" ,
       "HCM/IE-F2-HCA01/Metric/S7/in/02" ,
       "HCM/IE-F2-HCA01/Metric/S7/in/03" ,
       "HCM/IE-F2-HCA01/Metric/S7/in/04" ,
       "HCM/IE-F2-HCA01/Metric/S7/in/05" ,
       "HCM/IE-F2-HCA01/Metric/S7/in/06" ,
       "HCM/IE-F2-HCA01/Metric/S7/out/00" ,
       "HCM/IE-F2-HCA01/Metric/S7/out/01" ,
       "HCM/IE-F2-HCA01/Metric/S7/out/02" ,
       "HCM/IE-F2-HCA01/Metric/S7/out/03" ,
       "HCM/IE-F2-HCA01/Metric/S7/out/04" ,
       "HCM/IE-F2-HCA01/Metric/S7/out/05" ,
       "HCM/IE-F2-HCA01/Metric/S7/out/06" , };
    void Start()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
        mqtt.SubscribeTopic(topicStation7);
    }
    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation7);
    }
}

