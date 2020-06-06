using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private TextMeshProUGUI infoTime;
    [SerializeField] private GameObject panelCompletedLevel;
    [SerializeField] private Slider progressExtinguish;
    [SerializeField] private TextMeshProUGUI pickUpAlertText;
    [SerializeField] private TextMeshProUGUI pickUpErroTextInfo;


    public void SetInfoTime(float time)
    {
        infoTime.text = "Czas: " + time.ToString("#.00");
    }

    public void SetInfoText(string text)
    {
        infoText.text = text;
    }

    public void SetPickUpTextInfo(string text)
    {
        pickUpAlertText.text = text;
    }

    public void SetErrorPickUpMessage(string error)
    {
        pickUpErroTextInfo.text = error;
    }

    public void SetProgressExtinguish(float value)
    {
        progressExtinguish.value = value;
    }

    public void ShowProgressExtinguish()
    {
        progressExtinguish.gameObject.SetActive(true);
    }

    public void HideProgressExtinguish()
    {
        progressExtinguish.gameObject.SetActive(false);
    }

    public void HidePanelErrorPickUpMessage()
    {
        pickUpErroTextInfo.transform.parent.gameObject.SetActive(false);
    }

    public void ShowPanelCompletedLevel(float time)
    {
        panelCompletedLevel.SetActive(true);
        string user = PlayerPrefs.GetString("User");
        panelCompletedLevel.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = "User: " + user;
        panelCompletedLevel.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = "Czas: " + time.ToString("#.00");
    }
}
