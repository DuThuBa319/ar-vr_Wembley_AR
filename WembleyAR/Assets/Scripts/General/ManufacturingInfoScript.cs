using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;

public class ManufacturingInfoScript : MonoBehaviour
{
    static string url = "https://wembleyscada.azurewebsites.net/api/References/Parameters?LineId=HerapinCap";
    public TMP_Text productNameText, referenceIdText, lotCodeText, lotSizeText, employeeText;
    private ManufacturingInfo[] manufacturingData;
    public GameObject loadingAnimator;
    float timer = 0;
    void Start()
    {
        loadingAnimator.SetActive(false);
        StartCoroutine(GetManufacturingInfoData());

    }
    public IEnumerator GetManufacturingInfoData()
    {
        loadingAnimator.SetActive(true);
        loadingAnimator.GetComponent<Animator>().Play("Loading", 0, 0);
        loadingAnimator.GetComponent<Animator>().SetBool("Loading", true);
        yield return new WaitForSeconds(0.5f);
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            //The Wrapper class is used to wrap the array of ManufacturingInfo objects because JsonUtility.FromJson does not support top-level arrays.
            //ManufacturingInfo[] manufacturingData = JsonUtility.FromJson<Wrapper>("{\"manufacturingData\":" + jsonResponse + "}").manufacturingData;
            //? another way for not using wrapper class => JsonConvert trong thư viện System.Net
            manufacturingData = JsonConvert.DeserializeObject<ManufacturingInfo[]>(jsonResponse);
            if (manufacturingData == null || manufacturingData.Length == 0)
            {
                Debug.LogError("Failed to parse JSON data or no data found.");
                loadingAnimator.SetActive(false);
                loadingAnimator.GetComponent<Animator>().SetBool("Loading", false);
                yield break;
            }
        }
        catch (WebException e)
        {
            Debug.LogError("Error: " + e.Message);
            loadingAnimator.SetActive(false);
            loadingAnimator.GetComponent<Animator>().SetBool("Loading", false);
            yield break;
        }
        //  yield return new WaitForSeconds(3);
        employeeText.text = manufacturingData[0].stations[0].employees[0].employeeName;
        loadingAnimator.SetActive(false);
        loadingAnimator.GetComponent<Animator>().SetBool("Loading", false);
        yield break;
    }
}

