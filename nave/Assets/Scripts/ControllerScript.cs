using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	public Transform playerTransform;
	public RocketScript rock;
	
	// speed da nave
	public Vector2 speed = new Vector2(10,10);
	public Vector2 movement;

	// Movement flags
	private bool moveLeft, moveRight, moveUp, moveDown, fire = false;

	public static bool isFire = false;

	void Awake() {
		rock = playerTransform.gameObject.GetComponent<RocketScript> ();

	}

	void Start() {

	}

	void Update() {
		calculaMovementEFire ();
	}

	void FixedUpdate() {
		if (moveUp || moveRight || moveDown || moveLeft) {
			AplicaMovemento();
		}
	}

	public void Up() {
		moveUp = true;
	}

	public void Right() {
		moveRight = true;
	}

	public void Donwn() {
		moveDown = true;
	}

	public void Left() {
		moveLeft = true;
	}

	public void Fire() {
		isFire = true;
	}

	public void calculaMovementEFire() {

		float directionMoveX = 0f;
		float directionMoveY = 0f;

		if (moveRight) {
			directionMoveX = 150.25f;
		} else if (moveLeft) {
			directionMoveX = -100.25f;
		} else if (moveUp) {
			directionMoveY = 150.25f;
		} else if (moveDown) {
			directionMoveY = -100.25f;
		}


		// Movement direction
		movement = new Vector2 (
			speed.x * (directionMoveX * Time.deltaTime),
			speed.y * (directionMoveY * Time.deltaTime));

	}

	public void AplicaMovemento() {
		rock.GetComponent<Rigidbody2D> ().velocity = movement;
	}

	public void RemoveMovemento() {
		moveLeft = moveRight = moveUp = moveDown = false;
		rock.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
	}

	public void stopFire() {
		isFire = false;
	}

}
