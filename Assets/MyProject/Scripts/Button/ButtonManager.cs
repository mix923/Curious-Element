using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public void LoadLevel()
    {
        string user = GameObject.Find("InputField").GetComponent<TMP_InputField>().text;
        PlayerPrefs.SetString("User", user);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
}
