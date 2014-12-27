using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
	
	//variables for catapult
	public float maxStretch = 2.0f;
	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack;

	private GameObject catapultLineFrontGO;
	private GameObject catapultLineBackGO;
	
	private SpringJoint2D spring;
	private Transform catapult;
	private Ray rayToMouse;
	private Ray leftCatapultToProjectile;
	private float maxStretchSqr;
	private float circleRadius;
	private Vector2 prevVelocity;
	private bool clickedOn = false;
	
	//prediction line
	int samples = 25;
	float spacing = 0.1f;
	private GameObject[] line;
	private Vector3 home;
	public int force = 6;
	private float actualForce = 0;
	

	
	void Awake(){

		spring = GetComponent<SpringJoint2D> ();
		catapultLineBackGO = GameObject.Find ("Catapult");
		catapultLineFrontGO = GameObject.Find ("CatapultFront");

		catapultLineBack = catapultLineBackGO.GetComponent <LineRenderer>();
		catapultLineFront = catapultLineFrontGO.GetComponent <LineRenderer>();
		spring.connectedBody = catapultLineBackGO.GetComponent<Rigidbody2D> ();

		catapult = spring.connectedBody.transform;
	}
	
	// Use this for initialization
	void Start () {



		LineRendererSetup ();
		rayToMouse = new Ray (catapult.position, Vector3.zero);
		leftCatapultToProjectile = new Ray (catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		CircleCollider2D circle = collider2D as CircleCollider2D;
		circleRadius = circle.radius;
		
		line = new GameObject[samples];
		for (int i = 0; i < line.Length; i++){
			var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			go.collider.enabled = false;
			go.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
			line[i] = go;
		}
		
		home = transform.position;
	}
	
	void FixedUpdate(){
		
		if (clickedOn)
			DisplayLine ();
	}

	
	// Update is called once per frame
	void Update () {

		Vector2 distanceFromCatapult = new Vector2(transform.position.x - catapult.position.x, transform.position.y - catapult.position.y);
		actualForce = force + distanceFromCatapult.magnitude;

		if (clickedOn)
			Dragging ();
		
		if (spring != null) {
			if(!rigidbody2D.isKinematic && prevVelocity.sqrMagnitude > rigidbody2D.velocity.sqrMagnitude){
				Destroy (spring);
				rigidbody2D.velocity = prevVelocity;
				for (int i = 0; i < line.Length; i++){
					Destroy(line[i]);
				}
			}
			if (!clickedOn)
				prevVelocity = rigidbody2D.velocity;
			
			LineRendererUpdate();
		} else {
			catapultLineFront.enabled = false;
			catapultLineBack.enabled = false;
		}
		
	}
	
	void LineRendererSetup(){
		catapultLineFront.SetPosition (0, catapultLineFront.transform.position);
		catapultLineBack.SetPosition (0, catapultLineBack.transform.position);
		
		
		catapultLineFront.sortingLayerName = "Foreground";
		catapultLineBack.sortingLayerName = "Foreground";
		
		
		catapultLineFront.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1;
		
	}
	
	void OnMouseDown(){
		spring.enabled = false;
		clickedOn = true;
	}
	
	void OnMouseUp(){
		spring.enabled = true;
		rigidbody2D.isKinematic = false;
		clickedOn = false;

	}
	
	void Dragging(){
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;
		
		if (catapultToMouse.sqrMagnitude > maxStretchSqr) {
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
		}
		
		mouseWorldPoint.z = 0.0f;
		transform.position = mouseWorldPoint;
		
	}
	
	void LineRendererUpdate(){
		
		Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
		leftCatapultToProjectile.direction = catapultToProjectile;
		Vector3 holdPoint = leftCatapultToProjectile.GetPoint (catapultToProjectile.magnitude + circleRadius);
		catapultLineFront.SetPosition (1, holdPoint);
		catapultLineBack.SetPosition (1, holdPoint);
		
	}
	
	void DisplayLine()
	{
		line [0].transform.position = transform.position;
		Vector3 v3 = transform.position;
		float y = (actualForce * (home - transform.position)).y;
		float t = 0.0f;
		v3.y = 0.0f;
		
		for (int i = 1; i < line.Length; i++) {
			v3 += actualForce * (home - transform.position) * spacing;
			t += spacing;
			v3.y = y * t + 0.5f * Physics2D.gravity.y * t * t + transform.position.y;
			line[i].transform.position = v3;
		}
	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Ground")
		{
			Destroy(gameObject, 1f);
		}
	}
}