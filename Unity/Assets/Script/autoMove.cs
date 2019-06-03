using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class autoMove : MonoBehaviour {

    private GameObject thisObject;
    // Use this for initialization
    public float moveX;
    private float moveY;
    private float moveZ;
    private float turnLeftRightVelocity = 0.1f;
    public float maxSpeedX;
    public float maxSpeedY;
    public float maxSpeedZ;
    public float brakeX;
    public float brakeY;
    public float brakeZ;
    public float accelerateX;
    public float accelerateY;
    public float accelerateZ;
    public GameObject buttonBrake;
    public GameObject buttonLeft;
    public GameObject buttonRight;
    public bool isStopped;
    void Start () {
        thisObject = this.gameObject;
        moveX = moveY = moveZ = 0f;
        isStopped = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (doBrake())
        {
            goBrake();

        }
        else {
            if (Mathf.Abs(moveZ + accelerateZ)  < Mathf.Abs(maxSpeedZ)) {
                moveZ += accelerateZ;
            }
            if (Mathf.Abs(moveY + accelerateY) < Mathf.Abs(maxSpeedY))
            {
                moveY += accelerateY;
            }
            if (Mathf.Abs(moveX + accelerateX) < Mathf.Abs(maxSpeedX))
            {
                moveX += accelerateX;
            }          
        }
        goNeutralForward();
        if (doRight()) {
            goRight();
        }
        if (doLeft())
        {
            goLeft();
        }
        Vector3 moveVector = new Vector3(moveX,moveY,moveZ);
        if (isStopped == false) {
            thisObject.transform.Translate(moveVector);
        }
        
	}

    public Vector3 getPlayerVector() {
        return new Vector3(3 * moveX, 3 * moveY, 0);
    }

    private bool doBrake() {
        bool case1 = Input.GetKey(KeyCode.Space);
        bool case2 = false;
        if (buttonBrake) {
            case2 = buttonBrake.GetComponent<ButtonHandler>().isPressed;
        }
        
        return case1||case2;
    }

    private bool doLeft() {
        bool case1 = Input.GetKey(KeyCode.A);
        bool case2 = false;
        if (buttonLeft)
        {
            case2 = buttonLeft.GetComponent<ButtonHandler>().isPressed;
        }
        return case1 || case2;
    }

    private bool doRight() {
        bool case1 = Input.GetKey(KeyCode.D);
        bool case2 = false;
        if (buttonRight)
        {
            case2 = buttonRight.GetComponent<ButtonHandler>().isPressed;
        }
        return case1 || case2;
    }
    private void goBrake() {
        
        if (Mathf.Abs(moveX) > Mathf.Abs(brakeX))
        {
            moveX -= brakeX;
        }
    }
    private void goLeft()
    {
        this.moveZ -= this.turnLeftRightVelocity;
    }

    private void goRight()
    {

        this.moveZ += this.turnLeftRightVelocity;
    }
    private void goNeutralForward() {
        this.moveZ = 0;
    }

 
}
