using UnityEngine;
using System.Collections;


public class Enemy : MonoBehaviour 
{
	private bool isWalking;
	private Animator anim;
	public float speed;
	private int killValue = 100;
	private Vector3 startPos;


	// Use this for initialization
	void Start () 
	{
		startPos = transform.position;
		isWalking = true;
		anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("Walking", true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isWalking)
			iTween.MoveAdd (gameObject, new Vector3 (speed, 0f, 0f), 0.45f);
	}

	void OnCollisionEnter2D(Collision2D other)
	{		
		if (other.gameObject.tag == "Blue Ammo" && gameObject.tag == "Blue Enemy") // Hand
		{
			GameManager.currentScore += killValue;
			isWalking = false;
			Destroy(other.gameObject);
			anim.SetBool("Die", true);
			Destroy (gameObject, 1f);
		}
	
		if (other.gameObject.tag == "Red Ammo" && gameObject.tag == "Red Enemy") // Mouth
		{
			GameManager.currentScore += killValue;
			isWalking = false;
			Destroy(other.gameObject);
			anim.SetBool("Die", true);
			Destroy (gameObject, 1f);


		}

		if (other.gameObject.tag == "Eye Ammo" && gameObject.tag == "Eye Enemy") { // Eye
			GameManager.currentScore += killValue;
			isWalking = false;
			Destroy (other.gameObject);
			anim.SetBool ("Die", true);
			Destroy (gameObject, 1f);

		
		}
		
	 	else 
		{
			Destroy (other.gameObject);
		}
	}

}
