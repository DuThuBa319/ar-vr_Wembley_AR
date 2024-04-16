using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_1 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation1 = new List<string> {

         "HCM/IE-F2-HCA01/Metric/Encoder Value" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/00" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/01" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/02" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/03" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/04" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/05" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/06" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/07" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/08" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/09" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/10" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/11" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/12" ,
         "HCM/IE-F2-HCA01/Metric/S1/in/13" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/00" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/01" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/02" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/03" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/04" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/05" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/06" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/07" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/08" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/09" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/10" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/11" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/12" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/13" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/14" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/15" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/16" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/17" ,
         "HCM/IE-F2-HCA01/Metric/S1/out/18" , };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation1);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation1);
    }
}

