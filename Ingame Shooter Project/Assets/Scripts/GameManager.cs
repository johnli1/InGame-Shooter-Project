using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject redAmmo;
	public GameObject blueAmmo;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadRedAmmo()
	{
		Instantiate (redAmmo, new Vector2 (-6f, -0.025f), Quaternion.identity);
	}

	public void LoadBlueAmmo()
	{
		Instantiate (blueAmmo, new Vector2 (-6f, -0.025f), Quaternion.identity);
	}
}
