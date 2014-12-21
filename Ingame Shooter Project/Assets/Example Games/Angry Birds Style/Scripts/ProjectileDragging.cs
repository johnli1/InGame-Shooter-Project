using UnityEngine;

public class ProjectileDragging : MonoBehaviour {
	public float maxStretch = 3.0f;
	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack;  
	public GameObject blackPrefab;
	

	private SpringJoint2D spring;
	private Transform catapult;
	private Ray rayToMouse;
	private Ray leftCatapultToProjectile;
	private float maxStretchSqr;
	private float circleRadius;
	private bool clickedOn;
	private Vector2 prevVelocity;

	private GameObject[] sphereArr;
	private Vector3 startLocation;
	public int samples = 25;
	public float spacing = 0.05f;
	
	void Awake () {
		spring = GetComponent <SpringJoint2D> (); //get the connected SpringJoint
		catapult = spring.connectedBody.transform; //get catapult from SpringJoint
	}
	
	void Start () {


		LineRendererSetup (); 
		rayToMouse = new Ray(catapult.position, Vector3.zero);
		leftCatapultToProjectile = new Ray(catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqr = maxStretch * maxStretch;
		CircleCollider2D circle = collider2D as CircleCollider2D;
		circleRadius = circle.radius;



		sphereArr = new GameObject[samples];
		for(int i = 0; i < sphereArr.Length; i++)
		{
			GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			go.collider.enabled = false;
			go.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
			sphereArr[i] = go;
		}
		startLocation = transform.position;
	}
	
	void Update () {
		if (clickedOn)
			Dragging ();
		
		if (spring != null) {
			if (!rigidbody2D.isKinematic && prevVelocity.sqrMagnitude > rigidbody2D.velocity.sqrMagnitude) {
				Destroy (spring);
				rigidbody2D.velocity = prevVelocity;
			}
			
			if (!clickedOn)
				prevVelocity = rigidbody2D.velocity;
			
			LineRendererUpdate ();
			
		} else {
			catapultLineFront.enabled = false;
			catapultLineBack.enabled = false;
		}
	}
	
	void LineRendererSetup () {
		catapultLineFront.SetPosition(0, catapultLineFront.transform.position);
		catapultLineBack.SetPosition(0, catapultLineBack.transform.position);
		
		catapultLineFront.sortingLayerName = "Foreground";
		catapultLineBack.sortingLayerName = "Foreground";
		
		catapultLineFront.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1;
	}
	
	void OnMouseDown () {
		spring.enabled = false;
		clickedOn = true;
		DisplayIndicators ();
	}
	
	void OnMouseUp () {
		spring.enabled = true;
		rigidbody2D.isKinematic = false;
		clickedOn = false;
	}

	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector2 catapultToMouse = mouseWorldPoint - catapult.position;
		
		if (catapultToMouse.sqrMagnitude > maxStretchSqr) {
			rayToMouse.direction = catapultToMouse;
			mouseWorldPoint = rayToMouse.GetPoint(maxStretch);
		}
		
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

	void LineRendererUpdate () {
		Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
		leftCatapultToProjectile.direction = catapultToProjectile;
		Vector3 holdPoint = leftCatapultToProjectile.GetPoint(catapultToProjectile.magnitude + circleRadius);
		catapultLineFront.SetPosition(1, holdPoint);
		catapultLineBack.SetPosition(1, holdPoint);
	}
	public void ChangeToBlack()
	{
		Instantiate (blackPrefab, new Vector2 (-7f, -2f), Quaternion.identity);
	}
	void DisplayIndicators()
	{
		sphereArr [0].transform.position = transform.position;
		Vector3 v3 = startLocation;
		float y = (3f * (startLocation - Input.mousePosition)).y;
		float t = 0.0f;
		v3.y = 0.0f;
		for (var i = 1; i < sphereArr.Length; i++)
		{
			v3 =  3f * (startLocation - Input.mousePosition) * spacing;
			t = spacing;
			v3.y = y * t + 0.5f * Physics.gravity.y * t * t + Input.mousePosition.y;
			sphereArr[i].transform.position = v3;
		}
	}	
}