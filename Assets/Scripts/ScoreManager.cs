using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;
	public int score;
	public int highScore;

	void Awake() {
		//creats singleton instance of score manager
		if (instance == null) {
			instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		score = 0;
		//score will be saved on computer under the score key "score"
		PlayerPrefs.SetInt("score", score);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void incrementScore() {
		score++;
	}

	public void startScore() {
		//(function, after how much time, for every x seconds)
		InvokeRepeating ("incrementScore", 0.1f, 0.5f);
	}

	//cancels invoking repeating our incermentScore function
	public void StopScore() {
		CancelInvoke ("startScore");
		//saves score
		PlayerPrefs.SetInt ("score", score);

		//check if you have a high score
		if (PlayerPrefs.HasKey ("highScore")) {
			if (score > PlayerPrefs.GetInt ("highScore")) {
				PlayerPrefs.SetInt ("highScore", score);
			}
		} else {
			PlayerPrefs.SetInt ("highScore", score);
		}
	}
}