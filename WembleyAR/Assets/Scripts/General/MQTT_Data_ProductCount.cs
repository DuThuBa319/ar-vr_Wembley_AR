using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MQTT_Data_ProductCount : MonoBehaviour
{
    MQTT mqtt;
    List<string> productCountTopics = new List<string> {

         $"{GlobalVariable.basedTopic}/productCount" ,
         $"{GlobalVariable.basedTopic}/EFF" ,
         $"{GlobalVariable.basedTopic}/goodProductRaw" ,
         $"{GlobalVariable.basedTopic}/errorProduct" ,
          $"{GlobalVariable.basedTopic}/operationTimeRaw" ,
         $"{GlobalVariable.basedTopic}/GOOD_CNT_TR1" ,
         $"{GlobalVariable.basedTopic}/GOOD_CNT_TR2" ,
         $"{GlobalVariable.basedTopic}/GOOD_CNT_TR3" ,
         $"{GlobalVariable.basedTopic}/GOOD_CNT_TR4" ,
         $"{GlobalVariable.basedTopic}/BAD_CNT_TR1" ,
         $"{GlobalVariable.basedTopic}/BAD_CNT_TR2" ,
         $"{GlobalVariable.basedTopic}/BAD_CNT_TR3" ,
         $"{GlobalVariable.basedTopic}/BAD_CNT_TR4" ,
         $"{GlobalVariable.basedTopic}/TOTAL_CNT_TR1" ,
         $"{GlobalVariable.basedTopic}/TOTAL_CNT_TR2" ,
         $"{GlobalVariable.basedTopic}/TOTAL_CNT_TR3" ,
         $"{GlobalVariable.basedTopic}/TOTAL_CNT_TR4" ,
         $"{GlobalVariable.basedTopic}/BOTTOM_CAP_REJ_TR1" ,
         $"{GlobalVariable.basedTopic}/BOTTOM_CAP_REJ_TR2" ,
         $"{GlobalVariable.basedTopic}/BOTTOM_CAP_REJ_TR3" ,
         $"{GlobalVariable.basedTopic}/BOTTOM_CAP_REJ_TR4" ,
         $"{GlobalVariable.basedTopic}/SILICON_PRESENCE_REJ_TR1" ,
         $"{GlobalVariable.basedTopic}/SILICON_PRESENCE_REJ_TR2" ,
         $"{GlobalVariable.basedTopic}/SILICON_PRESENCE_REJ_TR3" ,
         $"{GlobalVariable.basedTopic}/SILICON_PRESENCE_REJ_TR4" ,
         $"{GlobalVariable.basedTopic}/COVER_PRESENCE_REJ_TR1" ,
         $"{GlobalVariable.basedTopic}/COVER_PRESENCE_REJ_TR2" ,
         $"{GlobalVariable.basedTopic}/COVER_PRESENCE_REJ_TR3" ,
         $"{GlobalVariable.basedTopic}/COVER_PRESENCE_REJ_TR4" ,
         $"{GlobalVariable.basedTopic}/HEIGHT_CHK_REJ_TR1" ,
         $"{GlobalVariable.basedTopic}/HEIGHT_CHK_REJ_TR2" ,
         $"{GlobalVariable.basedTopic}/HEIGHT_CHK_REJ_TR3" ,
         $"{GlobalVariable.basedTopic}/HEIGHT_CHK_REJ_TR4" ,
         $"{GlobalVariable.basedTopic}/LEAK_TEST_CHK_OK_TR1" ,
         $"{GlobalVariable.basedTopic}/LEAK_TEST_CHK_TR2" ,
         $"{GlobalVariable.basedTopic}/LEAK_TEST_CHK_TR3" ,
         $"{GlobalVariable.basedTopic}/LEAK_TEST_CHK_TR4" ,
          };

    void Awake()
    {
        mqtt = GameObject.FindWithTag("Mqtt").GetComponent<MQTT>();
    }
    void OnEnable()
    {
        mqtt.SubscribeTopic(productCountTopics);
    }

    void OnDisable()
    {
        mqtt.UnsubscribeTopic(productCountTopics);
    }
}
