using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCube : MonoBehaviour {

    public float alwaysRotateSpeed;
    public float moveSpeed;
    public bool isMoving;
    Vector3 rotateVector;

    
	// Use this for initialization
	void Start () {
        rotateVector = new Vector3(-alwaysRotateSpeed, alwaysRotateSpeed, alwaysRotateSpeed);
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rotateVector);
    }



    
    
}
