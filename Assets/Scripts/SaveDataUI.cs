using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveDataUI : MonoBehaviour
{
    //public InputField playerName;
    //public Text playerScore;
    public DataManager dataManager;
    //public string playerName = BrainFramework.Profile;
    //public int playerScore = ScoreTextScript.coinAmount;

    public GameObject savedNotif; 

    void Start()
    {
        dataManager.Load();
        Debug.Log("SaveDataUI START");
    }

    //public void ChangeName(string text)
    //{
    //    dataManager.data.name = text;
    //}

    public void ClickSave()
    {
        Debug.Log("SaveDataUI ClickSave");
        dataManager.Save();
        //SaveManager.Save(so);
        StartCoroutine(savedPopUpMessage(savedNotif, 3));
    }
    IEnumerator savedPopUpMessage(GameObject saveNotif, float delay)
    {
        saveNotif.SetActive(true);
        yield return new WaitForSeconds(delay);
        saveNotif.SetActive(false);
    }
}
