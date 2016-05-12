using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class ButtonTap : MonoBehaviour {


	private bool rotateRight = false;
	private bool rotateLeft = false;

	public GameObject molecule;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (rotateRight) {
			Debug.Log ("Entrouuu");
			molecule.transform.eulerAngles = new Vector3(
				molecule.transform.eulerAngles.x,
				molecule.transform.eulerAngles.y + 0.5f,
				molecule.transform.eulerAngles.z 
			);
			//molecule.transform.rotation = Quaternion.Euler(0, molecule.transform.localRotation.y + 0.5f, 0);
			//molecule.transform.rotation = Quaternion.AngleAxis(molecule.transform.localRotation.y*Time.deltaTime, Vector3.up);

		}
		if (rotateLeft) {
			molecule.transform.eulerAngles = new Vector3(
				molecule.transform.eulerAngles.x,
				molecule.transform.eulerAngles.y - 0.5f,
				molecule.transform.eulerAngles.z 
			);

		}
	}

	void OnMouseDown(){
		if (this.name == "Button00") {
			rotateRight = true;
		}
		if (this.name == "Button01") {
			rotateLeft = true;
		}
		this.transform.localScale -= new Vector3(0.075F, 0.075F, 0);
		Debug.Log ("Teste2");
	}

	void OnMouseUp() {
		if (this.name == "Button00") {
			rotateRight = false;
			Debug.Log ("Uhuuu");
		}
		if (this.name == "Button01") {
			rotateLeft = false;
		}
		this.transform.localScale += new Vector3(0.075F, 0.075F, 0);
	}

	void OnMouseUpAsButton(){
		Debug.Log ("Teste2");
	}
}
