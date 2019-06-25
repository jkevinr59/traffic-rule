using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageOneController : MonoBehaviour {

    public GameObject player;
    public GameObject Speedometer;
    public GameObject timer;
    public GameObject intropanel;
    public GameObject resultPanel;
    public GameObject failPanel;
    public int level;
    public int limitSecond;
    public int twoStarSecond;
    public int threeStarSecond;
    public int limitSpeed;
    private int maxSpeed;

    private float initialTime;
    
	// Use this for initialization
	void Start () {
        maxSpeed = 0;
        ShowIntroPanel();
        initialTime = Time.time;
        resultPanel.SetActive(false);
        failPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        updateTimer();
        updateSpeed();
        
	}


    void updateTimer() {

        try
        {
            Text timeText;
            int remainingSecond = this.limitSecond - this.GetTime();
            string timeString = this.SecondToTimeFormat(remainingSecond);
            timeText = this.timer.GetComponent<Text>();
            timeText.text = timeString;
            
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }


    string SecondToTimeFormat(int second) {

        string timeString = "00:00";

        int secondFormat = second % 60;
        int minuteFormat = second / 60;
        timeString = minuteFormat.ToString().PadLeft(2,'0') + ":" + secondFormat.ToString().PadLeft(2, '0');
        return timeString;
    }

    void updateSpeed() {

        
        try
        {
            Text speedText;
            autoMove playerMove;
            speedText = this.Speedometer.GetComponent<Text>();
            playerMove = this.player.GetComponent<autoMove>();
            int playerSpeed = playerMove.GetSpeed();
            speedText.text = playerSpeed.ToString();
            this.maxSpeed = (playerSpeed > this.maxSpeed) ? playerSpeed : maxSpeed;

            if (maxSpeed > limitSpeed) {
                gameFail("Anda Melebihi Batas Kecepatan");
                speedText.text = maxSpeed.ToString();
            }
        }
        catch (Exception e) {
            Debug.Log(e.Message);
        }


        
    }

    public void gameFail(string message) {
        this.PausingGame();
        failPanel.SetActive(true);
    }
    public void ShowIntroPanel()
    {
        this.PausingGame();
        this.intropanel.SetActive(true);

    }

    public void ContinueFromIntroPanel() {
        this.ContinueGame();
        this.intropanel.SetActive(false);

    }
    public void PausingGame() {
        Time.timeScale = 0;

        this.player.GetComponent<autoMove>().isStopped = true;
    }

    public void ContinueGame() {
        Time.timeScale = 1;
        this.player.GetComponent<autoMove>().isStopped = false;
    }

    int GetTime() {

        float currentTime = Time.time;

        int timeRange = Mathf.RoundToInt(currentTime - initialTime);


        return timeRange;
    }

    public void restartScene(string sceneName) {
        SceneManager.LoadScene(sceneName);

    }

    public void Scoring() {
        int remainingSecond = this.limitSecond - this.GetTime();
        ResultBoard resultComponent = resultPanel.GetComponent<ResultBoard>();
        int resultStar = 0;
        if (remainingSecond > this.threeStarSecond) {
            resultStar = 3;
        }
        else if (remainingSecond > this.twoStarSecond)
        {
            resultStar = 2;
        }
        else
        {
            resultStar = 1;
        }
        resultPanel.SetActive(true);
        resultComponent.showStar(resultStar);
        this.SavingScore(this.level, resultStar);
        
    }

    public void SavingScore(int level, int star) {

        SaveDataController saveController = gameObject.GetComponent<SaveDataController>();
        saveController.SaveStarResult(1, level, star);
        saveController.unlockStage(1, level + 1);
    }
}
