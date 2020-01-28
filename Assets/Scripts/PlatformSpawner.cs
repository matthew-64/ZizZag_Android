using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public GameObject platform;
	public GameObject diamond;

	Vector3 lastPos;
	float size;
	public bool gameOver;

	// Use this for initialization
	void Start () {
		lastPos = platform.transform.position;

		//Size of object so we can calculate position of next object
		size = platform.transform.localScale.x;

		for (int i = 0; i < 10; i++) {
			SpawnPlatforms ();
		}
		//(function, time to wait, time to repeat function again and again after inital call)
		InvokeRepeating ("SpawnPlatforms", 2f, 0.2f);
	}
	
	// Update is called once per frame
	void Update() {
		if (gameOver) {
			CancelInvoke("SpawnPlatforms");
		}
	}

	void SpawnPlatforms(){
		int rand = Random.Range (0, 6);
		if (rand < 3) {
			SpawnX ();
		} else {
			SpawnZ ();
		}
	}

	void SpawnX() {
		Vector3 pos = lastPos;
		pos.x += size; 

		//lastPos is updated
		lastPos = pos;

		//(object, position, at which rotation [there is no rotation])
		Instantiate (platform, pos, Quaternion.identity);

			int rand = Random.Range (0, 10);
		if (rand < 1) {
			//(object, position, rotation)
			Instantiate(diamond, new Vector3(pos.x, pos.y+ 1, pos.z), diamond.transform.rotation);
		}
	}

	void SpawnZ() {
		Vector3 pos = lastPos;
		pos.z += size;
		lastPos = pos;
		Instantiate (platform, pos, Quaternion.identity);

		int rand = Random.Range (0, 10);
		if (rand < 1) {
			Instantiate(diamond, new Vector3(pos.x, pos.y+1, pos.z), diamond.transform.rotation);
		}

	}
		
}
