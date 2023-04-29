using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class IOController: MonoBehaviour
{
    public static IOController instance;
    private Dictionary<string, object> jsonData = new();
    private string dataPath;

    public void Awake()
    {
        dataPath = Application.persistentDataPath+"/saveFile.json";
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        if (!File.Exists(dataPath)) CreateFile();
    }

    public void WriteFile(object data)
    {
        string jsonAttribute = JsonUtility.ToJson(data);
        File.WriteAllText(dataPath, jsonAttribute);
    }

    private void CreateFile()
    {
        using (StreamWriter sw = File.CreateText(dataPath))
        {
            sw.WriteLine("{\"scoreValue\":0.00}");
        }
    }

    public Dictionary<string, object> ReadFile()
    {
        if (!File.Exists(dataPath)) throw new DataException("No data found");
        string saveJson = File.ReadAllText(dataPath);
        jsonData = JsonConvert.DeserializeObject<Dictionary<string, object>>(saveJson);
        return (jsonData);
    }
    
    
    
}





