using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMovement : MonoBehaviour {

    [SerializeField]
    Vector3 v3Force;
    [SerializeField]
    KeyCode keyPositive;
    [SerializeField]
    KeyCode keyNegative;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
        if (Input.GetKey(keyPositive)){
        GetComponent<Rigidbody>().velocity += v3Force;
	}

        if(Input.GetKey(keyNegative)){

GetComponent<Rigidbody>().velocity -= v3Force;
}
    }
    }