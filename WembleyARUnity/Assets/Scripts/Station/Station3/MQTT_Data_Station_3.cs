using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_Station_3 : MonoBehaviour
{
    MQTT mqtt;
    List<string> topicStation3 = new List<string> {
        "HCM/IE-F2-HCA01/Metric/S3/in/00" ,
         "HCM/IE-F2-HCA01/Metric/S3/in/01" ,
         "HCM/IE-F2-HCA01/Metric/S3/in/02" ,
         "HCM/IE-F2-HCA01/Metric/S3/in/03" ,
         "HCM/IE-F2-HCA01/Metric/S3/in/04" ,
         "HCM/IE-F2-HCA01/Metric/S3/in/05" ,
         "HCM/IE-F2-HCA01/Metric/S3/in/06" ,
         "HCM/IE-F2-HCA01/Metric/S3/in/07" ,
         "HCM/IE-F2-HCA01/Metric/S3/in/08" ,
         "HCM/IE-F2-HCA01/Metric/S3/out/00" ,
         "HCM/IE-F2-HCA01/Metric/S3/out/01" ,
         "HCM/IE-F2-HCA01/Metric/S3/out/02" ,
         "HCM/IE-F2-HCA01/Metric/S3/out/03" ,
         "HCM/IE-F2-HCA01/Metric/S3/out/04" ,
         "HCM/IE-F2-HCA01/Metric/S3/out/05" ,
         "HCM/IE-F2-HCA01/Metric/S3/out/06" ,
         "HCM/IE-F2-HCA01/Metric/S3/out/07" ,
         "HCM/IE-F2-HCA01/Metric/S3/out/08" ,
         "HCM/IE-F2-HCA01/Metric/S3/out/09" , };
    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(topicStation3);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(topicStation3);
    }
}

