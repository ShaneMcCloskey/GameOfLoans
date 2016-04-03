using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.HighScoreObjects;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class HighScoreController : MonoBehaviour
{
	private Player player;
	public GameObject HighScoresPage;
	public GameObject PlayerInputPage;
	public GameObject scoresPanel;
	public GameObject gameOverPanel;
	public GameObject HighScorePopUP;
	public Text PopUpText;
	public Text PageNumText;
	public Text GameOverIncome;
	public Text GameOverAssets;
	public Text GameOverCredit;
	public Text GameOverLoans;
	public Text GameOverScore;
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
	private bool isScoreError = false;


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
		if (NameInput.text != "" && TeamInput.text != "") {

			GameScore sendingScore = new GameScore () {
				Id = null,
				Name = NameInput.text,
				TeamName = TeamInput.text,
				Score = player.Score,
				LoansClosed = player.NumPropertiesClosed
			};
            
			StartCoroutine (WaitRequestSendScore (sendingScore));

        
		}
		else {
			HighScorePopUP.SetActive (true);
			PopUpText.text = "You must enter both a name and team name to submit a high score.";
		}
    }
		
    private IEnumerator WaitRequestGetScores()
    {
        isLoadingScores = true;
		var error = false;
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
					if (wwwGET.error == null) {
						
						isLoadingScores = false;
						SetScores (wwwGET.text);
					} 
					else 
					{
						error = true;
					}

				}
			}
			else{
				//error
				error = true;
				isScoreError = true;
			}
		}
		if (error == true) {
			PopUpText.text = "ERROR: High Scores could not be loaded.";
			HighScorePopUP.SetActive (true);
		}
    }
	private IEnumerator WaitRequestSendScore(GameScore gs){
		string gsJson = JsonUtility.ToJson (gs);
		Debug.Log (gsJson);
		//var encoding = new System.Text.UTF8Encoding();
		var postHeader = new Dictionary<string, string>();
		postHeader.Add("Content-Type", "text/json");
		//postHeader.Add("Content-Length", gsJson.Length.ToString());
		using (var www = new WWW(sendscoresurl, Encoding.UTF8.GetBytes(gsJson), postHeader))
		{
			
			yield return www;
			if (www.error == null) {
				Debug.Log (www.text);
				//no error
				AddScoreReturn returnValue = JsonUtility.FromJson<AddScoreReturn>(www.text);
				NavController.OnButtonLeaderboards ();
				HighScores (returnValue.rank / scoresPerPage);
			} 
			else {
				PopUpText.text = "ERROR: Score could not be added.";
				HighScorePopUP.SetActive (true);
				isScoreError = true;
			}

		}
	}
	public void SetPlayer(Player finalPlayer)
	{
		player = finalPlayer;
		GameOverAssets.text = finalPlayer.Assets.ToString();
		GameOverLoans.text = finalPlayer.NumPropertiesClosed.ToString ();
		GameOverIncome.text = finalPlayer.Income.ToString ();
		GameOverCredit.text = finalPlayer.Credit.ToString();
		GameOverScore.text = finalPlayer.Score.ToString ();
		gameOverPanel.SetActive(true);
	}
	public void OnPopUPOk()
	{
		HighScorePopUP.SetActive(false);

		if (isScoreError) {
			SceneManager.LoadScene ("MainScene");
			isScoreError = false;
		}
	}
}


