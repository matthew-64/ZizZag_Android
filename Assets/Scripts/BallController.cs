using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public GameObject particle;

	//Even if private, it will show up in the editator so it will shopw in the editor
	[SerializeField]
	private float speed;
	bool started;
	bool gameOver;

	Rigidbody rb;

	//Awake is called before start so we can get access to the rigid body
	void Awake(){
		//Gives access to Ridgid ody compont this is asstahed to the game object
		//Basically, get RB that is attached to the game object (Ball)
		rb = GetComponent<Rigidbody>();
	}

	// Use this for initialization
	void Start () {
		started = false;
		gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {


		if (!started) {
			if (Input.GetMouseButtonDown(0)) {
				rb.velocity = new Vector3 (0, 0, 0);
				started = true;

				GameManager.instance.StartGame ();
			}
		}
		//In order to read mouse click
		//0 mouse button = left click
		if (Input.GetMouseButtonDown(0) && !gameOver) {
			SwitchDirection();
		}

		Debug.DrawRay (transform.position, Vector3.down, Color.red);

		//Raycasting
		//If the ray is not touching the platform, the ball falls down = game over
		//origional position, direction of ray, size of ray
		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			gameOver = true;
			rb.velocity = new Vector3 (0, -25f, 0);

			//Camera.main = main camera
			//GetComponent<CameraFollow> = can get access to CameraFollow.cs public variables (gameOver for example)
			//in CameraFollow.cs, the camera won't follow when: gameOver = true
			Camera.main.GetComponent<CameraFollow>().gameOver = true;

			GameManager.instance.GameOver ();
		}

	}

	void SwitchDirection() {
		if (rb.velocity.z > 0) {
			rb.velocity = new Vector3 (speed, 0, 0);
		} else {
			rb.velocity = new Vector3 (0, 0, speed);
		}
	}

	void OnTriggerEnter(Collider col) {
		//This will pick u the "Diamond" tag
		if (col.gameObject.tag == "Diamond") {
			//(object, position, rotation)
			GameObject tempParticle = Instantiate (particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;

			Destroy (col.gameObject);
			Destroy (tempParticle, 1.5f);
		}
	}
}