using UnityEngine;
using System.Collections;

public class PrimitiveGOScript : MonoBehaviour {

	public Vector3 pos;
	private GameObject posGo;
	void Start () 
	{
		posGo = GameObject.Find ("/Scientist/projectilePos");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (posGo != null)
		{
			gameObject.transform.position = posGo.transform.position;
			print("NULL");
		}
		if (GameManager.ammoLoaded == false)
						Destroy (gameObject);
	}
}
