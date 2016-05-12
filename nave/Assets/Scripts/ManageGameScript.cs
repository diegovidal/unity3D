using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManageGameScript : MonoBehaviour {

	public Transform inimigoPrefab;
	float camHalfWidth;
	float width;
	float height;

	public Text score;
	public static int SCORE_COUNT;
	private int highScore;
	string highScoreKey = "HighScore";

	public static bool IS_GAMEOVER = false;



	// Use this for initialization
	void Start () {
		height = 2f * Camera.main.orthographicSize;
		width = height * Camera.main.aspect; 

		criaInimigo ();
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);


	}
	
	// Update is called once per frame
	void Update () {
		TrataGameOver ();
		if (Time.frameCount % 200 == 0) {

			int inimigoToral = Random.Range(1, 5);

			for(int i = 0; i <= inimigoToral; i++) {
				criaInimigo();
			}

		}

		marcarScore ();
	}

	private void criaInimigo() {
		var inimigoTransform = Transform.Instantiate (inimigoPrefab);

		inimigoTransform.position = new Vector2 (Random.Range(width * 0.5f, width * 2f) , 
													Random.Range(-(height/2f), height/2f));
	}

	public void TrataGameOver(){
		if (IS_GAMEOVER) {
			IS_GAMEOVER = false;
			salvaHightScore();
			SCORE_COUNT = 0;



			Application.LoadLevel("MenuScene");

		}
	}

	public void marcarScore() {
		score.text = "Score: " + SCORE_COUNT;
	}

	private void salvaHightScore() {
		if (SCORE_COUNT > highScore) {
			PlayerPrefs.SetInt(highScoreKey, SCORE_COUNT);
			PlayerPrefs.Save();
		}
	}
}
