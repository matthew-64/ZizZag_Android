using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	//singleton instance
	public static GameManager instance;

	public bool gameOver;

	void Awake() {
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		gameOver = false;
		//Now look at Update() in BallController.cs
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartGame() {
		//This is why I created a singleton pattern
		//Can access any public function from the UiManager
		UiManager.instance.GameStart ();
		ScoreManager.instance.startScore ();
	}

	public void GameOver() {
		UiManager.instance.GameOver ();
		ScoreManager.instance.StopScore ();
	}
}
