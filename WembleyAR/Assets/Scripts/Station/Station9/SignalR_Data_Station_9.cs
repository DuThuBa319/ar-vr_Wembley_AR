using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_9 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation9 = new List<string> {

         $"{GlobalVariable.basedTopic}/S9_MAXIMUM_HEIGHT_VALUE_TR2" ,
         $"{GlobalVariable.basedTopic}/S9_MINIMUN_HEIGHT_VALUE_TR2" ,
         $"{GlobalVariable.basedTopic}/S9_OFF_SET_TR2" ,
         $"{GlobalVariable.basedTopic}/S9_CURRENT_HEIGHT_TR2" ,
         $"{GlobalVariable.basedTopic}/S9_TOTAL_HEIGHT_TR2" ,
         $"{GlobalVariable.basedTopic}/S9_MAXIMUM_HEIGHT_VALUE_TR4" ,
         $"{GlobalVariable.basedTopic}/S9_MINIMUN_HEIGHT_VALUE_TR4" ,
         $"{GlobalVariable.basedTopic}/S9_OFF_SET_TR4" ,
         $"{GlobalVariable.basedTopic}/S9_CURRENT_HEIGHT_TR4" ,
         $"{GlobalVariable.basedTopic}/S9_TOTAL_HEIGHT_TR4" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        GlobalVariable.subscribedTopics.AddRange(topicStation9);
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
    }
}
