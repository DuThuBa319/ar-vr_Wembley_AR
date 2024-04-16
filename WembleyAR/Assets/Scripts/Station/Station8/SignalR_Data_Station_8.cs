using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_8 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation8 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
        $"{GlobalVariable.basedTopic}/S8_MAXIMUM_HEIGHT_VALUE_TR1" ,
         $"{GlobalVariable.basedTopic}/S8_MINIMUN_HEIGHT_VALUE_TR1" ,
         $"{GlobalVariable.basedTopic}/S8_OFF_SET_TR1" ,
         $"{GlobalVariable.basedTopic}/S8_CURRENT_HEIGHT_TR1" ,
         $"{GlobalVariable.basedTopic}/S8_TOTAL_HEIGHT_TR1" ,
         $"{GlobalVariable.basedTopic}/S8_MAXIMUM_HEIGHT_VALUE_TR3" ,
         $"{GlobalVariable.basedTopic}/S8_MINIMUN_HEIGHT_VALUE_TR3" ,
         $"{GlobalVariable.basedTopic}/S8_OFF_SET_TR3" ,
         $"{GlobalVariable.basedTopic}/S8_CURRENT_HEIGHT_TR3" ,
         $"{GlobalVariable.basedTopic}/S8_TOTAL_HEIGHT_TR3" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = topicStation8;
        signalR.UpdateTopics(topicStation8);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}
