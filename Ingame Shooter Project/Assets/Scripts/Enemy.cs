using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	private bool isWalking;
	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		isWalking = true;
		anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("Walking", true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isWalking)
			iTween.MoveAdd (gameObject, new Vector3 (-0.15f, 0f, 0f), 0.45f);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Red Ammo" && gameObject.tag == "Red Enemy")
		{
			isWalking = false;
			Destroy(other.gameObject);
			anim.SetBool("Die", true);
			Destroy (gameObject, 1f);
		}
		
		if (other.gameObject.tag == "Blue Ammo" && gameObject.tag == "Blue Enemy") 
		{
			isWalking = false;
			Destroy(other.gameObject);
			anim.SetBool("Die", true);
			Destroy (gameObject, 1f);
		}
		
		if (other.gameObject.tag == "Eye Ammo" && gameObject.tag == "Eye Enemy") 
		{
			isWalking = false;
			Destroy(other.gameObject);
			anim.SetBool("Die", true);
			Destroy (gameObject, 1f);
		}
	}

}
