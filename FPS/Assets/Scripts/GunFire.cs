using UnityEngine;
using System.Collections;

public class GunFire : MonoBehaviour {

	private AudioSource gunSound;
	private Animation gunAnimation;

	// Use this for initialization
	void Start () {
		
		gunSound = GetComponent<AudioSource> ();
		gunAnimation = GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
			
			gunSound.Play ();
			gunAnimation.Play ("GunShot");
		}
	}
}
