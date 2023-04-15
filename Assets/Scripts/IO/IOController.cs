using System.IO;
using UnityEngine;

public class IOController: MonoBehaviour
{
    public static IOController instance;
    public TextAsset jsonFile;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }

    public void WriteFile(float score)
    {
        JsonData jsonData = new JsonData();
        jsonData.name = "Score";
        jsonData.score = score;
        string jsonAttribute = JsonUtility.ToJson(jsonData);
        File.WriteAllText(Application.dataPath+"/data.txt", jsonAttribute);
    }

    public JsonData ReadFile()
    {
        return JsonUtility.FromJson<JsonData>(jsonFile.text);
    }
    
    
    
}

[System.Serializable]
public class JsonData
{
    public string name;
    public float score;
}




