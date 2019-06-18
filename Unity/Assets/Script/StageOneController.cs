using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class StageOneController : MonoBehaviour {

    public GameObject player;
    public GameObject Speedometer;
    private int maxSpeed;
	// Use this for initialization
	void Start () {
        maxSpeed = 0;
	}
	
	// Update is called once per frame
	void Update () {
        updateSpeed();
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
        }
        catch (Exception e) {
            Debug.Log(e.Message);
        }


        
    }
}
