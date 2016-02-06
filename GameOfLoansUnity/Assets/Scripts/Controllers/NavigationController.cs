using UnityEngine;
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

	public GameObject changePropertyButton;

	public GameObject propertyCard1;
	public GameObject propertyCard2;
	public GameObject propertyCard3;

	public GameController gameControler;

	// private vars -------------------------
	private GameObject currentPanel;

	// Use this for initialization
	void Awake() 
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
		currentPropertiesPanel.SetActive(false);
		changePropertyButton.SetActive(false);
	}

	// main menu buttons ----------------------------------
	public void OnButtonPlay()
	{
		ChangePanel (oppKnocksPanel, true, false);
		gameControler.EnterOppKnocksScreen ();
	}

	public void OnButtonHowToPlay()
	{
		ChangePanel (howToPlayPanel, false, false);
	}

	public void OnButtonLeaderboards()
	{
		ChangePanel (leaderboardsPanel, false, false);
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
	}

	// Opp knocks buttons ------------------------------------------
	public void OnButtonDrawOppKnocksCard ()
	{
		gameControler.DrawOppKnocksCard();
	}

	// Property hunt buttons ----------------------------------------
	public void OnButtonPickPropertyCard(string leftOrRight)
	{
		gameControler.DrawPropertyCard (leftOrRight);
	}

	public void ChangeProperty (int num)
	{
	}

	void ChangePanel (GameObject panelToShow, bool showHUD, bool showChangeProperty)
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
		if (showChangeProperty)
		{
			changePropertyButton.SetActive(true);
		}
		else
		{
			changePropertyButton.SetActive(false);
		}

		currentPanel.SetActive (false);
		panelToShow.SetActive (true);
		currentPanel = panelToShow;
	}
}
