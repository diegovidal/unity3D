using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class ScoreManager : MonoBehaviour {

	// The map we are building is going to look like
	//
	// LIST OF USERS -> A User -> LIST OF SCORES for that user
	//

	Dictionary<string, Dictionary<string, int>> playerScores;
	

	// Use this for initialization
	void Start () {
		setScore("vidal", "kills", 10);
		setScore("vidal", "deaths", 2);
		setScore("vidal", "assists", 25);

		setScore("bob", "kills", 5);
		setScore("bob", "deaths", 12);
		setScore("bob", "assists", 9);

		setScore("zezo", "kills", 32);
		setScore("zezo", "deaths", 2);
		setScore("zezo", "assists", 2);

		setScore("fulano", "kills", 4);
		setScore("fulano", "deaths", 18);
		setScore("fulano", "assists", 12);

		setScore("torres", "kills", 12);
		setScore("torres", "deaths", 6);
		setScore("torres", "assists", 12);

		setScore("guilerme", "kills", 2);
		setScore("guilerme", "deaths", 5);
		setScore("guilerme", "assists", 9);

		setScore("waldir", "kills", 22);
		setScore("waldir", "deaths", 4);
		setScore("waldir", "assists", 12);

		setScore("renato", "kills", 2);
		setScore("renato", "deaths", 5);
		setScore("renato", "assists", 20);

	}

	void Init(){
		if (playerScores != null)
			return;

		playerScores = new Dictionary<string, Dictionary<string, int>>();
	}
	
	public int getScore(string username, string scoreType){
		Init();

		if(playerScores.ContainsKey(username) == false){
			// We have no score record at all for this username
			return 0;
		}
		if(playerScores[username].ContainsKey(scoreType) == false){
			return 0;
		}

		return playerScores[username][scoreType];
	}

	public void setScore(string username, string scoreType, int value){
		Init();

		if(playerScores.ContainsKey(username) == false){
			playerScores[username] = new Dictionary<string, int>();
		}

		playerScores[username][scoreType] = value;

	}

	public void changeScore(string username, string scoreType, int amount){
		Init();

		int currentScore = getScore(username, scoreType);
		setScore(username, scoreType, currentScore + amount);

	}

	public string[] getPlayerNames(string sortingScoreType){
		Init();

		return playerScores.Keys.OrderByDescending(n => getScore(n, sortingScoreType)).ToArray();
	}
}
