using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Enemy : MonoBehaviour 
{
	public AudioSource scienistHitAudio;
	private GameObject scientistRef;

	private AudioSource enemyDeathAudio;

	public bool isWalking;
	private Animator anim;
	public float speed;
	private int killValue = 100;
	private Vector3 startPos;


	// Use this for initialization
	void Start () 
	{
		scientistRef = GameObject.FindGameObjectWithTag ("Scientist");
		AudioSource[] audios = scientistRef.GetComponents<AudioSource> ();
		scienistHitAudio = audios [1];

		enemyDeathAudio = GetComponent<AudioSource> ();

		startPos = transform.position;
		isWalking = true;
		anim = gameObject.GetComponent<Animator> ();
		anim.SetBool ("Walking", true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isWalking)
		{
			iTween.MoveAdd (gameObject, new Vector3 (speed, 0f, 0f), 0.2f);
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Scientist")
		{
			isWalking = false;
			StartCoroutine (MakeDamage());
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{		

		if (other.gameObject.tag == "Blue Ammo" && gameObject.tag == "Blue Enemy") // Hand
		{
			GameManager.currentScore += killValue;
			isWalking = false;
			enemyDeathAudio.Play();
			Destroy(other.gameObject);
			anim.SetBool("Die", true);
			Destroy (gameObject, 1f);
		}
	
		if (other.gameObject.tag == "Red Ammo" && gameObject.tag == "Red Enemy") // Mouth
		{
			GameManager.currentScore += killValue;
			enemyDeathAudio.Play ();
			isWalking = false;
			Destroy(other.gameObject);
			anim.SetBool("Die", true);
			Destroy (gameObject, 1f);


		}

		if (other.gameObject.tag == "Eye Ammo" && gameObject.tag == "Eye Enemy") { // Eye
			GameManager.currentScore += killValue;
			enemyDeathAudio.Play();
			isWalking = false;
			Destroy (other.gameObject);
			anim.SetBool ("Die", true);
			Destroy (gameObject, 1f);

		
		}
		if (other.gameObject.tag == "Ground1")
		{
			rigidbody2D.AddForce(Vector2.up * 300f * Time.deltaTime, ForceMode2D.Impulse);
		}
	 	else 
		{
			Destroy (other.gameObject);
		}
	}
	IEnumerator MakeDamage()
	{
		scienistHitAudio.Play ();
		GameManager.currentHealth -= 1;
		yield return new WaitForSeconds (2);
		GameManager.currentHealth -= 1;
		scienistHitAudio.Play ();
		yield return new WaitForSeconds (2);
		scienistHitAudio.Play ();
		GameManager.currentHealth -= 1;
		yield return new WaitForSeconds (2);
		scienistHitAudio.Play ();
		GameManager.currentHealth -= 1;
		yield return new WaitForSeconds (2);
		scienistHitAudio.Play ();
		GameManager.currentHealth -= 1;
	}

}
