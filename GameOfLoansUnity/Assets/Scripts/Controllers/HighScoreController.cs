using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine.UI;
using Newtonsoft.Json;



public class HighScoreController : MonoBehaviour {
	public Player player;
	public GameObject scoresPanel;
	const int RANK_LOC = 0;
	const int NAME_LOC = 1;
	const int TEAM_LOC = 2;
	const int Score_LOC = 3;
	const int LOANS_LOC = 4;

	const string getscores = "http://35.9.22.106/Api/HighScores/GetHighScores?n=250";

	public void Start(){
		WWW www = new WWW (getscores);
		StartCoroutine (WaitRequestGet (www));
	}

	private IEnumerator WaitRequestGet(WWW www){
	
		yield return www;
		SetScores (www);
	}

	public void SetScores(WWW www)
	{
		List<GameScore> data = JsonConvert.DeserializeObject<List<GameScore>>(www.text);
		int count = scoresPanel.transform.childCount;
		for(int i=0;i<25;i++)
		{
			// if not enough data
			if (i >= data.Count)
			{
				break;
			}
			//set the rank
			scoresPanel.transform.GetChild(i).GetChild(RANK_LOC).GetChild(0).GetComponent<Text>().text = (i+1).ToString();
			//set the name
			scoresPanel.transform.GetChild(i).GetChild(NAME_LOC).GetChild(0).GetComponent<Text>().text = data[i].Name;
			//set the team name
			scoresPanel.transform.GetChild(i).GetChild(TEAM_LOC).GetChild (0).GetComponent<Text>().text = data[i].TeamName;
			//set Score
			scoresPanel.transform.GetChild(i).GetChild(Score_LOC).GetChild (0).GetComponent<Text>().text = data[i].Score.ToString();
			//set Loans closed
			scoresPanel.transform.GetChild(i).GetChild(LOANS_LOC).GetChild (0).GetComponent<Text>().text = data[i].LoansClosed.ToString();
			
		}
	}
		


}
