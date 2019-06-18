using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class autoMove : MonoBehaviour {

    private GameObject thisObject;
    // Use this for initialization
    private float moveX;
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
        if (isStopped)
        {
            return new Vector3(0, 0, 0);
        }
        else {

            return new Vector3(3 * moveZ, 3 * moveY, 0);
        }
        
        
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
        
        if (Mathf.Abs(moveZ) > Mathf.Abs(brakeZ))
        {
            moveZ -= brakeZ;
        }
    }
    private void goLeft()
    {
        this.moveX -= this.turnLeftRightVelocity;
    }

    private void goRight()
    {

        this.moveX += this.turnLeftRightVelocity;
    }
    private void goNeutralForward() {
        this.moveX = 0;
    }

    public int GetSpeed() {

        if (!isStopped)
        {
            float rawSpeed = this.moveZ;
            float speedModifier = 40f / 0.3f;
            float playerSpeed = this.moveZ * speedModifier;

            return Mathf.RoundToInt(playerSpeed);

        }
        else {
            return 0;
        }   
    }
 
}
