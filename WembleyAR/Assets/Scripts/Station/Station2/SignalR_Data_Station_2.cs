using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_2 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation2 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
         $"{GlobalVariable.basedTopic}/S2/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = topicStation2;
        signalR.UpdateTopics(topicStation2);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}
