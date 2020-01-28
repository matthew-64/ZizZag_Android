using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

	//Making it a singleton pattern
	// = only 1 instance of ui manager
	// = Can access and function or public variavle on the other scripts
	// UiManager.instance.[variable etc...]
	public static UiManager instance;

	public GameObject zigzagPanel;
	public GameObject gameOverPanel;
	public GameObject tapText;
	public Text score;
	public Text highScore1;
	public Text highScore2;

	//Called before starting the game
	void Awake() {
		if (instance == null) {
			//instance will not be null next time
			instance = this;
		} 
	}

	// Use this for initialization
	void Start () {
		
	}

	//Called when game starts
	public void GameStart(){
		//TapText will not be shown in the screen when the game starts
		tapText.SetActive (false);
		//get animanator component <>, otherwise you can't play the animation
		zigzagPanel.GetComponent<Animator>().Play("panelUp");
	}

	//Called when game over happens
	public void GameOver(){
		//animation will play if set to active
		gameOverPanel.SetActive (true);
	}

	//Will reload scene 
	public void Reset() {
		//Can pass 0 since there is only 1 scene
		//can also br nsme of scene in the ()
		SceneManager.LoadScene (0);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
