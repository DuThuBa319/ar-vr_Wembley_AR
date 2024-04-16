using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_10 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation10 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
         $"{GlobalVariable.basedTopic}/S10/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = topicStation10;
        signalR.UpdateTopics(topicStation10);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}
