using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ErrorListView : MonoBehaviour
{
    public GameObject errorPrefab, listView;
    public ScrollRect scrollRect;

    void Start()
    {
        // GenerateListView(GlobalVariable.errorInfors);
        //ErrorInfor errorInfor = new ErrorInfor { errorName = "Error 1 description", time = "12:00:00" };
        GenerateListView(new List<ErrorInfor>());
    }

    public void GenerateListView(List<ErrorInfor> errorInfors)
    {
        foreach (Transform child in listView.transform)
        {
            Destroy(child.gameObject);
        }

        for (var i = 0; i < errorInfors.Count; i++)
        {
            GameObject error = Instantiate(errorPrefab, listView.transform);
            error.SetActive(true);
            error.transform.localScale = new Vector3(1, 1, 1);
            GameObject errorNameText = error.transform.Find("Alarm_Name").gameObject;
            errorNameText.GetComponent<TMP_Text>().text = errorInfors[i].errorName;
            GameObject timeText = error.transform.Find("Time_text").gameObject;
            timeText.GetComponent<TMP_Text>().text = errorInfors[i].time;
        }
        scrollRect.verticalNormalizedPosition = 1;
        //! lưu ý nếu listview bị nằm ở giữa scroll rect thì chỉnh pivot y-value của listview = 1
    }


}



