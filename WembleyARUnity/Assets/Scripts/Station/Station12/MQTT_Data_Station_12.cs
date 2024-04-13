using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_12 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation12 = new List<string> {

                    "HCM/IE-F2-HCA01/Metric/S11/in/00" ,
         "HCM/IE-F2-HCA01/Metric/S11/out/00" ,
         "HCM/IE-F2-HCA01/Metric/S11/out/01" ,
         "HCM/IE-F2-HCA01/Metric/S11/out/02" ,
         "HCM/IE-F2-HCA01/Metric/S11/out/03" ,
         "HCM/IE-F2-HCA01/Metric/S11/out/04" ,
         "HCM/IE-F2-HCA01/Metric/S11/out/05" ,
         "HCM/IE-F2-HCA01/Metric/S11/out/06" ,
         "HCM/IE-F2-HCA01/Metric/S11/out/07" ,
         "HCM/IE-F2-HCA01/Metric/S11/out/08" ,
         "HCM/IE-F2-HCA01/Metric/S11/out/09" ,
};
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation12);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation12);
    }
}
