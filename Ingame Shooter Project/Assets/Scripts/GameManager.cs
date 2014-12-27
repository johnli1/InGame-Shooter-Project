using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject redAmmo;
	public GameObject blueAmmo;
	public GameObject EyeAmmo;
	public static int currentScore = 0;


	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){

	}

	public void LoadRedAmmo()
	{
		Instantiate (redAmmo, new Vector2 (-5.8f, -1.85f), Quaternion.identity);
	}

	public void LoadBlueAmmo()
	{
		Instantiate (blueAmmo, new Vector2 (-5.8f, -01.85f), Quaternion.identity);
	}

	public void LoadEyeAmmo()
	{
		Instantiate (EyeAmmo, new Vector2 (-5.8f, -01.85f), Quaternion.identity);
	}
}
