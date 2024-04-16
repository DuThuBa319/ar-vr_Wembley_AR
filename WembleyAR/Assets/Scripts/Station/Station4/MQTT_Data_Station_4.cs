using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_4 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation4 = new List<string> {
 "HCM/IE-F2-HCA01/Metric/S4/in/00" ,
         "HCM/IE-F2-HCA01/Metric/S4/in/01" ,
         "HCM/IE-F2-HCA01/Metric/S4/in/02" ,
         "HCM/IE-F2-HCA01/Metric/S4/in/03" ,
         "HCM/IE-F2-HCA01/Metric/S4/in/04" ,
         "HCM/IE-F2-HCA01/Metric/S4/in/05" ,
         "HCM/IE-F2-HCA01/Metric/S4/in/06" ,
         "HCM/IE-F2-HCA01/Metric/S4/in/07" ,
         "HCM/IE-F2-HCA01/Metric/S4/in/08" ,
         "HCM/IE-F2-HCA01/Metric/S4/in/09" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/00" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/01" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/02" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/03" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/04" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/05" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/06" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/07" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/08" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/09" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/10" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/11" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/12" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/13" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/14" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/15" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/16" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/17" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/18" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/19" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/20" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/21" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/22" ,
         "HCM/IE-F2-HCA01/Metric/S4/out/23" , };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation4);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation4);
    }
}

