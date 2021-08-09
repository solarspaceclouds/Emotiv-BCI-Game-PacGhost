using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public PlayerData data;
    public string coinamt = ScoreTextScript.coinAmount.ToString();
    
    public static string directory = "/SaveData/";
    public static string fileName = "player_" + BrainFramework.Profile + ".txt";

    private string file = "player_" + BrainFramework.Profile + ".txt";

    public void Awake()
    {
        PlayerData saveObject = new PlayerData
        {
            playerName = BrainFramework.Profile,
            playerScore = ScoreTextScript.coinAmount.ToString(),
        };
        string json = JsonUtility.ToJson(saveObject);
        Debug.Log("json string: " + json);
    }
    public void Save()
    {
        string dir = Application.persistentDataPath + directory;
        PlayerData saveObject = new PlayerData();
        Debug.Log("DataManager Save");
        if (!Directory.Exists(dir))
        {
            Debug.Log("Create New Directory");
            Directory.CreateDirectory(dir);

        }
        string json = JsonUtility.ToJson(saveObject);
        File.AppendAllText(dir + fileName, "\n" + json);
        Debug.Log("Json: " + json);
        Debug.Log("Player data saved successfully at: " + dir + fileName);
        //Debug.Log("Save: ScoreTextScript.coinAmount " + coinamt);
        //Debug.Log("Save: PlayerData.playerScore " + data.playerScore);
        //string json = JsonUtility.ToJson(data);
        //WriteToFile(file, json);

        
    }

    public void Load()
    {
        data = new PlayerData();
        string json = ReadFromFile(file);
        JsonUtility.FromJsonOverwrite(json, data);
    }
    private PlayerData WriteToFile(string fileName, string json)
    {
        string dir2 = Application.persistentDataPath + "/" + file;
        PlayerData saveObject = new PlayerData();
        if (File.Exists(dir2))
        {
            //string.json = File.ReadAllText(fullPath);
            //so = JsonUtility.FromJson<SaveObject>(json);

            json = File.ReadAllText(dir2);
            saveObject = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.Log("Save file does not exist");
            json = JsonUtility.ToJson(saveObject);
            File.AppendAllText(dir2 + fileName, json);
            Debug.Log("Json: " + json);
        }
        Debug.Log("Player data saved successfully at: " + dir2);
        return saveObject;

        //string path = GetFilePath(fileName);
        //FileStream fileStream = new FileStream(path, FileMode.Create);

        //using (StreamWriter writer = new StreamWriter(fileStream))
        //{
        //    //writer.Write(json);
        //    writer.WriteLine(json);
        //}
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
        {
            Debug.LogWarning("File not found!");
        }
        return "";
    }
    private string GetFilePath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }

}
