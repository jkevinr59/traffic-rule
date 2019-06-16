using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveDataController : MonoBehaviour {

    private string dataPath;
    private string fileName;
    private SaveData loadSave;
	// Use this for initialization
	void Start () {
        this.dataPath = Application.dataPath;
        this.fileName = "data.json";
        Debug.Log(this.dataPath);
        Debug.Log(this.fileName);
        //if (this.LoadSaveData())
        //{


        //}
        //else {
        //    this.GenerateNewSave();
        //    this.LoadSaveData();
        //}

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateNewSave() {
        this.dataPath = Application.dataPath;
        this.fileName = "data.json";
        SaveData saveFile = new SaveData();
        string jsonString = JsonUtility.ToJson(saveFile);
        
        File.WriteAllText(this.dataPath + "/" + this.fileName, jsonString);

    }

    public bool LoadSaveData() {
        string filePath = this.dataPath + "/" + this.fileName;
        if (File.Exists(filePath))
        {
            StreamReader reader = new StreamReader(filePath);
            string jsonString = reader.ReadToEnd();
            this.loadSave = JsonUtility.FromJson<SaveData>(jsonString);          
            return true;
        }

        else {
            return false;
        }
        
    }
}

[System.Serializable]
public class SaveData
{
    public string playerName = "PlayerName";

    public StageData Mode1Stage1 = new StageData();
    //public StageData Mode1Stage2 = new StageData();
    //public StageData Mode1Stage3 = new StageData();
    //public StageData Mode1Stage4 = new StageData();
    //public StageData Mode1Stage5 = new StageData();
    //public StageData Mode1Stage6 = new StageData();

}

[System.Serializable]
public class StageData
{
    public int star=0;
    public int isUnlocked=0;

}