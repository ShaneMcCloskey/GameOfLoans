using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Test Comment shane was here

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
		currentPanel = homePanel;
		homePanel.SetActive (true);
	}





	public void SelectHome()
	{
		phPanel.SetActive (false);
		lipPanel.SetActive (false);
		okPanel.SetActive (false);
		homePanel.SetActive (true);
	}

	public void SelectPHPane()
	{
		phPanel.SetActive (true);
		homePanel.SetActive (false);
	}

	public void SelectLipPanel()
	{
		lipPanel.SetActive (true);
		homePanel.SetActive (false);
	}

	public void SelectOkPanel()
	{
		okPanel.SetActive (true);
		homePanel.SetActive (false);
	}

	public void OnButtonPlay()
	{
		mainMenuPanel.SetActive (false);
		okPanel.SetActive (true);
	}

	public void OnButtonDrawOppKnocksCard ()
	{
		gameControler.DrawCard();
	}
}
