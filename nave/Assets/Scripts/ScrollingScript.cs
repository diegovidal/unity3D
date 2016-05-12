using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScrollingScript : MonoBehaviour {

	// speed
	public Vector2 speed = new Vector2(2, 2);

	// moving direction
	public Vector2 direction = new Vector2(-1, 0);

//	//applied to camera
//	public bool isLinkedCamera = false;
//
//		// background is infinite
//	public bool isLooping = false;
//
//	private List<Transform> backgroundPart;
	
	public GameObject bg;

//	private Plane[] planes;

	float width;
	float Y;
	Vector3 screenPos;

//	RectTransform objectRectTransform;


	void Start() {
//		planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
		float height = 2f * Camera.main.orthographicSize;
		width = height * Camera.main.aspect;

//		objectRectTransform = gameObject.GetComponent<RectTransform> ();
//		Debug.Log("width: " + objectRectTransform.rect.width + ", height: " + objectRectTransform.rect.height);

		Y = gameObject.transform.position.y;
	}

	// Update is called once per frame
	void Update () {
		moveParallax ();
	}

	private void moveParallax() {
		Vector3 movement = new Vector3 (
			speed.x * direction.x,
			speed.y * direction.y,
			0f);
		
		movement *= Time.deltaTime;
		transform.Translate (movement);
//		
//		if (isLinkedCamera) {
//			Camera.main.transform.Translate(movement);
//		}

		screenPos = Camera.main.WorldToScreenPoint(bg.transform.position);

		if (screenPos.x < -Screen.width*0.5f) {
			gameObject.transform.position = new Vector3(width, Y, 0f);

		}

	}
	
}
