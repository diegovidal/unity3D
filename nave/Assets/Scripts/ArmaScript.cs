using UnityEngine;
using System.Collections;

public class ArmaScript : MonoBehaviour {

	public Transform balaPrefab;
	public float mediaDeTiro = 0.25f;
	public float tiroEsfriar;

	private float w;

	// Use this for initialization
	void Start () {
		tiroEsfriar = 0f;

		var gameOb = transform.gameObject.GetComponent<SpriteRenderer> ();
		w = (gameOb.bounds.max.x - gameOb.bounds.min.x) / 2;

	}
	
	// Update is called once per frame
	void Update () {
		if (tiroEsfriar > 0) {
			tiroEsfriar -= Time.deltaTime;
		}


	}

	public void atacar(bool isEnemy) {

		if (podeAtacar) {
			tiroEsfriar = mediaDeTiro;

			//crie novo tiro
			var tiroTransform = Transform.Instantiate(balaPrefab) as Transform;

			// posicao tiro
			if(isEnemy) {
				tiroTransform.position = new Vector2(transform.position.x - w,
				                                     transform.position.y);
			} else {
				tiroTransform.position = new Vector2(transform.position.x + w + 0.5f,
				                                     transform.position.y);
			}

			BalaScript bala = tiroTransform.gameObject.GetComponent<BalaScript>();
			if(bala != null) {
				bala.isEnemyShot = isEnemy;
			}

			MovementScript move = 
				tiroTransform.gameObject.GetComponent<MovementScript>();
			if(move != null) {
				//em 2d sempre a direta do Sprite
				move.direction = this.transform.right;
			}

		}
	}

	public bool podeAtacar{
		get {
			return tiroEsfriar <= 0f;
		}
	}
}
