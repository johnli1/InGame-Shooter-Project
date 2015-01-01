using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject redAmmo;
	public GameObject blueAmmo;
	public GameObject EyeAmmo;
	public static int currentScore = 0;

	public static int killCount = 0;
	public static bool ammoLoaded = false;

	public static int fullHealth = 3;
	public static int currentHealth;

	 




	// Use this for initialization
	void Start ()
	{
		currentHealth = fullHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void LoadRedAmmo()
	{
		if (ammoLoaded == false)
			Instantiate (redAmmo, new Vector2 (-7.381295f, 0.219643f), Quaternion.identity);

	}

	public void LoadBlueAmmo()
	{
		if (ammoLoaded == false)
			Instantiate (blueAmmo, new Vector2 (-7.381295f, 0.219643f), Quaternion.identity);
	}

	public void LoadEyeAmmo()
	{
		if (ammoLoaded == false)
			Instantiate (EyeAmmo, new Vector2 (-7.381295f, 0.219643f), Quaternion.identity);
	}

//	IEnumerator PlayTutorial()
//	{
//	yield return WaitForSeconds(1)
		
//	}
}
