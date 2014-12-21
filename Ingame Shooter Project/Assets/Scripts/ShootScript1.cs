using UnityEngine;
using System.Collections;

public class ShootScript1 : MonoBehaviour
{
	public float force = 4.0f;
	public int samples = 25;
	public float spacing = 0.05f;

	private Vector3 offset;
	private Vector3 startLocation;
	private Rigidbody2D rb;
	private GameObject[] sphereArr;
	private Vector3 aim;

	void Start()
	{
		startLocation = transform.position;
		rb = rigidbody2D;
		sphereArr = new GameObject[samples];
		for(int i = 0; i < sphereArr.Length; i++)
		{
			GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			go.collider.enabled = false;
			go.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
			sphereArr[i] = go;
		}
	}
	void Update()
	{
		if (Input.GetMouseButtonDown (0))
		{
			rb.isKinematic = false;
			rb.velocity = -(force * (startLocation - aim));
			Invoke ("ReturnStartLocation", 2.0f);
		}
		Aim ();
	}
	void ReturnStartLocation()
	{
		transform.position = startLocation;
		rb.velocity = Vector3.zero;
		rb.isKinematic = true;
	}

	void Aim()
	{
		Vector3 v3 = Input.mousePosition;
		v3.z = transform.position.z - Camera.main.transform.position.z;
		v3 = Camera.main.ScreenToWorldPoint(v3);
//		offset = transform.position - v3;
		aim = v3 + offset;
		DisplayIndicators();
	}

	void DisplayIndicators()
	{
		sphereArr [0].transform.position = transform.position;
		Vector3 v3 = startLocation;
		float y = (force * (startLocation - aim)).y;
		float t = 0.0f;
		v3.y = 0.0f;
		for (var i = 1; i < sphereArr.Length; i++)
		{
			v3 -=  force * (startLocation - aim) * spacing;
			t -= spacing;
			v3.y = y * t + 0.5f * Physics.gravity.y * t * t + aim.y;
			sphereArr[i].transform.position = v3;
		}
	}
}
//	void OnMouseDown()
//	{
//		Vector3 v3 = Input.mousePosition;
//		v3.z = transform.position.z - Camera.main.transform.position.z;
//		v3 = Camera.main.ScreenToWorldPoint (v3);
//		offset = transform.position - v3;
//	}
//
//	void OnMouseDrag()
//	{
//		Vector3 v3 = Input.mousePosition;
//		v3.z = transform.position.z - Camera.main.transform.position.z;
//		v3 = Camera.main.ScreenToWorldPoint(v3);
//		transform.position = v3 + offset;
//		DisplayIndicators();
//	}
//
//	void OnMouseUp()
//	{
//		rb.isKinematic = false;
//		rb.velocity = force * (startLocation - transform.position);
//		Invoke ("ReturnStartLocation", 2.0f);
//	}
//








//	public float moveSpeed;
//	public float yForce;
//	public float xForce;
//	public float dampenForce;
//
//	void Update()
//	{
//		float h = Input.GetAxis ("Horizontal") * moveSpeed;
//		transform.Translate (Vector3.right * h);
//
//		if (Input.GetKey(KeyCode.Space))
//		{
//			xForce += 5.0f;
//		}
//
//		if (Input.GetKeyUp(KeyCode.Space))
//		{
//			rigidbody2D.gravityScale = 1f;
//			rigidbody2D.AddForce(new Vector2(xForce - dampenForce, yForce));
//			xForce = 0f;
//		}
//
//		if (Input.GetKey(KeyCode.Q))
//		{
//			transform.Rotate(new Vector3(0, 0, 30.0f) * Time.deltaTime);
//			dampenForce += 4f;
//			yForce += 3.5f;
//		}
//
//		if (Input.GetKey(KeyCode.E))
//		{
//			transform.Rotate(new Vector3(0, 0, -30.0f) * Time.deltaTime);
//			yForce -= 3.5f;
//			dampenForce -= 4f;
//		}
//	}



