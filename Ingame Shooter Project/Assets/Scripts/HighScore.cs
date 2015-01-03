using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {
	Text text;
	
	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameManager.HighScoreFlag){
			text.text = "New HighScore!: " + PlayerPrefs.GetInt("HighScore");
		}
		else{
			text.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
		}
	}
}
