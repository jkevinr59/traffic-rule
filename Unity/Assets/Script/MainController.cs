using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            doExit();
        }
	}

    public void doExit() {
        Application.Quit();
    }

    public void startGame() {

        Debug.Log("We Do start");
        SaveDataController saveController = this.gameObject.GetComponent<SaveDataController>();
        
        if (saveController.LoadSaveData()) {

            SceneManager.LoadScene("TemplateMode1", LoadSceneMode.Single);
            
        }
        else
        {
            saveController.GenerateNewSave();
            SceneManager.LoadScene("TemplateMode1", LoadSceneMode.Single);
        }
    }
}
