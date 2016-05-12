using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScoreList : MonoBehaviour {

	public GameObject playerScoreEntryPrefab;

	ScoreManager scoreManager;
	bool executeOnce = false;

	// Use this for initialization
	void Start () {

		scoreManager = GameObject.FindObjectOfType<ScoreManager>();

	}
	
	// Update is called once per frame
	void Update () {

		if(executeOnce)
			return;

		if(scoreManager == null){
			Debug.LogError("You forgot to add the score manager component to a game object");
			return;
		}

//		while(this.transform.childCount > 0){
//			Transform c = this.transform.GetChild(0);
//			c.SetParent(null); //Become batman
//			Destroy(c.gameObject);
//			Debug.Log("Destroy completed");
//		}
		
		string[] names = scoreManager.getPlayerNames("kills");
		
		foreach(string name in names){
			
			GameObject go = Instantiate(playerScoreEntryPrefab);
			go.transform.SetParent(this.transform);
			go.transform.Find("Username").GetComponent<Text>().text = name;
			go.transform.Find("Kills").GetComponent<Text>().text = scoreManager.getScore(name, "kills").ToString();;
			go.transform.Find("Deaths").GetComponent<Text>().text = scoreManager.getScore(name, "deaths").ToString();
			go.transform.Find("Assists").GetComponent<Text>().text = scoreManager.getScore(name, "assists").ToString();
		}

		executeOnce = true;
	
	}
}
