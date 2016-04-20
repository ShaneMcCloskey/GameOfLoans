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
	public Button AddScoreButton;
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

	string getscoresurl = "/Api/HighScores/GetHighScores?";
	string sendscoresurl = "/Api/HighScores/AddScore";
	string getnumscoresurl = "/Api/HighScores/GetNumScores";
	int pageNumber = 0;
	int scoresPerPage = 20;
	int maxPageNum = 0;
	int minPageNum = 0;
	int totalScores = 0;
	private bool isLoadingScores = true;
	private bool isScoreError = false;

	//on start initializes the ip address of the server
	public void Start()
	{
		string ip = "http://35.9.22.106";
		getscoresurl = ip + getscoresurl;
		sendscoresurl = ip + sendscoresurl;
		getnumscoresurl = ip + getnumscoresurl;
	}


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

	//changes high score page to the next page if not at the last page
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

	//returns the high scores panel to the first page
    public void OnFirstClick()
    {
        pageNumber = 0;
        HighScores(pageNumber);
    }
	//high scores page to the previous page
    public void OnPrevClick()
    {

        pageNumber -= 1;
        if (pageNumber <= minPageNum)
        {

            pageNumber = minPageNum;
        }
        HighScores(pageNumber);
    }

	//function called when user clicks submit for gameover
    public void AddScore()
    {
		if (NameInput.text != "" && TeamInput.text != "") {
			AddScoreButton.interactable = false;
			GameScore sendingScore = new GameScore () {
				Id = null,
				Name = NameInput.text,
				TeamName = TeamInput.text,
				Score = player.Score,
				LoansClosed = player.NumPropertiesClosed
			};
            		//start api call
			StartCoroutine (WaitRequestSendScore (sendingScore));

        
		}
		else {
			//if the user did not enter both the name and team name an error message opens
			HighScorePopUP.SetActive (true);
			PopUpText.text = "You must enter both a name and team name to submit a high score.";
		}
    }
		// function to call the api and receive the response for getting the number of total scores in the database and the current page of scores
    private IEnumerator WaitRequestGetScores()
    {
        isLoadingScores = true;
		var error = false;
		using (var www = new WWW(getnumscoresurl))
		{
			yield return www;
			//if no error

			if (www.error == null) {
				//receive the total number of scores
				totalScores = Convert.ToInt32 (www.text);
				maxPageNum = totalScores / scoresPerPage;
				//initializes the api call to grab the correct page of 25 scores
				var geturl = getscoresurl + "start=" + (scoresPerPage * pageNumber).ToString() + "&" + "range=" + scoresPerPage.ToString();
				using (var wwwGET = new WWW(geturl))
				{
					yield return wwwGET;

					//if there is no error
					if (wwwGET.error == null) {
						
						isLoadingScores = false;
						//call function to parse the json and set the scores on the page
						SetScores (wwwGET.text);
					}
					//error getting the list of scores
					else 
					{
						error = true;
					}

				}
			}
			else{
				//error getting the total number of scores
				error = true;
				isScoreError = true;
				AddScoreButton.interactable = true;
			}
		}
		//if there was any error calling the api for getting scores
		if (error == true) {
			PopUpText.text = "ERROR: High Scores could not be loaded.";
			HighScorePopUP.SetActive (true);
		}
    }
	// coroutine for api to send score to database
	private IEnumerator WaitRequestSendScore(GameScore gs){
		string gsJson = JsonUtility.ToJson (gs);
		//var encoding = new System.Text.UTF8Encoding();
		var postHeader = new Dictionary<string, string>();
		postHeader.Add("Content-Type", "text/json");
		//postHeader.Add("Content-Length", gsJson.Length.ToString());
		using (var www = new WWW(sendscoresurl, Encoding.UTF8.GetBytes(gsJson), postHeader))
		{
			
			yield return www;
			if (www.error == null)
			{
				//no error
				AddScoreReturn returnValue = JsonUtility.FromJson<AddScoreReturn> (www.text);
				//if get a correct response then show the leaderboards on the page on which the user's score is diplayed
				NavController.OnButtonLeaderboards ();
				HighScores (((returnValue.rank) / scoresPerPage));
			} 
			//error sending the score and receiving appropriate response
			else {
				PopUpText.text = "ERROR: Score could not be added.";
				HighScorePopUP.SetActive (true);
				isScoreError = true;
			}

		}
	}
	//function called when the game is over to pass the player to the high score controller
	public void SetPlayer(Player finalPlayer)
	{
		player = finalPlayer;
		player.Score = player.Score + (int) player.Credit  + (int)player.Income + (int) player.Assets;
		GameOverAssets.text = player.Assets.ToString();
		GameOverLoans.text = player.NumPropertiesClosed.ToString ();
		GameOverIncome.text = player.Income.ToString ();
		GameOverCredit.text = player.Credit.ToString();
		GameOverScore.text = player.Score.ToString ();
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


