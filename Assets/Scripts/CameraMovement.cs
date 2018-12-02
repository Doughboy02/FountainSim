using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float moveSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)) transform.position += transform.forward * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.A)) transform.position -= transform.right * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.S)) transform.position -= transform.forward * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.D)) transform.position += transform.right * Time.deltaTime * moveSpeed;
       // if (Input.GetKey(KeyCode.Q)) transform.RotateAround(rotatePoint.transform.position, Vector3.up, Time.deltaTime * rotateSpeed);
       // if (Input.GetKey(KeyCode.E)) transform.RotateAround(rotatePoint.transform.position, Vector3.up, -Time.deltaTime * rotateSpeed);
    }
}
