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
        this.dataPath = Application.persistentDataPath;
        this.fileName = "data.json";
        Debug.Log(this.dataPath);
        Debug.Log(this.fileName);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateNewSave() {
        
        SaveData saveFile = new SaveData();
        saveFile.Mode1Stage1.isUnlocked = 1;
        saveFile.Mode1Stage2.isUnlocked = 1;
        saveFile.Mode1Stage3.isUnlocked = 1;
        this.savingData(saveFile);
        

    }

    public bool LoadSaveData() {
        this.dataPath = Application.persistentDataPath;
        this.fileName = "data.json";
        string filePath = this.dataPath + "/" + this.fileName;
        if (File.Exists(filePath))
        {
            StreamReader reader = new StreamReader(filePath);
            string jsonString = reader.ReadToEnd();
            this.loadSave = JsonUtility.FromJson<SaveData>(jsonString);
            reader.Close();
            return true;
        }

        else {
            return false;
        }
        
    }

    private void savingData(SaveData saveFile) {
        this.dataPath = Application.persistentDataPath;
        this.fileName = "data.json";
        string jsonString = JsonUtility.ToJson(saveFile);
        File.WriteAllText(this.dataPath + "/" + this.fileName, jsonString);

    }


    public int GetStar(int stage, int level)
    {

        this.LoadSaveData();
        int star = 0;
        if (stage == 1)
        {
            switch (level)
            {
                case 1:
                    star = this.loadSave.Mode1Stage1.star;
                    break;
                case 2:
                    star = this.loadSave.Mode1Stage2.star;
                    break;
                case 3:
                    star = this.loadSave.Mode1Stage3.star;
                    break;
                case 4:
                    star = this.loadSave.Mode1Stage4.star;
                    break;
                default:
                    star = 0;
                    break;
            }


        }

        return star;
    }

    public void SaveStarResult(int stage, int level, int star) {
        this.LoadSaveData();
        if (stage == 1)
        {
            switch (level)
            {
                case 1:
                    this.loadSave.Mode1Stage1.star = star;
                    break;
                case 2:
                    this.loadSave.Mode1Stage2.star = star;
                    break;
                case 3:
                    this.loadSave.Mode1Stage3.star = star;
                    break;
                case 4:
                    this.loadSave.Mode1Stage4.star = star;
                    break;
                default:
                    break;
            }


        }

        this.savingData(this.loadSave);
        return;
    }

    public void unlockStage(int stage, int level) {


    }

    public bool StageUnlockStatus(int stage, int level)
    {

        this.LoadSaveData();
        bool status = false;
        if (stage == 1)
        {
            switch (level)
            {
                case 1:
                    status = (this.loadSave.Mode1Stage1.isUnlocked == 1) ? true : false;
                    break;
                case 2:
                    status = (this.loadSave.Mode1Stage2.isUnlocked == 1) ? true : false;
                    break;
                case 3:
                    status = (this.loadSave.Mode1Stage3.isUnlocked == 1) ? true : false;
                    break;
                case 4:
                    status = (this.loadSave.Mode1Stage4.isUnlocked == 1) ? true : false;
                    break;
                default:
                    status = (this.loadSave.Mode1Stage5.isUnlocked == 1) ? true : false;
                    break;
            }


        }

        return status;
    }

}

[System.Serializable]
public class SaveData
{
    public string playerName = "PlayerName";

    public StageData Mode1Stage1 = new StageData();
    public StageData Mode1Stage2 = new StageData();
    public StageData Mode1Stage3 = new StageData();
    public StageData Mode1Stage4 = new StageData();
    public StageData Mode1Stage5 = new StageData();
    //public StageData Mode1Stage6 = new StageData();

}

[System.Serializable]
public class StageData
{
    public int star=0;
    public int isUnlocked=0;

}