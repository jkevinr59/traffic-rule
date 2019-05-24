using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMove : MonoBehaviour {

    private GameObject thisObject;
    // Use this for initialization
    public float moveX;
    public float moveY;
    public float moveZ;
    private float brake;
    private float accelerate;
    void Start () {
        thisObject = this.gameObject;
        accelerate = -0.01f;
        brake = -0.02f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Space))
        {
            if (moveZ < 0) {
                moveZ -= brake;
            }
            
        }
        else {
            moveZ += accelerate;
        }
        Vector3 moveVector = new Vector3(moveX,moveY,moveZ);
        thisObject.transform.Translate(moveVector);
	}

    public Vector3 getPlayerVector() {
        return new Vector3(3 * moveX, 3 * moveY, 3 * moveZ);
    }
}
