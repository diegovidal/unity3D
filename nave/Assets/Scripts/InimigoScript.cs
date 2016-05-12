using UnityEngine;
using System.Collections;

public class InimigoScript : MonoBehaviour {

	private ArmaScript arma;


	void Awake() {
		arma = GetComponent<ArmaScript>();
	}

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {

		if (arma != null && arma.podeAtacar) {
			arma.atacar(true);
		}
	}

	public void CriaMultiplosInimigos(Transform inimigoPrefab) {
		var inimigoTransform = Transform.Instantiate (inimigoPrefab);
	}
}
