// #pragma strict
// 
// var force = 4.0;
// var samples = 25;
// var spacing = 0.1;  // Time between samples 
// 
// private var offset : Vector3;
// private var home : Vector3;
// private var rb : Rigidbody2D;
// private var argo : GameObject[];
// 
// public var primitiveME : GameObject;
// 
// private var anim : Animator;
// private var scientistAnim : Animator;
// private var scientistGO : GameObject;
// 
// private var sRenderer : SpriteRenderer;
// 
// private var cam : GameObject;
// private var gameManagerRef : GameM
// 
// 
// function Start () 
// {
//	 sRenderer = gameObject.GetComponent(SpriteRenderer); 
//	 cam = Camera.main;
//	 gameManagerRef = cam.GetComponent("GameManager");
//	 scientistGO = GameObject.Find("Scientist");
//	 scientistAnim = scientistGO.GetComponent(Animator);
//	 anim = gameObject.GetComponent(Animator);
//	 
//     home = transform.position;
//     rb = rigidbody2D;
//     argo = new GameObject[samples];
//     for (var i = 0; i < argo.Length; i++) {
//         var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
//         go.collider.enabled = false;
//         go.transform.localScale = Vector3(0.2, 0.2, 0.2);
//         argo[i] = go;
//     }
// }
// 
// function OnMouseDown()
//  {
//  	 sRenderer.enabled = false;  	 
//  	 Instantiate (primitiveME, transform.position, Quaternion.identity); 
//  	 
//  	 scientistAnim.SetTrigger ("dragging");
//  	 
//     var v3 = Input.mousePosition;
//     v3.z = transform.position.z - Camera.main.transform.position.z;
//     v3 = Camera.main.ScreenToWorldPoint(v3);
//     offset = transform.position - v3;
// }
// 
// function OnMouseDrag() {
//     var v3 = Input.mousePosition;
//     v3.z = transform.position.z - Camera.main.transform.position.z;
//     v3 = Camera.main.ScreenToWorldPoint(v3);
//     transform.position = v3 + offset;
//     DisplayIndicators();
// }
// 
// function OnMouseUp()
//  {
//     sRenderer.enabled = true;
//	 scientistAnim.SetTrigger ("threw");  
//     rb.isKinematic = false;
//     rb.velocity = force * (home - transform.position);
//     gameManagerRef.AmmoLoaded = false;
// }
// 
// function DisplayIndicators() {
//     argo[0].transform.position = transform.position;
//     var v3 = transform.position;
//     var y = (force * (home - transform.position)).y;
//     var t = 0.0;
//     v3.y = 0.0;
//     for (var i = 1; i < argo.Length; i++) {
//         v3 +=  force * (home - transform.position) * spacing;
//         t += spacing;
//         v3.y = y * t + 0.5 * Physics.gravity.y * t * t + transform.position.y;
//         argo[i].transform.position = v3;
//     }
// }
// function OnCollisionEnter2D(coll: Collision2D)
// {
// 		if (coll.gameObject.tag == "Ground1")
//		{
//			Destroy(gameObject);
//		}
// }
// 