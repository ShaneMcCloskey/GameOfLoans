using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour 
{
	// public vars -----------------------------
	public GameObject mainMenuPanel;
	public GameObject howToPlayPanel;
	public GameObject leaderboardsPanel;
	public GameObject creditsPanel;
	public GameObject navPanel;
	public GameObject propertyHuntPanel;
	public GameObject loanInProgressPanel;
	public GameObject oppKnocksPanel;
	public GameObject currentPropertiesPanel;
	public GameObject HUDPanel;
	public GameObject popUpPanel;
	public GameObject popUpPanelNeedProp;
	public GameObject popUpPanelRandEvent;
    	public GameObject quizPanel;
	public GameObject GameOverPanel;
        public GameObject ConfirmPropertyPanel;

	public Button oppKnocksButton;
	public Button loanInProgressButton;
	public Button propHuntButton;

	public GameObject changePropertyButton;

	//public GameObject cancelLoanButton;

	public GameController gameControler;
	public HighScoreController HighScoreController;
	public BackgroundScroll backgroundScroll;


	// private vars -------------------------
	private GameObject currentPanel;

	//private bool isInputEnabled;

        public string leftrightocecnter;

	// Use this for initialization
	public void Awake() 
	{
		//isInputEnabled = true;
		currentPanel = mainMenuPanel;
		mainMenuPanel.SetActive (true);
		howToPlayPanel.SetActive (false);
		leaderboardsPanel.SetActive (false);
		creditsPanel.SetActive (false);
		navPanel.SetActive(false);
		propertyHuntPanel.SetActive (false);
		loanInProgressPanel.SetActive (false);
		oppKnocksPanel.SetActive (false);
		HUDPanel.SetActive (false);
		popUpPanel.SetActive(false);
		popUpPanelNeedProp.SetActive(false);
		popUpPanelRandEvent.SetActive(false);
		currentPropertiesPanel.SetActive(false);
		changePropertyButton.SetActive(false);
        	ConfirmPropertyPanel.SetActive(false);
	}

	// main menu buttons ----------------------------------
	public void OnButtonPlay()
	{
		ChangePanel (oppKnocksPanel, true, false);
		//gameControler.EnterOppKnocksScreen ();
		loanInProgressButton.interactable = false;
		propHuntButton.interactable = false;
		oppKnocksButton.interactable = false;
		backgroundScroll.scroll = false;
		backgroundScroll.Change();
	}

	public void OnButtonHowToPlay()
	{
		ChangePanel (howToPlayPanel, false, false);
	}

	public void OnButtonLeaderboards()
	{
		ChangePanel (leaderboardsPanel, false, false);
		HighScoreController.HighScores (0);
	}

	public void OnButtonCredits()
	{
		ChangePanel (creditsPanel, false, false);
	}
		
	// Nav buttons ---------------------------------------------------
	public void OnButtonOppKnocks()
	{
		oppKnocksButton.interactable = false;
		loanInProgressButton.interactable = true;
		propHuntButton.interactable = true;
		ChangePanel (oppKnocksPanel, true, false);
	}

	public void OnButtonPropertyHunt()
	{
		oppKnocksButton.interactable = true;
		loanInProgressButton.interactable = true;
		propHuntButton.interactable = false;
		ChangePanel (propertyHuntPanel, true, false);
		popUpPanelNeedProp.SetActive(false);
		gameControler.EnterPropertyHuntScreen();
	}

	public void OnButtonLoanInProgress()
	{
		oppKnocksButton.interactable = true;
		loanInProgressButton.interactable = false;
		propHuntButton.interactable = true;
		ChangePanel (loanInProgressPanel, true, true);
		gameControler.EnterLoanInProgressScreen();
	}

	public void OnButtonChangeProperty ()
	{
		ChangePanel(currentPropertiesPanel, true, false);
		gameControler.EnterChangePropertyScreen();
	}

	public void OnButtonCancelLoan ()
	{
		ChangePanel(propertyHuntPanel, true, false);
		gameControler.CancelCurrentLoan();
	}

	public void GameOver(Player player)
	{
		HighScoreController.SetPlayer (player);
		ChangePanel (GameOverPanel, false, false);
	}

	// Opp knocks --------------------------------------------------
	public void OnDrawOppKnocks (string leftRightOrCenter)
	{
		gameControler.DrawOppKnocksCard(leftRightOrCenter, oppKnocksButton, propHuntButton, loanInProgressButton);
	}

	// Property hunt buttons ----------------------------------------
	public void OnButtonPickPropertyCard(string leftRightOrCenter)
	{
	        gameControler.GetPropertyChoiceName(leftRightOrCenter);
	        ConfirmPropertyPanel.SetActive(true);
	        leftrightocecnter = leftRightOrCenter;
		//	gameControler.DrawPropertyCard (leftRightOrCenter);
		//	ChangePanel(loanInProgressPanel, true, true);
		//	gameControler.EnterLoanInProgressScreen();
	}

	// Loan in Progress Buttons --------------------------------------
	public void OnButtonRollDice()
	{
		gameControler.RollDie(popUpPanel, quizPanel);
	}

	public void OnButtonChangePropertyTo(int num)
	{
		gameControler.ChangePropertyTo(num);
		ChangePanel(loanInProgressPanel, true, true);
		gameControler.EnterLoanInProgressScreen();
	}

	// PopUp ---------------------------------------------------------
	public void OnPopUpOk ()
	{
		gameControler.ProcessOkButton(popUpPanel, popUpPanelNeedProp, propertyHuntPanel, quizPanel);
	}

	// Quiz Answer Buttons
	public void OnButtonAnswer(string letter)
	{
		gameControler.ProcessAnswer(quizPanel, popUpPanel, letter);
	}

	public void OnRandEventPopUpOk ()
	{
		popUpPanelRandEvent.SetActive(false);
	}
	public void OnHighScoresHomeButtonClick()
	{
		SceneManager.LoadScene("MainScene");
	}

	void ChangePanel (GameObject panelToShow, bool showHUD, bool loanInProgresActive)
	{
		if (showHUD)
		{	
			HUDPanel.SetActive (true);
			navPanel.SetActive (true);
		} 
		else
		{
			HUDPanel.SetActive (false);
			navPanel.SetActive (false);	
		}
		if (loanInProgresActive)
		{
			changePropertyButton.SetActive(true);
			//cancelLoanButton.SetActive(true);
		}
		else
		{
			changePropertyButton.SetActive(false);
			//cancelLoanButton.SetActive(false);
		}

		currentPanel.SetActive (false);
		panelToShow.SetActive (true);
		currentPanel = panelToShow;
	}

	public void OnButtonYes()
	{
		ConfirmPropertyPanel.SetActive(false);
		gameControler.DrawPropertyCard(leftrightocecnter);
		OnButtonLoanInProgress();
		/*ChangePanel(loanInProgressPanel, true, true);
		gameControler.EnterLoanInProgressScreen();*/

	}

	public void OnButtonNo()
	{
		ConfirmPropertyPanel.SetActive(false);
	}
}
