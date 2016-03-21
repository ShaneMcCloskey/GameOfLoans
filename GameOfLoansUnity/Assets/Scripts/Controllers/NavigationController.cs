﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Test Comment shane was here test

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

	public Button oppKnocksButton;
	public Button loanInProgressButton;
	public Button propHuntButton;

	public GameObject changePropertyButton;
	public GameObject cancelLoanButton;

	public GameController gameControler;
	public HighScoreController HighScoreController;

	// private vars -------------------------
	private GameObject currentPanel;

	/*public CardFlip cfLeft;
	public CardFlip cfCenter;
	public CardFlip cfRight;*/

	public BackgroundScroll backgroundScroll;


	// Use this for initialization
	public void Awake() 
	{
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
	}

	// main menu buttons ----------------------------------
	public void OnButtonPlay()
	{
		ChangePanel (oppKnocksPanel, true, false);
		gameControler.EnterOppKnocksScreen ();
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
		ChangePanel (oppKnocksPanel, true, false);
		gameControler.EnterOppKnocksScreen ();
	}

	public void OnButtonPropertyHunt()
	{
		ChangePanel (propertyHuntPanel, true, false);
		popUpPanelNeedProp.SetActive(false);
		gameControler.EnterPropertyHuntScreen();
	}

	public void OnButtonLoanInProgress()
	{
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
		gameControler.DrawOppKnocksCard(leftRightOrCenter);
	}

	// Property hunt buttons ----------------------------------------
	public void OnButtonPickPropertyCard(string leftRightOrCenter)
	{
		gameControler.DrawPropertyCard (leftRightOrCenter);
		ChangePanel(loanInProgressPanel, true, true);
		gameControler.EnterLoanInProgressScreen();
	}

	public void ChangeProperty (int num)
	{
	}

    // Loan in Progress Buttons --------------------------------------
    public void OnButtonRollDice()
    {
        gameControler.RollDie(popUpPanel, quizPanel);
    }

    	// PopUp ---------------------------------------------------------
    public void OnPopUpOk ()
	{
		gameControler.ProcessOkButton(popUpPanel, popUpPanelNeedProp, propertyHuntPanel, quizPanel);
	}

        // Quiz Answer Buttons
        public void OnAnswerA()
        {
            gameControler.ProcessAnswerA(quizPanel, popUpPanel);
        }

        public void OnAnswerB()
        {
            gameControler.ProcessAnswerB(quizPanel, popUpPanel);
        }

        public void OnAnswerC()
        {
            gameControler.ProcessAnswerC(quizPanel, popUpPanel);
        }

        public void OnAnswerD()
        {
            gameControler.ProcessAnswerD(quizPanel, popUpPanel);
        }


	public void OnRandEventPopUpOk ()
	{
		popUpPanelRandEvent.SetActive(false);
	}
	public void OnHighScoresHomeButtonClick()
	{
		this.Awake ();
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
			cancelLoanButton.SetActive(true);
		}
		else
		{
			changePropertyButton.SetActive(false);
			cancelLoanButton.SetActive(false);
		}

		currentPanel.SetActive (false);
		panelToShow.SetActive (true);
		currentPanel = panelToShow;
	}
}
