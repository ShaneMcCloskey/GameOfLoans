using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NavigationController : MonoBehaviour 
{
	public Text propertyName;

	public GameObject mainMenuPanel;
	public GameObject homePanel;
	public GameObject statsPanel;
	public GameObject phPanel;
	public GameObject lipPanel;
	public GameObject okPanel;

	public GameController gameControler;

	// Use this for initialization
	void Start () 
	{
		/*mainMenuPanel.SetActive (true);
		statsPanel.SetActive (false);
		phPanel.SetActive (false);
		lipPanel.SetActive (false);
		okPanel.SetActive (false);*/
	}

	public void SelectStats()
	{
		Debug.Log ("hit");
		statsPanel.SetActive (true);
		homePanel.SetActive (false);
	}

	public void SelectHome()
	{
		statsPanel.SetActive (false);
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
