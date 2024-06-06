using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using M2MqttUnity;
using System;
using TMPro;
using Unity.VisualScripting;

[Serializable]
public class Data
{
    public string name;
    public string value;
    public string timestamp;

    public static Data CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Data>(jsonString);
    }

}
public class DoubleTypeData
{
    public string name;
    public double value;
    public string timestamp;

    public static DoubleTypeData CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<DoubleTypeData>(jsonString);
    }

}
public class TagMessage
{
    public string TagName { get; set; }
    public string TagValue { get; set; }
    public TagMessage(string _tagName, string _tagValue)
    {
        TagName = _tagName;
        TagValue = _tagValue;
    }
}

public class MQTT : M2MqttUnity.M2MqttUnityClient
{


    public GameObject[] inputCheckS1;
    public GameObject[] outputCheckS1;
    public GameObject[] inputCheckS2;
    public GameObject[] outputCheckS2;
    public GameObject[] inputCheckS3;
    public GameObject[] outputCheckS3;
    public GameObject[] inputCheckS4;
    public GameObject[] outputCheckS4;
    public GameObject[] inputCheckS5;
    public GameObject[] outputCheckS5;
    public GameObject[] inputCheckS6;
    public GameObject[] outputCheckS6;
    public GameObject[] inputCheckS7;
    public GameObject[] outputCheckS7;
    public GameObject[] inputCheckS10;
    public GameObject[] outputCheckS10;
    public GameObject[] inputCheckS11;
    public GameObject[] outputCheckS11;
    public GameObject[] inputCheckS12;
    public GameObject[] outputCheckS12;
    //public GameObject[] S1SensorCheck;


    public GameObject[] S3SensorCheck_2;

    // public GameObject[] S5SensorCheck_1;
    public GameObject[] S5SensorCheck_2;
    public GameObject[] S10SensorCheck;

    //? S1
    public GameObject S1_Horz_Snr_On, S1_Horz_Snr_Off, S1_Vert_Up, S1_Vert_Dn, S1_Horz_Fwd, S1_Horz_Rev, S1_Gripper_On, S1_Gripper_Off;
    public GameObject[] S1_SensorCheck;
    //? S2
    public GameObject S2_Horz_Snr_On, S2_Horz_Snr_Off, S2_Vert_Up, S2_Vert_Dn, S2_Horz_Fwd, S2_Horz_Rev, S2_Vacuum_On, S2_Vacuum_Off;
    // GameObject[] S2SensorCheck;
    public GameObject[] S2_GripperOn;
    bool isReset;
    //? S3
    public GameObject[] S3_Press_Dn;
    public GameObject S3_Hold_Fwd;
    public GameObject[] S3SensorCheck_1;
    //? S3

    public GameObject S5_Slide_Dn;
    public GameObject[] S5SensorCheck_1;
    //? S4
    public GameObject S4_Horz_Snr_On, S4_Horz_Snr_Off, S4_Vert_Up, S4_Vert_Dn, S4_Horz_Fwd, S4_Horz_Rev;
    //public GameObject[] S4_SensorCheck;
    public GameObject[] S4_GripperOn;
    //? S11/S12
    public GameObject S11_Horz_Snr_On, S11_Horz_Snr_Off, S12_Gripper_On, S12_Gripper_Off, S11_Horz_Fwd, S11_Horz_Rev;
    public GameObject[] S12_SensorCheck;
    public GameObject[] S11_GripperOn;
    //? S10

    public GameObject[] S10_Holding_Fwd;
    public GameObject[] S10_AirBlow_On;

    protected override void Awake()
    {
        base.Awake();
        brokerAddress = "52.141.29.70";
        autoConnect = true;
        Connect();
    }
    protected override void Start()
    {
        base.Start();

    }
    protected override void OnConnecting()
    {
        base.OnConnecting();
        Debug.Log("Connecting");

    }
    protected override void OnConnected()
    {
        base.OnConnected();
        Debug.Log("Connected");
    }

    protected override void Update()
    {
        base.Update();

    }
    public void SubscribeTopic(List<string> topics)
    {
        foreach (var topic in topics)
        {
            client.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE });
        }
    }
    public void UnsubscribeTopic(List<string> topics)
    {
        foreach (var topic in topics)
        {
            client.Unsubscribe(new string[] { topic });
        }
    }
    protected override void SubscribeTopics()
    {


    }
    public void Publish_Message(int station)
    {

        client.Publish("Wembley/HerapinCap/IE-F2-HCA01/EnableStation", System.Text.Encoding.UTF8.GetBytes(station.ToString()), MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE, false);

    }
    protected override void DecodeMessage(string topic, byte[] message)
    {
        string msg = System.Text.Encoding.UTF8.GetString(message);

        // Debug.Log(msg);
        /*
        Debug.Log("Da nhan");
        int c = 0;
        string msg = System.Text.Encoding.UTF8.GetString(message);

        Debug.Log(msg);
        
                foreach (char chr in msg)
                {
                    if (chr == ';') c += 1;
                }
                string[] Tach_Chuoi_msg = msg.Split(";");

                Data[] jsondata = new Data[c];

                for (int i = 0; i < c; i++)
                {
                    jsondata[i] = Data.CreateFromJSON(Tach_Chuoi_msg[i]);

                    if (jsondata[i].name == "PLC.PLC.motorStatus")
                    {
                        if (jsondata[i].value == "true")
                        {
                            motorImg.GetComponent<Image>().sprite = motorOn;
                        }
                        else
                        {
                            motorImg.GetComponent<Image>().sprite = motorOff;
                        } 
                    }
                }  */
        //! đổi based topic thì đổi số ở đây
        string valueKey = topic.Remove(0, 23);
        // string msg = System.Text.Encoding.UTF8.GetString(message);

        msg = msg.TrimStart("[").TrimEnd("]");

        if (topic.Contains("Encoder Value"))
        {
            GlobalVariable.encoderPosition = int.Parse(Data.CreateFromJSON(msg).value);

        }
        //! S1
        else if (valueKey.Contains("S1/in/"))
        {

            int index = int.Parse(valueKey.Remove(0, 6));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            inputCheckS1[index].SetActive(value);
            GlobalVariable.inputStation1[index] = value;
            if (index == 0)
            {
                if (value)
                {
                    S1_Horz_Snr_On.SetActive(true);
                    S1_Horz_Snr_Off.SetActive(false);
                }
                else
                {
                    S1_Horz_Snr_Off.SetActive(true);
                    S1_Horz_Snr_On.SetActive(false);
                }
            }
            else if (index > 1 && index < 6)
            {
                S1_SensorCheck[index - 2].SetActive(value);
            }
        }
        else if (valueKey.Contains("S1/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            outputCheckS1[index].SetActive(value);
            //if(index==12) GlobalVariable.outputStation1[index] = value;
            if (index == 17 && value)
            {

                S1_Vert_Up.SetActive(true);
                S1_Vert_Dn.SetActive(false);

            }
            else if (index == 18 && value)
            {
                S1_Vert_Dn.SetActive(true);
                S1_Vert_Up.SetActive(false);
            }
            else if (index == 13 && value)
            {
                S1_Horz_Fwd.SetActive(true);
                S1_Horz_Rev.SetActive(false);
            }
            else if (index == 14 && value)
            {
                S1_Horz_Rev.SetActive(true);
                S1_Horz_Fwd.SetActive(false);
            }
            else if (index == 15 && value)
            {
                S1_Gripper_On.SetActive(true);
                S1_Gripper_Off.SetActive(false);
            }
            else if (index == 16 && value)
            {
                S1_Gripper_Off.SetActive(true);
                S1_Gripper_On.SetActive(false);
            }
        }
        //! S2
        else if (valueKey.Contains("S2/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            inputCheckS2[index].SetActive(value);

            if (index == 0)
            {
                if (value)
                {
                    S2_Horz_Snr_On.SetActive(true);
                    S2_Horz_Snr_Off.SetActive(false);
                }
                else
                {
                    S2_Horz_Snr_Off.SetActive(true);
                    S2_Horz_Snr_On.SetActive(false);
                }
            }
            // else if (index != 0 && index != 1)
            // {
            //     S2SensorCheck[index - 2].SetActive(value);
            // }

        }
        else if (valueKey.Contains("S2/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            outputCheckS2[index].SetActive(value);
            if (index == 6)
            {
                S2_GripperOn[0].SetActive(value);

            }
            else if (index == 7)
            {
                S2_GripperOn[1].SetActive(value);

            }
            else if (index == 8)
            {
                S2_GripperOn[2].SetActive(value);

            }
            else if (index == 9)
            {
                S2_GripperOn[3].SetActive(value);
            }
            else if (index == 17 && value)
            {

                S2_Vert_Up.SetActive(true);
                S2_Vert_Dn.SetActive(false);

            }
            else if (index == 18 && value)
            {
                S2_Vert_Dn.SetActive(true);
                S2_Vert_Up.SetActive(false);
            }
            else if (index == 15 && value)
            {
                S2_Horz_Fwd.SetActive(true);
                S2_Horz_Rev.SetActive(false);
            }
            else if (index == 16 && value)
            {
                S2_Horz_Rev.SetActive(true);
                S2_Horz_Fwd.SetActive(false);
            }
            else if (index == 3)
            {
                if (value)
                {
                    S2_Vacuum_On.SetActive(true);
                }
                else
                {
                    S2_Vacuum_On.SetActive(false);
                }
            }


        }
        //! S3
        else if (valueKey.Contains("S3/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            inputCheckS3[index].SetActive(value);
            if (index > 0 && index < 5)
            {
                S3SensorCheck_1[index - 1].SetActive(value);
            }


        }
        else if (valueKey.Contains("S3/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            outputCheckS3[index].SetActive(value);
            if (index == 1)
            {
                S3_Press_Dn[0].SetActive(value);

            }
            else if (index == 3)
            {
                S3_Press_Dn[1].SetActive(value);

            }
            else if (index == 5)
            {
                S3_Press_Dn[2].SetActive(value);

            }
            else if (index == 7)
            {
                S3_Press_Dn[3].SetActive(value);
            }
            else if (index == 8 && value)
            {

                S3_Hold_Fwd.SetActive(true);


            }
            else if (index == 9 && value)
            {
                S3_Hold_Fwd.SetActive(false);

            }
        }
        //! S4
        else if (valueKey.Contains("S4/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            inputCheckS4[index].SetActive(value);
            if (index == 0)
            {
                // Debug.Log("lên");
                if (value)
                {
                    S4_Horz_Snr_On.SetActive(true);
                    S4_Horz_Snr_Off.SetActive(false);
                }
                else
                {
                    S4_Horz_Snr_Off.SetActive(true);
                    S4_Horz_Snr_On.SetActive(false);
                }
            }
            // else if (index >= 6 && index <= 9)
            // {
            //     S4_SensorCheck[index - 6].SetActive(value);
            // }


        }
        else if (valueKey.Contains("S4/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            outputCheckS4[index].SetActive(value);
            if (index == 22 && value)
            {

                S4_Vert_Up.SetActive(true);
                S4_Vert_Dn.SetActive(false);

            }
            else if (index == 23 && value)
            {
                S4_Vert_Dn.SetActive(true);
                S4_Vert_Up.SetActive(false);
            }
            else if (index == 13 && value)
            {
                S4_Horz_Fwd.SetActive(true);
                S4_Horz_Rev.SetActive(false);
            }
            else if (index == 12 && value)
            {
                S4_Horz_Rev.SetActive(true);
                S4_Horz_Fwd.SetActive(false);
            }
            else if (index == 14 && value)
            {
                S4_GripperOn[0].SetActive(true);
            }
            else if (index == 15 && value)
            {
                S4_GripperOn[0].SetActive(false);
            }
            else if (index == 16 && value)
            {
                S4_GripperOn[1].SetActive(true);
            }
            else if (index == 17 && value)
            {
                S4_GripperOn[1].SetActive(false);
            }
            else if (index == 18 && value)
            {
                S4_GripperOn[2].SetActive(true);
            }
            else if (index == 19 && value)
            {
                S4_GripperOn[2].SetActive(false);
            }
            else if (index == 20 && value)
            {
                S4_GripperOn[3].SetActive(true);
            }
            else if (index == 21 && value)
            {
                S4_GripperOn[3].SetActive(false);
            }

        }
        //! S5
        else if (valueKey.Contains("S5/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            inputCheckS5[index].SetActive(value);
            if (index > 0)
            {
                S5SensorCheck_1[index - 1].SetActive(value);
            }

        }
        else if (valueKey.Contains("S5/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            outputCheckS5[index].SetActive(value);
            if (index == 1 && value)
            {

                S5_Slide_Dn.SetActive(true);


            }
            else if (index == 0 && value)
            {
                S5_Slide_Dn.SetActive(false);

            }
        }
        //! S6
        else if (valueKey.Contains("S6/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            inputCheckS6[index].SetActive(value);
        }
        else if (valueKey.Contains("S6/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            outputCheckS6[index].SetActive(value);
        }
        //! S7
        else if (valueKey.Contains("S7/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 6));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            inputCheckS7[index].SetActive(value);
        }
        else if (valueKey.Contains("S7/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            outputCheckS7[index].SetActive(value);

        }

        //! S8 
        else if (valueKey.Contains("S8"))
        {
            if (valueKey.Contains("MAXIMUM_HEIGHT_VALUE_TR1"))
            {
                GlobalVariable.S8_max_1 = DoubleTypeData.CreateFromJSON(msg).value;
                Debug.Log(GlobalVariable.S8_max_1);

            }
            else if (valueKey.Contains("MINIMUN_HEIGHT_VALUE_TR1"))
            {
                GlobalVariable.S8_min_1 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("CURRENT_HEIGHT_TR1"))
            {
                GlobalVariable.S8_current_1 = DoubleTypeData.CreateFromJSON(msg).value;
            }
            else if (valueKey.Contains("TOTAL_HEIGHT_TR1"))
            {
                GlobalVariable.S8_measured_1 = DoubleTypeData.CreateFromJSON(msg).value;
                Debug.Log(GlobalVariable.S8_measured_1);

            }
            else if (valueKey.Contains("OFF_SET_TR1"))
            {
                GlobalVariable.S8_offset_1 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("MAXIMUM_HEIGHT_VALUE_TR3"))
            {
                GlobalVariable.S8_max_3 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("MINIMUN_HEIGHT_VALUE_TR3"))
            {
                GlobalVariable.S8_min_3 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("CURRENT_HEIGHT_TR3"))
            {
                GlobalVariable.S8_current_3 = DoubleTypeData.CreateFromJSON(msg).value;
            }
            else if (valueKey.Contains("TOTAL_HEIGHT_TR3"))
            {
                GlobalVariable.S8_measured_3 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("OFF_SET_TR3"))
            {
                GlobalVariable.S8_offset_3 = DoubleTypeData.CreateFromJSON(msg).value;

            }
        }
        //! S9
        else if (valueKey.Contains("S9"))
        {
            // if (valueKey.Contains("TOTAL_HEIGHT_TR2"))
            // {
            //     Debug.Log(msg);
            //     Debug.Log(DoubleTypeData.CreateFromJSON(msg).value);

            // }
            if (valueKey.Contains("MAXIMUM_HEIGHT_VALUE_TR2"))
            {
                GlobalVariable.S9_max_2 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("MINIMUN_HEIGHT_VALUE_TR2"))
            {
                GlobalVariable.S9_min_2 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("CURRENT_HEIGHT_TR2"))
            {
                GlobalVariable.S9_current_2 = DoubleTypeData.CreateFromJSON(msg).value;
            }
            else if (valueKey.Contains("TOTAL_HEIGHT_TR2"))
            {
                GlobalVariable.S9_measured_2 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("OFF_SET_TR2"))
            {
                GlobalVariable.S9_offset_2 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("MAXIMUM_HEIGHT_VALUE_TR4"))
            {
                GlobalVariable.S9_max_4 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("MINIMUN_HEIGHT_VALUE_TR4"))
            {
                GlobalVariable.S9_min_4 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("CURRENT_HEIGHT_TR4"))
            {
                GlobalVariable.S9_current_4 = DoubleTypeData.CreateFromJSON(msg).value;
            }
            else if (valueKey.Contains("TOTAL_HEIGHT_TR4"))
            {
                GlobalVariable.S9_measured_4 = DoubleTypeData.CreateFromJSON(msg).value;

            }
            else if (valueKey.Contains("OFF_SET_TR4"))
            {
                GlobalVariable.S9_offset_4 = DoubleTypeData.CreateFromJSON(msg).value;

            }
        }
        //! S10
        else if (valueKey.Contains("S10/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            inputCheckS10[index].SetActive(value);


        }
        else if (valueKey.Contains("S10/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 8));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            outputCheckS10[index].SetActive(value);
            if (index < 4) S10_AirBlow_On[index].SetActive(value);


        }
        else if (valueKey.Contains("CHECK_PRESSURE_S10_TRACK"))
        {
            int index = int.Parse(valueKey.Remove(0, 24)) - 1;
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            S10SensorCheck[index].SetActive(value);


        }
        //!- S11
        else if (valueKey.Contains("S11/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            inputCheckS11[index].SetActive(value);
            if (index == 0)
            {
                if (value)
                {
                    S11_Horz_Snr_On.SetActive(true);
                    S11_Horz_Snr_Off.SetActive(false);
                }
                else
                {
                    S11_Horz_Snr_Off.SetActive(true);
                    S11_Horz_Snr_On.SetActive(false);
                }
            }

        }
        else if (valueKey.Contains("S11/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 8));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            outputCheckS11[index].SetActive(value);
            if (index == 0 && value)
            {

                S11_Horz_Fwd.SetActive(true);
                S11_Horz_Rev.SetActive(false);

            }
            else if (index == 1 && value)
            {
                S11_Horz_Rev.SetActive(true);
                S11_Horz_Fwd.SetActive(false);
            }
            else if (index == 2 && value)
            {
                S11_GripperOn[0].SetActive(true);
            }
            else if (index == 3 && value)
            {
                S11_GripperOn[0].SetActive(false);
            }
            else if (index == 4 && value)
            {
                S11_GripperOn[1].SetActive(true);
            }
            else if (index == 5 && value)
            {
                S11_GripperOn[1].SetActive(false);
            }
            else if (index == 6 && value)
            {
                S11_GripperOn[2].SetActive(true);
            }
            else if (index == 7 && value)
            {
                S11_GripperOn[2].SetActive(false);
            }
            else if (index == 8 && value)
            {
                S11_GripperOn[3].SetActive(true);
            }
            else if (index == 9 && value)
            {
                S11_GripperOn[3].SetActive(false);
            }
        }
        //! S12
        else if (valueKey.Contains("S12/in/"))
        {
            int index = int.Parse(valueKey.Remove(0, 7));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            inputCheckS12[index].SetActive(value);
            S12_SensorCheck[index].SetActive(value);
        }
        else if (valueKey.Contains("S12/out/"))
        {
            int index = int.Parse(valueKey.Remove(0, 8));
            bool value = Data.CreateFromJSON(msg).value == "1" ? true : false;
            outputCheckS12[index].SetActive(value);
            if (index == 0 && value)
            {

                S12_Gripper_On.SetActive(true);
                S12_Gripper_Off.SetActive(false);

            }
            else if (index == 1 && value)
            {
                S12_Gripper_Off.SetActive(true);
                S12_Gripper_On.SetActive(false);
            }
        }
        else if (valueKey.Contains("GOOD_CNT_TR"))
        {
            int index = int.Parse(valueKey.Remove(0, 11));
            GlobalVariable.goodProductCountTR[index - 1] = int.Parse(Data.CreateFromJSON(msg).value);
        }
        else if (valueKey.Contains("BAD_CNT_TR"))
        {
            int index = int.Parse(valueKey.Remove(0, 10));
            GlobalVariable.badProductCountTR[index - 1] = int.Parse(Data.CreateFromJSON(msg).value);
        }
        else if (valueKey.Contains("TOTAL_CNT_TR"))
        {
            int index = int.Parse(valueKey.Remove(0, 12));
            GlobalVariable.productCountTR[index - 1] = int.Parse(Data.CreateFromJSON(msg).value);
        }
        else if (valueKey.Contains("BOTTOM_CAP_REJ_TR"))
        {
            int index = int.Parse(valueKey.Remove(0, 17));
            GlobalVariable.RejCountS1TR[index - 1] = int.Parse(Data.CreateFromJSON(msg).value);
        }
        else if (valueKey.Contains("SILICON_PRESENCE_REJ_TR"))
        {
            int index = int.Parse(valueKey.Remove(0, 23));
            GlobalVariable.RejCountS3TR[index - 1] = int.Parse(Data.CreateFromJSON(msg).value);
        }
        else if (valueKey.Contains("COVER_PRESENCE_REJ_TR"))
        {
            int index = int.Parse(valueKey.Remove(0, 21));
            GlobalVariable.RejCountS5TR[index - 1] = int.Parse(Data.CreateFromJSON(msg).value);
        }
        else if (valueKey.Contains("HEIGHT_CHK_REJ_TR"))
        {
            int index = int.Parse(valueKey.Remove(0, 17));
            GlobalVariable.RejCountS89TR[index - 1] = int.Parse(Data.CreateFromJSON(msg).value);
        }
        else if (valueKey.Contains("LEAK_TEST_CHK_TR"))
        {
            int index = int.Parse(valueKey.Remove(0, 16));
            GlobalVariable.RejCountS10TR[index - 1] = int.Parse(Data.CreateFromJSON(msg).value);
        }
        else if (valueKey.Contains("LEAK_TEST_CHK_OK_TR1"))
        {
            GlobalVariable.RejCountS10TR[0] = int.Parse(Data.CreateFromJSON(msg).value);
        }
        else
        {
            switch (valueKey)
            {
                case "productCount":
                    GlobalVariable.productCount = int.Parse(Data.CreateFromJSON(msg).value);
                    break;
                case "goodProductRaw":
                    GlobalVariable.goodProductCount = int.Parse(Data.CreateFromJSON(msg).value);
                    break;
                case "errorProduct":
                    GlobalVariable.badProductCount = int.Parse(Data.CreateFromJSON(msg).value);
                    break;
                case "EFF":
                    GlobalVariable.effective = DoubleTypeData.CreateFromJSON(msg).value;
                    break;
                case "operationTimeRaw":
                    GlobalVariable.operationTime = Data.CreateFromJSON(msg).value;
                    break;
                default:
                    break;
            }
        }
    }
}
