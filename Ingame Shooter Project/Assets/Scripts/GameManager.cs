using UnityEngine;
using System.Collections;

using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	public GameObject redAmmo;
	public GameObject blueAmmo;
	public GameObject EyeAmmo;
	public static int currentScore = 0;

	public static int killCount = 0;
	public static bool ammoLoaded = false;

	public static int fullHealth = 3;
	public static int currentHealth;

	private GameObject buttonHand, buttonMouth, buttonEye;
	private Animator handsAnim, mouthAnim, EyesAnim;

	public GameObject handEnemy, mouthEnemy, eyeEnemy;

	private GameObject defeatPanel;

	// Use this for initialization
	void Start ()
	{
		currentHealth = fullHealth;
		defeatPanel = GameObject.FindGameObjectWithTag ("Defeat Panel");
		defeatPanel.SetActive (false);
		buttonHand = GameObject.FindGameObjectWithTag ("ButtonHand");
		buttonMouth = GameObject.FindGameObjectWithTag("ButtonMouth");
		buttonEye = GameObject.FindGameObjectWithTag ("ButtonEye");
		handsAnim = buttonHand.GetComponent<Animator> ();
		mouthAnim = buttonMouth.GetComponent<Animator> ();
		EyesAnim = buttonEye.GetComponent<Animator> ();

		StartCoroutine (PlayTutorial());
		currentHealth = fullHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(currentHealth == 0)
		{
			defeatPanel.SetActive(true);
		}
	}

	public void LoadRedAmmo()
	{
		if(Time.timeScale != 1 && mouthAnim.GetBool("goHighlighted") == true)
		{
			Time.timeScale = 1f;
			mouthAnim.SetBool("goHighlighted", false);
		}

		if (ammoLoaded == false)
			Instantiate (redAmmo, new Vector2 (-7.381295f, 0.219643f), Quaternion.identity);
	}

	public void LoadBlueAmmo()
	{
		if(Time.timeScale != 1 && handsAnim.GetBool("goHighlighted") == true)
		{
			Time.timeScale = 1f;
			handsAnim.SetBool("goHighlighted", false);
		}

		if (ammoLoaded == false)
			Instantiate (blueAmmo, new Vector2 (-7.381295f, 0.219643f), Quaternion.identity);
	}

	public void LoadEyeAmmo()
	{
		if(Time.timeScale != 1 && EyesAnim.GetBool("goHighlighted") == true)
		{
			Time.timeScale = 1f;
			EyesAnim.SetBool("goHighlighted", false);
		}

		if (ammoLoaded == false)
			Instantiate (EyeAmmo, new Vector2 (-7.381295f, 0.219643f), Quaternion.identity);
	}

	IEnumerator PlayTutorial()
	{
		buttonHand.SetActive (false);
		buttonEye.SetActive (false);
		buttonMouth.SetActive (false);
		yield return new WaitForSeconds (5.5f);
		buttonHand.SetActive (true);
		handsAnim.SetBool ("goHighlighted", true);
		Time.timeScale = 0.0f;
		float pauseEndTime = Time.realtimeSinceStartup + 3;
		while (Time.realtimeSinceStartup < pauseEndTime)
		{
			yield return 0;
		}
		handsAnim.SetBool ("goHighlighted", false);
		Time.timeScale = 1;

		yield return new WaitForSeconds (8);
		buttonMouth.SetActive (true);
		mouthAnim.SetBool ("goHighlighted", true);
		Time.timeScale = 0.0f;
		float pauseEndTime1 = Time.realtimeSinceStartup + 3;
		while (Time.realtimeSinceStartup < pauseEndTime1)
		{
			yield return 0;
		}
		mouthAnim.SetBool ("goHighlighted", false);
		Time.timeScale = 1;

		yield return new WaitForSeconds (10f);
		buttonEye.SetActive (true);
		EyesAnim.SetBool ("goHighlighted", true);
		Time.timeScale = 0.0f;
		float pauseEndTime2 = Time.realtimeSinceStartup + 3;
		while (Time.realtimeSinceStartup < pauseEndTime2)
		{
			yield return 0;
		}
		EyesAnim.SetBool ("goHighlighted", false);
		Time.timeScale = 1;
	}
	public void RestartLevel()
	{
		Application.LoadLevel (0);
	}
}
