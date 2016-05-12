using UnityEngine;
using System.Collections;

public class BalaScript : MonoBehaviour {

	public int demage = 1;

	public bool isEnemyShot = false;

	// Use this for initialization
	void Start () {
	
		Destroy (gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Destroy(other.gameObject);
		Destroy (gameObject);
		ManageGameScript.SCORE_COUNT = ManageGameScript.SCORE_COUNT + 1;
	}
}
