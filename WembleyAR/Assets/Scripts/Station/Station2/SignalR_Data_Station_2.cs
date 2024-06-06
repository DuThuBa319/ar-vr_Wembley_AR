using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_2 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation2 = new List<string>  {
         $"{GlobalVariable.basedTopic}/S2/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        GlobalVariable.subscribedTopics.AddRange(topicStation2);
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
        signalR.PublishStationIndex(2);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = GlobalVariable.initialTopic;
        signalR.UpdateTopics(GlobalVariable.subscribedTopics);
        signalR.PublishStationIndex(0);
    }
}
