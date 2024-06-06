using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_5 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation5 = new List<string>  {
         $"{GlobalVariable.basedTopic}/S5/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        GlobalVariable.subscribedTopics.AddRange(topicStation5);
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
        signalR.PublishStationIndex(5);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
        signalR.PublishStationIndex(0);
    }
}
