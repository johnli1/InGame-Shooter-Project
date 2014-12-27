using UnityEngine;
using System.Collections;


public class Enemy1 : MonoBehaviour 
{
	public GameObject redAmmo;
	private bool isWalking;
	private Animator anim;
	public float speed1;
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
		anim.SetBool("Die", false);
		anim.SetBool ("Walking", true);
		getRandSpeed ();
		Instantiate (redAmmo, new Vector2 (-5.8f, -1.85f), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isWalking)
			iTween.MoveAdd (gameObject, new Vector3 (speed1, 0f, 0f), 0.45f);
	}
	void getRandSpeed(){
		speed1 = (float)Random.Range(-0.15f, -0.6f);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Red Ammo" && gameObject.tag == "Red Enemy") // Mouth
		{
			GameManager.currentScore += killValue;
			isWalking = false;
			Destroy(other.gameObject);
			anim.SetBool("Die", true);
			//reStart();
			Destroy (gameObject, 1f);

		}
		 else {
			Destroy (other.gameObject);
		}
	}

}
