using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.Net;
using System.IO;



public class HighScoreController : MonoBehaviour
{
	public Player player;
	public GameObject HighScoresPage;
	public GameObject PlayerInputPage;
	public GameObject scoresPanel;

	public InputField NameInput;
	public InputField TeamInput;
	public InputField ScoreInput;
	public InputField LoansInput;
	const int RANK_LOC = 0;
	const int NAME_LOC = 1;
	const int TEAM_LOC = 2;
	const int Score_LOC = 3;
	const int LOANS_LOC = 4;

	const string getscoresurl = "http://35.9.22.106/Api/HighScores/GetHighScores?n=250";
	const string sendscoresurl = "http://35.9.22.106/Api/HighScores/AddScore";
	int pageNumber = 0;
	int scoresPerPage = 25;
	int maxPageNum =0;
	int minPageNum = 0;
	List<GameScore> data;

	//change to start to get high scores page to work
	public void Start()
	{
		WWW www = new WWW (getscoresurl);
		StartCoroutine (WaitRequestGet (www));
	}

	private IEnumerator WaitRequestGet (WWW www) {
	
		yield return www;
		SetScores (www);
	}

	public void SetScores (WWW www) {
		data = JsonConvert.DeserializeObject<List<GameScore>> (www.text);
		maxPageNum = (int) Mathf.Ceil (data.Count / scoresPerPage);
		SetUI (data);
	}


	public void SetUI (List<GameScore> dataList) {
		
		for (int i = 0; i < 25; i++) {
			// if not enough data
			if (i + (pageNumber * scoresPerPage) >= dataList.Count) {
				//set the rank
				scoresPanel.transform.GetChild (i).GetChild (RANK_LOC).GetChild (0).GetComponent<Text> ().text = "";
				//set the name
				scoresPanel.transform.GetChild (i).GetChild (NAME_LOC).GetChild (0).GetComponent<Text> ().text = "";
				//set the team name
				scoresPanel.transform.GetChild (i).GetChild (TEAM_LOC).GetChild (0).GetComponent<Text> ().text = "";
				//set Score
				scoresPanel.transform.GetChild (i).GetChild (Score_LOC).GetChild (0).GetComponent<Text> ().text = "";
				//set Loans closed
				scoresPanel.transform.GetChild (i).GetChild (LOANS_LOC).GetChild (0).GetComponent<Text> ().text = "";
			}
			//there is enough data
			else {
				//set the rank
				scoresPanel.transform.GetChild (i).GetChild (RANK_LOC).GetChild (0).GetComponent<Text> ().text = (i + (pageNumber * scoresPerPage) + 1).ToString ();
				//set the name
				scoresPanel.transform.GetChild (i).GetChild (NAME_LOC).GetChild (0).GetComponent<Text> ().text = dataList [i + (pageNumber * scoresPerPage)].Name;
				//set the team name
				scoresPanel.transform.GetChild (i).GetChild (TEAM_LOC).GetChild (0).GetComponent<Text> ().text = dataList [i + (pageNumber * scoresPerPage)].TeamName;
				//set Score
				scoresPanel.transform.GetChild (i).GetChild (Score_LOC).GetChild (0).GetComponent<Text> ().text = dataList [i + (pageNumber * scoresPerPage)].Score.ToString ();
				//set Loans closed
				scoresPanel.transform.GetChild (i).GetChild (LOANS_LOC).GetChild (0).GetComponent<Text> ().text = dataList [i + (pageNumber * scoresPerPage)].LoansClosed.ToString ();
			}
		}
	}
		
	public void OnNextClick()
	{
		pageNumber += 1;
		if (pageNumber >= maxPageNum) {
			pageNumber = maxPageNum;
		}
		SetUI (data);

	}

	public void OnPrevClick() {

		pageNumber -= 1;
		if (pageNumber <= minPageNum) {

			pageNumber = minPageNum;
		}
		SetUI (data);
	}


	public void AddScore(){
		if(NameInput.text!="" &&ScoreInput.text!="" && TeamInput.text!="" &&LoansInput.text!="")
		{
			
			GameScore sendingScore = new GameScore ();
			sendingScore.Name = NameInput.text;
			sendingScore.TeamName = TeamInput.text;
			sendingScore.Score = int.Parse(ScoreInput.text);
			sendingScore.LoansClosed = int.Parse( LoansInput.text);

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (sendscoresurl);
			request.Method = "PUSH";
			StreamWriter writer = new StreamWriter( request.GetRequestStream());
			writer.Write (sendingScore);
			writer.Close ();

		}

	}
}