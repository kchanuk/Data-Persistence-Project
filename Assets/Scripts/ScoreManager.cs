using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public string name; 
    public int score;

    public string playername;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class ScoreData
    {
        public string name;
        public int score;
    }

    public void SaveScore()
    {
        ScoreData data=new ScoreData();
        data.name= name;
        data.score= score;

        string json=JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath+"/savefile.json", json);
    }

    public void LoadScore()
    {
        string path= Application.persistentDataPath+"/savefile.json";
        if(File.Exists(path))
        {
            string json=File.ReadAllText(path);
            ScoreData data=JsonUtility.FromJson<ScoreData>(json);
            name=data.name;
            score=data.score;
        }
    }

}
