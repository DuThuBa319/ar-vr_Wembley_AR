using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalR_Data_Station_3 : MonoBehaviour
{
    SignalRData signalR;
    List<string> topicStation3 = new List<string> {

         $"{GlobalVariable.basedTopic}/Encoder Value" ,
         $"{GlobalVariable.basedTopic}/S3/" ,
          };
    void Awake()
    {
        signalR = GameObject.FindWithTag("signalR").GetComponent<SignalRData>();
    }
    void OnEnable()
    {
        GlobalVariable.subscribedTopics = topicStation3;
        signalR.UpdateTopics(topicStation3);
    }

    void OnDisable()
    {
        GlobalVariable.subscribedTopics = new List<string>();
        signalR.UpdateTopics(new List<string>());
    }
}
