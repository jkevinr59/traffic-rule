using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour {

    private Vector3 offset;
    private GameObject cameraObject;
    public GameObject playerObject;
    private autoMove playerMove;
    //private float zVector;
	// Use this for initialization
	void Start () {
        cameraObject = this.gameObject;
        offset = cameraObject.transform.position - playerObject.transform.position;
        playerMove = playerObject.GetComponent<autoMove>();
	}
	
	// Update is called once per frame
	void LateUpdate () {

        //if (Input.GetKey(KeyCode.W))
        //{

        //    yVector = 1f;
        //}

        //if (Input.GetKey(KeyCode.S))
        //{
        //    yVector = -1f;
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    xVector = +1f;
        //}

        //if (Input.GetKey(KeyCode.A))
        //{
        //    xVector = -1f;
        //}

        cameraObject.transform.position = playerObject.transform.position + offset - playerMove.getPlayerVector();
    }

   
}
