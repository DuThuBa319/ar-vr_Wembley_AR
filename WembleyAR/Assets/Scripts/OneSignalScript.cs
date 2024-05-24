using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OneSignalSDK;

public class OneSignalScript : MonoBehaviour
{
    void Start()
    {
        // Replace 'YOUR_ONESIGNAL_APP_ID' with your OneSignal App ID from app.onesignal.com
        OneSignal.Initialize("96b6cb31-9a02-4505-9afd-c89262e08349");
        OneSignal.Notifications.RequestPermissionAsync(true);
        OneSignal.Login("IE-F2-HCA01");

    }
}
