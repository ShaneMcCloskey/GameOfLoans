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
	public GameObject highscoresPopUPPanel;
	public Text PopUpText;
	public InputField NameInput;
	public InputField TeamInput;
	public InputField LoansInput;
	public InputField ScoreInput;
	const int RANK_LOC = 0;
	const int NAME_LOC = 1;
	const int TEAM_LOC = 2;
	const int Score_LOC = 3;
	const int LOANS_LOC = 4;

	const string getscoresurl = "http://35.9.22.106/Api/HighScores/GetHighScores?";
	const string sendscoresurl = "http://35.9.22.106/Api/HighScores/AddScore";
	const string getnumscoresurl = "http://35.9.22.106/Api/HighScores/GetNumScores";
	int pageNumber = 0;
	int scoresPerPage = 25;
	int maxPageNum = 0;
	int minPageNum = 0;
	int totalScores = 0;
	List<GameScore> data;

	//change to start to get high scores page to work
	// get HighScores from api
	public void HighScores (int pageNum)
	{
		Debug.Log (pageNumber);

		try {
			//get max page number
			HttpWebRequest requestNum = (HttpWebRequest)WebRequest.Create(getnumscoresurl);
			requestNum.Method= "GET";
			requestNum.Timeout =100000;
			WebResponse numResponse = requestNum.GetResponse();
			StreamReader numReader = new StreamReader(numResponse.GetResponseStream());
			string numString = numReader.ReadToEnd();
			totalScores = JsonConvert.DeserializeObject<int>(numString);
			maxPageNum = (int) totalScores/scoresPerPage;
			// get the correct page of  high Scores
			string geturl = getscoresurl + "start=" + (scoresPerPage * pageNumber).ToString () + "&" + "range=" + scoresPerPage.ToString ();
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (geturl);
			request.Method = "GET";
			request.Timeout = 100000;
			WebResponse response = request.GetResponse ();
			StreamReader reader = new StreamReader (response.GetResponseStream ());
			string readerString = reader.ReadToEnd ();
			SetScores (readerString);

		} catch (WebException) {
			highscoresPopUPPanel.SetActive (true);
			PopUpText.text = "High scores could not be loaded.";
			//will need a function to call here.

		}
	}
	//deserializes json into data and passes list of scores to setUI function
	public void SetScores (string serializedText)
	{
		data = JsonConvert.DeserializeObject<List<GameScore>> (serializedText);
		SetUI (data);
	}

	//sets the HighScore page with the appropriate high scores
	public void SetUI (List<GameScore> dataList)
	{

		for (int i = 0; i < scoresPerPage; i++) {
			// if not enough data
			if (i >= dataList.Count) {
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
				scoresPanel.transform.GetChild (i).GetChild (RANK_LOC).GetChild (0).GetComponent<Text> ().text = (i + (pageNumber*scoresPerPage) + 1).ToString ();
				//set the name
				scoresPanel.transform.GetChild (i).GetChild (NAME_LOC).GetChild (0).GetComponent<Text> ().text = dataList [i].Name;
				//set the team name
				scoresPanel.transform.GetChild (i).GetChild (TEAM_LOC).GetChild (0).GetComponent<Text> ().text = dataList [i].TeamName;
				//set Score
				scoresPanel.transform.GetChild (i).GetChild (Score_LOC).GetChild (0).GetComponent<Text> ().text = dataList [i].Score.ToString ();
				//set Loans closed
				scoresPanel.transform.GetChild (i).GetChild (LOANS_LOC).GetChild (0).GetComponent<Text> ().text = dataList [i].LoansClosed.ToString ();
			}
		}
	}

	public void OnNextClick ()
	{
		pageNumber += 1;
		if (pageNumber >= maxPageNum) {
			pageNumber = maxPageNum;
		}
		HighScores (pageNumber);
		SetUI (data);

	}
	public void OnLastClick()
	{
		pageNumber = maxPageNum;
		HighScores (pageNumber);
		SetUI (data);
	}
	public void OnFirstClick()
	{
		pageNumber = 0;
		HighScores (pageNumber);
		SetUI (data);
	}

	public void OnPrevClick ()
	{

		pageNumber -= 1;
		if (pageNumber <= minPageNum) {

			pageNumber = minPageNum;
		}
		HighScores (pageNumber);
		SetUI (data);
	}


	public void AddScore ()
	{
		if (NameInput.text != "" && TeamInput.text != "") {

			GameScore sendingScore = new GameScore ();
			sendingScore.Name = NameInput.text;

			sendingScore.TeamName = TeamInput.text;


			//change this when integrating into main scene
			//			sendingScore.Score = player.score;
//				sendingScore.LoansClosed = player.numPropertiesClosed;
			sendingScore.Score= int.Parse(ScoreInput.text);
			sendingScore.LoansClosed = int.Parse (LoansInput.text);
			sendingScore.Id = null;
			AddScoreReturn returnedScore;
			try {

				HttpWebRequest request = (HttpWebRequest)WebRequest.Create (sendscoresurl);
				request.Method = "POST";
				request.ContentType = "application/json; charset=utf-8";
				request.Timeout = 100000;
				StreamWriter writer = new StreamWriter (request.GetRequestStream ());
				string sendData = JsonConvert.SerializeObject (sendingScore);
				writer.Write (sendData);
				writer.Close ();
				WebResponse response = request.GetResponse ();
				StreamReader reader = new StreamReader (response.GetResponseStream ());
				string readerString = reader.ReadToEnd ();
			// what reader string looks like	{"gameScore":{"Id":52,"Name":"TESTADDNew2","TeamName":"TESTADDNew2","Score":1,"LoansClosed":1},"rank":47}
			returnedScore = JsonConvert.DeserializeObject<AddScoreReturn>(readerString);
				Debug.Log(returnedScore.rank);
				// change page functionality later
				//HighScores (0);
			} catch (WebException) {
				highscoresPopUPPanel.SetActive (true);
				PopUpText.text = "Your high score could not be added at this time.";
			}
		} 
		else {
			highscoresPopUPPanel.SetActive (true);
			if (NameInput.text == "" && TeamInput.text != "") {
				PopUpText.text = "Please fill in the Name textbox to submit your score.";
			}
			if (TeamInput.text == "" && NameInput.text != "") {
				PopUpText.text = "Please fill in the  Team Name textbox to submit your score.";
			}
			if (TeamInput.text == "" && NameInput.text == "") {
				PopUpText.text = "Please fill in the  Name and Team Name textboxes to submit your score.";
			}

		}
	}

	public void ClosePopUp ()
	{
		highscoresPopUPPanel.SetActive (false);
	}
}