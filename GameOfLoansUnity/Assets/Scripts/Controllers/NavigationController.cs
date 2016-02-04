using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Test Comment shane was here test

public class NavigationController : MonoBehaviour 
{
	public GameObject mainMenuPanel;
	public GameObject howToPlayPanel;
	public GameObject leaderboardsPanel;
	public GameObject creditsPanel;
	public GameObject homePanel;
	public GameObject propertyHuntPanel;
	public GameObject loanInProgressPanel;
	public GameObject oppKnocksPanel;
	public GameObject HUDPanel;

	public GameController gameControler;

	private GameObject currentPanel;

	// Use this for initialization
	void Awake() 
	{
		currentPanel = mainMenuPanel;
		mainMenuPanel.SetActive (true);
		howToPlayPanel.SetActive (false);
		leaderboardsPanel.SetActive (false);
		creditsPanel.SetActive (false);
		homePanel.SetActive(false);
		propertyHuntPanel.SetActive (false);
		loanInProgressPanel.SetActive (false);
		oppKnocksPanel.SetActive (false);
		HUDPanel.SetActive (false);
	}

	// main menu buttons ----------------------------------
	public void OnButtonPlay()
	{
		ChangePanel (oppKnocksPanel, true);
	}

	public void OnButtonHowToPlay()
	{
		ChangePanel (howToPlayPanel, false);
	}

	public void OnButtonLeaderboards()
	{
		ChangePanel (leaderboardsPanel, false);
	}

	public void OnButtonCredits()
	{
		ChangePanel (creditsPanel, false);
	}

	// Home button in all panels -------------------------
	public void OnButtonHome()
	{
		ChangePanel (homePanel, true);
	}
		
	// Home buttons --------------------------------------
	public void OnButtonOppKnocks()
	{
		ChangePanel (oppKnocksPanel, true);
	}

	public void OnButtonPropertyHunt()
	{
		ChangePanel (propertyHuntPanel, true);
	}

	public void OnButtonLoanInProgress()
	{
		ChangePanel (loanInProgressPanel, true);
	}

	// Opp knocks buttons -------------------------------
	public void OnButtonDrawOppKnocksCard ()
	{
		gameControler.DrawOppKnocksCard();
	}

	// Property hunt buttons ----------------------------
	public void OnButtonPickPropertyCard(string leftOrRight)
	{
		gameControler.DrawPropertyCard (leftOrRight);
	}

	void ChangePanel(GameObject panelToShow, bool showHUD)
	{
		if (showHUD) 
		{	
			HUDPanel.SetActive (true);
		} 
		else 
		{
			HUDPanel.SetActive (false);	
		}
		currentPanel.SetActive (false);
		panelToShow.SetActive (true);
		currentPanel = panelToShow;
	}
}
