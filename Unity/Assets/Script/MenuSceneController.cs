using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour {

    // Use this for initialization


    public void SelectStageOne() {
        
        SceneManager.LoadScene("scene/StageOneSelect", LoadSceneMode.Single);
    }

    public void SelectStageTwo()
    {

        SceneManager.LoadScene("scene/StageTwoSelect", LoadSceneMode.Single);
    }

    public void SelectStageThree()
    {

        SceneManager.LoadScene("scene/StageThreeSelect", LoadSceneMode.Single);
    }

    public void ToTitle() {
        SceneManager.LoadScene("scene/MainTitle", LoadSceneMode.Single);
    }

    public void ToStageSelect()
    {
        SceneManager.LoadScene("scene/StageSelect", LoadSceneMode.Single);
    }

    public void StageOneLevel(int level) {

        //SceneManager.LoadScene("TemplateMode1", LoadSceneMode.Single);

        if (level == 1) {
            SceneManager.LoadScene("scene/Mode1Stage1", LoadSceneMode.Single);
        }

        else if(level == 2){
            SceneManager.LoadScene("scene/Mode1Stage2", LoadSceneMode.Single);
        }
        else if (level == 3)
        {
            SceneManager.LoadScene("scene/Mode1Stage3", LoadSceneMode.Single);
        }
    }
}
