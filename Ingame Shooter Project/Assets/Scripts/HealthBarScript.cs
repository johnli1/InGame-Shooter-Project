using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	private Animator anim;
	private int currentHealth;
	// Use this for initialization
	void Start () 
	{
		currentHealth = GameManager.currentScore;
		anim = gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		anim.SetInteger ("currentHealthBar", GameManager.currentHealth);
	}
}
