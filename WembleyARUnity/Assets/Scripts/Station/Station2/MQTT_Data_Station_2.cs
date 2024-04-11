using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_2 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation2 = new List<string> {
 "HCM/IE-F2-HCA01/Metric/Encoder Value" ,
         "HCM/IE-F2-HCA01/Metric/S2/in/00" ,
         "HCM/IE-F2-HCA01/Metric/S2/in/01" ,
         "HCM/IE-F2-HCA01/Metric/S2/in/02" ,
         "HCM/IE-F2-HCA01/Metric/S2/in/03" ,
         "HCM/IE-F2-HCA01/Metric/S2/in/04" ,
         "HCM/IE-F2-HCA01/Metric/S2/in/05" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/00" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/01" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/02" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/03" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/04" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/05" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/06" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/07" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/08" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/09" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/10" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/11" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/12" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/13" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/14" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/15" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/16" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/17" ,
         "HCM/IE-F2-HCA01/Metric/S2/out/18" , };
    void Start()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
        mqtt.SubscribeTopic(topicStation2);
    }
    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation2);
    }
}

