using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class SaveController : MonoBehaviour {

    // Use this for initialization
    private string dataPath;
    private SaveFile dummySave;
	void Start () {
        dataPath = Application.persistentDataPath;
        dummySave = new SaveFile();
        dummySave.playerName = "Jaka";
        dummySave.playerHighScore = 5000;
        this.Saving();
	}

    private void WriteJson(string jsonString,string fileName="save.json") {

        Debug.Log("written save file:"+jsonString+" at "+this.dataPath);
        File.WriteAllText(this.dataPath+"/"+fileName, jsonString);

    }

    public void Saving() {
        string jsonString = JsonUtility.ToJson(dummySave);
        this.WriteJson(jsonString);
    }
}
[System.Serializable]
public class SaveFile {
    public string playerName;
    public int playerHighScore;

}
