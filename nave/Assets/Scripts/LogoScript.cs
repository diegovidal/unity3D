using UnityEngine;
using System.Collections;

public class LogoScript : MonoBehaviour {

	public float delayTime = 5f;

	IEnumerator Start() {
		yield return new WaitForSeconds (delayTime);
		startMenuScene ();
	}

	public void startMenuScene() {
		Application.LoadLevel ("MenuScene");
	}
}
