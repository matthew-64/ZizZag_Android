using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	//Need to assign the ball here so the camera can follow the ball
	public GameObject ball;

	//distance between camera and ball
	Vector3 offset;

	//rate at which the camera will change its osition to follow the ball
	//made public so you can midify from inspector
	public float lerpRate;

	public bool gameOver;

	// Use this for initialization
	void Start () {
		//ball position - camera position = distance between ball and camera.
		offset = ball.transform.position - transform.position;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameOver) {
			Follow ();
		}
	}

	void Follow() {
		//cant directly modify transform.position values
		Vector3 pos = transform.position;
		Vector3 targetPos = ball.transform.position - offset;
		//Goes from one vaue to another with the assigned lerp rate
		//*Time.deltaTime = same rate regardless of speed of computer
		pos = Vector3.Lerp(pos, targetPos, lerpRate*Time.deltaTime);
		transform.position = pos;
	}
}
