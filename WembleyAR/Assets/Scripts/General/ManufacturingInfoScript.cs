using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using System.Net.Http;
using System.Threading.Tasks;
using System;

public class ManufacturingInfoScript : MonoBehaviour
{
    static string url = "https://wembleyscada.azurewebsites.net/api/References/Parameters?LineId=HerapinCap";
    public TMP_Text productNameText, referenceIdText, lotCodeText, lotSizeText, employeeText;
    private ManufacturingInfo[] manufacturingData;
    public GameObject loadingAnimator;

    void Start()
    {
        //loadingAnimator.SetActive(false);

    }
    //? The error you're seeing is because void cannot be awaited. The async keyword enables the await keyword in that method. When you await a method, it must return a Task or Task<T>.
    //? In your case, you should change async Task<void> to async Task in the UpdateManufacturingInforData method
    async void OnEnable()
    {
        await UpdateManufacturingInforData();
    }
    public async Task UpdateManufacturingInforData()
    {
        manufacturingData = await GetManufacturingInfoData();
        if (manufacturingData != null && manufacturingData.Length > 0)
        {
            SetManufacturingInfoData(manufacturingData[0]);
        }
    }

    public async Task<ManufacturingInfo[]> GetManufacturingInfoData()
    {
        OpenLoadingIndicator();

        try
        {
            using (HttpClient client = new HttpClient())
            {
                string jsonResponse = await client.GetStringAsync(url);
                manufacturingData = JsonConvert.DeserializeObject<ManufacturingInfo[]>(jsonResponse);
                if (manufacturingData == null || manufacturingData.Length == 0)
                {
                    Debug.LogError("Failed to parse JSON data or no data found.");


                }
                return manufacturingData;

            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error: " + e.Message);
        }
        finally
        {
            CloseLoadingIndicator();
        }
        return null;
    }

    //? có nhiều cách get nhưng cách này hay nhất
    // public async Task<string> FetchDataAsync(string url)
    // {
    //     using (HttpClient client = new HttpClient())
    //     {
    //         string jsonResponse = await client.GetStringAsync(url);
    //         return jsonResponse;
    //     }
    // }
    void OpenLoadingIndicator()
    {
        loadingAnimator.SetActive(true);
        loadingAnimator.GetComponent<Animator>().Play("Loading", 0, 0);
        loadingAnimator.GetComponent<Animator>().SetBool("Loading", true);

    }
    public void CloseLoadingIndicator()
    {
        loadingAnimator.SetActive(false);
        loadingAnimator.GetComponent<Animator>().SetBool("Loading", false);
    }
    public void SetManufacturingInfoData(ManufacturingInfo manufacturingData)
    {
        if (manufacturingData.productName != null)
        {

            productNameText.text = $"{manufacturingData.productName} {manufacturingData.referenceName}";
        }
        else
        {
            productNameText.text = "--";
        }
        referenceIdText.text = manufacturingData.referenceId ?? "--";
        lotCodeText.text = manufacturingData.lotCode ?? "--";
        lotSizeText.text = manufacturingData.lotSize.ToString() ?? "--";
        if (manufacturingData.stations.Length > 0 && manufacturingData.stations[0].employees.Length > 0)
        {
            employeeText.text = $"{manufacturingData.stations[0].employees[0].employeeId} - {manufacturingData.stations[0].employees[0].employeeName}";
        }
        else
        {
            employeeText.text = "--";
        }

    }
}

