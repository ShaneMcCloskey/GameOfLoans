using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.HighScoreObjects;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour
{
    public Player player;
    public GameObject HighScoresPage;
    public GameObject PlayerInputPage;
    public GameObject scoresPanel;
	public Text PageNumText;
    public InputField NameInput;
    public InputField TeamInput;
	public NavigationController NavController;
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
    private bool isLoadingScores = true;


    //change to start to get high scores page to work
    // get HighScores from api
    public void HighScores(int pageNum)
    {
        pageNumber = pageNum;
        StartCoroutine(WaitRequestGetScores());
    }
    //deserializes json into data and passes list of scores to setUI function
    public void SetScores(string serializedText)
    {
        if (!isLoadingScores)
        {
            serializedText = "{ \"Data\":" + serializedText + "}";
            GameScoreList gsl = JsonUtility.FromJson<GameScoreList>(serializedText);
            SetUI(new List<GameScore>(gsl.Data));
        }
    }

    //sets the HighScore page with the appropriate high scores
    public void SetUI(List<GameScore> dataList)
    {

        for (int i = 0; i < scoresPerPage; i++)
        {
            // if not enough data
            if (i >= dataList.Count)
            {
                //set the rank
                scoresPanel.transform.GetChild(i).GetChild(RANK_LOC).GetChild(0).GetComponent<Text>().text = "";
                //set the name
                scoresPanel.transform.GetChild(i).GetChild(NAME_LOC).GetChild(0).GetComponent<Text>().text = "";
                //set the team name
                scoresPanel.transform.GetChild(i).GetChild(TEAM_LOC).GetChild(0).GetComponent<Text>().text = "";
                //set Score
                scoresPanel.transform.GetChild(i).GetChild(Score_LOC).GetChild(0).GetComponent<Text>().text = "";
                //set Loans closed
                scoresPanel.transform.GetChild(i).GetChild(LOANS_LOC).GetChild(0).GetComponent<Text>().text = "";
            }
            //there is enough data
            else
            {
                //set the rank
                scoresPanel.transform.GetChild(i).GetChild(RANK_LOC).GetChild(0).GetComponent<Text>().text = (i + (pageNumber * scoresPerPage) + 1).ToString();
                //set the name
                scoresPanel.transform.GetChild(i).GetChild(NAME_LOC).GetChild(0).GetComponent<Text>().text = dataList[i].Name;
                //set the team name
                scoresPanel.transform.GetChild(i).GetChild(TEAM_LOC).GetChild(0).GetComponent<Text>().text = dataList[i].TeamName;
                //set Score
                scoresPanel.transform.GetChild(i).GetChild(Score_LOC).GetChild(0).GetComponent<Text>().text = dataList[i].Score.ToString();
                //set Loans closed
                scoresPanel.transform.GetChild(i).GetChild(LOANS_LOC).GetChild(0).GetComponent<Text>().text = dataList[i].LoansClosed.ToString();
            }
        }
		//set page number text box with appropriate info
		PageNumText.text = "Pg " + (pageNumber + 1).ToString () + "  of " + (maxPageNum + 1).ToString () + " (" + (0 + (pageNumber * scoresPerPage) + 1).ToString ()
			+ "-" + ((dataList.Count - 1) + (pageNumber * scoresPerPage) + 1).ToString ()+" of " + totalScores.ToString() + ")";
    }

    public void OnNextClick()
    {
        pageNumber += 1;
        if (pageNumber >= maxPageNum)
        {
            pageNumber = maxPageNum;
        }
        HighScores(pageNumber);

    }
    public void OnLastClick()
    {
        pageNumber = maxPageNum;
        HighScores(pageNumber);
    }
    public void OnFirstClick()
    {
        pageNumber = 0;
        HighScores(pageNumber);
    }

    public void OnPrevClick()
    {

        pageNumber -= 1;
        if (pageNumber <= minPageNum)
        {

            pageNumber = minPageNum;
        }
        HighScores(pageNumber);
    }


    public void AddScore()
    {
        if (NameInput.text != "" && TeamInput.text != "")
        {

			GameScore sendingScore = new GameScore()
			{
				Id = null,
				Name = NameInput.text,
				TeamName = TeamInput.text,
				Score = Convert.ToInt32(1000500),
				LoansClosed = Convert.ToInt32(20)
			};
            
			StartCoroutine (WaitRequestSendScore(sendingScore));

            //change this when integrating into main scene
            //			sendingScore.Score = player.score;
            //				sendingScore.LoansClosed = player.numPropertiesClosed;
        }
    }
		
    private IEnumerator WaitRequestGetScores()
    {
        isLoadingScores = true;
		using (var www = new WWW(getnumscoresurl))
		{
			yield return www;
			if (www.error == null) {
				totalScores = Convert.ToInt32 (www.text);
				maxPageNum = totalScores / scoresPerPage;
				var geturl = getscoresurl + "start=" + (scoresPerPage * pageNumber).ToString() + "&" + "range=" + scoresPerPage.ToString();
				using (var wwwGET = new WWW(geturl))
				{
					yield return wwwGET;
					isLoadingScores = false;
					SetScores(wwwGET.text);

				}
			}
			else{
				//error
				Debug.Log("Error");
			}
		}
        
    }
	private IEnumerator WaitRequestSendScore(GameScore gs){
		string gsJson = JsonUtility.ToJson (gs);
		Debug.Log (gsJson);
		var encoding = new System.Text.UTF8Encoding();
		var postHeader = new Dictionary<string, string>();
		postHeader.Add("Content-Type", "text/json");
		postHeader.Add("Content-Length", gsJson.Length.ToString());
		using (var www = new WWW(sendscoresurl, encoding.GetBytes(gsJson), postHeader))
		{
			
			yield return www;
			Debug.Log (www.text);
			var test = 5;
		}
	}

}


