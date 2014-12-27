using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreUpdate : MonoBehaviour {
	Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + GameManager.currentScore;
	}
}
