using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shoot1 : MonoBehaviour
{
	public AudioSource throwAudio;

	public float force = 4.0f;
	public int samples = 25;
	public float spacing = 0.1f;

	private Vector3 offset;
	private Vector3 home;
	private Rigidbody2D rb;
	private GameObject[] argo;

	public GameObject primitiveME;
	public GameObject sample;

	private Animator anim;
	private Animator scientistAnim;
	private GameObject scientistGo;

	private SpriteRenderer sRenderer;
	
	void Start () 
	{
		GameManager.ammoLoaded = true;
		sRenderer = gameObject.GetComponent<SpriteRenderer> ();
		anim = gameObject.GetComponent<Animator> ();
		rb = rigidbody2D;

		scientistGo = GameObject.FindGameObjectWithTag ("Scientist");
		scientistAnim = scientistGo.GetComponent<Animator> ();
		AudioSource[] audios = scientistGo.GetComponents<AudioSource> ();
		throwAudio = audios [0];

		home = transform.position;

		argo = new GameObject[samples];
		for (var i = 0; i < argo.Length; i++)
		{
			argo[i] = GameObject.Instantiate (sample) as GameObject;
		}
	}
	
	void OnMouseDown()
	{
		sRenderer.enabled = false;  	 
		Instantiate (primitiveME, transform.position, Quaternion.identity); 

		scientistAnim.SetTrigger ("dragging");
		
		var v3 = Input.mousePosition;
		v3.z = transform.position.z - Camera.main.transform.position.z;
		v3 = Camera.main.ScreenToWorldPoint(v3);
		offset = transform.position - v3;
	}
	
	void OnMouseDrag() {
		var v3 = Input.mousePosition;
		v3.z = transform.position.z - Camera.main.transform.position.z;
		v3 = Camera.main.ScreenToWorldPoint(v3);
		transform.position = v3 + offset;
		DisplayIndicators();
	}
	
	void OnMouseUp()
	{
		GameManager.ammoLoaded = false;
		scientistAnim.SetTrigger ("threw");  
		rb.isKinematic = false;
		rb.velocity = force * (home - transform.position);

		for (int i = 0; i < argo.Length; i++){
			Destroy(argo[i]);
		}
		sRenderer.enabled = true;
		throwAudio.Play ();
	}
	
	void DisplayIndicators() {
		argo[0].transform.position = transform.position;
		var v3 = transform.position;
		var y = (force * (home - transform.position)).y;
		var t = 0f;
		v3.y = 0f;
		for (var i = 1; i < argo.Length; i++) {
			v3 +=  force * (home - transform.position) * spacing;
			t += spacing;
			v3.y = y * t + 0.5f * Physics.gravity.y * t * t + transform.position.y;
			argo[i].transform.position = v3;
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground1")
		{
			Destroy(gameObject);
		}
	}
}