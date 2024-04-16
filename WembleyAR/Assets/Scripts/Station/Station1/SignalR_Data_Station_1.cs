using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_1 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation1 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
         $"{GlobalVariable.basedTopic}/S1/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = topicStation1;
        signalR.UpdateTopics(topicStation1);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}
