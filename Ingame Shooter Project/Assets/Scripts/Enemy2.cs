using UnityEngine;
using System.Collections;


public class Enemy2 : MonoBehaviour 
{
	private bool isWalking;
	private Animator anim;
	public float speed2;
	private int killValue = 100;
	private Vector3 startPos;
	// Use this for initialization
	void Start () 
	{
		startPos = transform.position;
		isWalking = true;
		anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("Walking", true);
		getRandSpeed ();

	}
	void reStart(){
		isWalking = true;
		anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("Walking", true);
		getRandSpeed ();
		iTween.MoveAdd (gameObject, startPos, 0.45f);
	}
	// Update is called once per frame
	void Update ()
	{
		if(isWalking)
			iTween.MoveAdd (gameObject, new Vector3 (speed2, 0f, 0f), 0.45f);
	}
	void getRandSpeed(){
		speed2 = (float)Random.Range(-0.15f, -0.6f);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		
		if (other.gameObject.tag == "Eye Ammo" && gameObject.tag == "Eye Enemy") { // Eye
			GameManager.currentScore += killValue;
			isWalking = false;
			Destroy (other.gameObject);
			anim.SetBool ("Die", true);
			Destroy (gameObject, 1f);
	
		} else {
			Destroy (other.gameObject);
		}
	}

}
