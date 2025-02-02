using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string sPlayerH = null;
    public string sPlayerC = null;
    public int iHighScore = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();

    }
    public void SaveData()
    {
        SaveData data = new SaveData();
        data.sPlayerHighScore = sPlayerH;
        data.iHighScore = iHighScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            sPlayerH = data.sPlayerHighScore;
            iHighScore = data.iHighScore;
        }
    }

}

[System.Serializable]
public class SaveData
{
    public string sPlayerHighScore;
    public int iHighScore;
}
