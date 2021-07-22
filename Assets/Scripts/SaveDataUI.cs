using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataUI : MonoBehaviour
{
    //public InputField playerName;
    //public Text Score;
    public DataManager dataManager;

    void Start()
    {
        dataManager.Load();
        //playerName.text = dataManager.data.name;
        //Score.text = dataManager.data.Score.ToString();
    }

    //public void ChangeName(string text)
    //{
    //    dataManager.data.name = text;
    //}

    public void ClickSave()
    {
        dataManager.Save();
    }
}
