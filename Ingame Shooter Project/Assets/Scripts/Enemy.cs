using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		iTween.MoveAdd (gameObject, new Vector3 (-0.35f, 0f, 0f), 0.75f);
	}


}
