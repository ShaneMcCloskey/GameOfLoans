using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Test Comment shane was here test

public class NavigationController : MonoBehaviour 
{
	public Text propertyName;

	public GameObject mainMenuPanel;
	public GameObject homePanel;
	public GameObject phPanel;
	public GameObject lipPanel;
	public GameObject okPanel;
	public GameObject HUDPanel;

	public GameController gameControler;

	private GameObject currentPanel;

	// Use this for initialization
	void Awake() 
	{
		currentPanel = mainMenuPanel;
		mainMenuPanel.SetActive (true);
		homePanel.SetActive(false);
		phPanel.SetActive (false);
		lipPanel.SetActive (false);
		okPanel.SetActive (false);
		HUDPanel.SetActive (false);
	}

	// main menu buttons
	public void OnButtonPlay()
	{
		ChangePanel (homePanel);
	}

	public void OnButtonHowToPlay()
	{
	}

	public void OnButtonLeaderboards()
	{
	}

	public void OnButtonCredits()
	{
	}

	// Home button in all panels
	public void OnButtonHome()
	{
		currentPanel.SetActive (false);
		homePanel.SetActive (true);
		currentPanel = homePanel;
	}
		
	// Home buttons
	public void OnButtonOppKnocks()
	{
		currentPanel.SetActive (false);
		okPanel.SetActive (true);
		currentPanel = okPanel;
	}

	public void OnButtonPropertyHunt()
	{
	}

	public void OnButtonLoanInProgress()
	{
	}

	// Opp knocks buttons
	public void OnButtonDrawOppKnocksCard ()
	{
		gameControler.DrawOppKnocksCard();
	}

	void ChangePanel(GameObject panelToShow)
	{
		currentPanel.SetActive (false);
		panelToShow.SetActive (true);
		currentPanel = panelToShow;
	}
}
