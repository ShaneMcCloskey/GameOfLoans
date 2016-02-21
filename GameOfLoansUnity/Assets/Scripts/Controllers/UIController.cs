using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
	// public vars ----------------------
	// HUD text elements
	public Text HUDscoreText;
	public Text HUDincomeText;
	public Text HUDassetsText;
	public Text HUDcreditText;
	public Text HUDturnText;
	// Opp knocks card text elements
	public Text textOppKnocksType;
	public Text textOppKnocksDesc;
	// Property hunt text elements
	public Text leftAddress;
	public Text leftPrice;
	public Text leftSqFoot;
	public Text leftDiff;
	public Text centerAddress;
	public Text centerPrice;
	public Text centerSqFoot;
	public Text centerDiff;
	public Text rightAddress;
	public Text rightPrice;
	public Text rightSqFoot;
	public Text rightDiff;
        // Loan in progress 
	public Text currentAddress;
	public Text currentPrice;
	public Text currentSqFoot;
	public Text currentDiff;
	public Slider progressBar;
	// Pop up elements
	public Text popUpText;
	public Text popUpButtonText;
	// Change propety text elements

	// private vars ----------------------
	private bool firstOkComplete = false;

	public void AwakeUI()
	{
		HUDscoreText.text = "Score: 0";
		HUDincomeText.text = "Income: 0";
		HUDassetsText.text = "Assets: 0";
		HUDcreditText.text = "Credit: 0";
		HUDturnText.text = "Turns Left: 40";
	}

	public void EnterOppKnocksScreenUI()
	{
		textOppKnocksDesc.text = "Click to draw card";
		textOppKnocksType.text = "";
	}

	public void UpdateTurnsLeft (Player player)
	{
		HUDturnText.text = "Turns Left: " + player.numTurnsLeft;
	}

	public void UpdateOppKnocksCardTextAndPlayerStatsUI(OppKnocksCard card, Player player)
	{
		textOppKnocksDesc.text = card.desc;

		if (card.category == 1) 
		{
			textOppKnocksType.text = "Income Card";
			HUDincomeText.text = "Income: " + player.income.ToString();
		} 
		else if (card.category == 2) 
		{
			textOppKnocksType.text = "Asset Card";
			HUDassetsText.text = "Assets: " + player.assets.ToString();
		} 
		else 
		{
			textOppKnocksType.text = "Credit Card";
			HUDcreditText.text = "Credit: " + player.credit.ToString();
		}
	}

	public void EnterPropertyHuntScreeUI(PropertyCard cardLeft, PropertyCard cardCenter, PropertyCard cardRight)
	{
		leftAddress.text = cardLeft.address;
		leftPrice.text = cardLeft.price.ToString();
		leftSqFoot.text = cardLeft.sqFoot.ToString();
		leftDiff.text = cardLeft.difficulty.ToString();

		centerAddress.text = cardCenter.address;
		centerPrice.text = cardCenter.price.ToString();
		centerSqFoot.text = cardCenter.sqFoot.ToString();
		centerDiff.text = cardCenter.difficulty.ToString();

		rightAddress.text = cardRight.address;
		rightPrice.text = cardRight.price.ToString();
		rightSqFoot.text = cardRight.sqFoot.ToString();
		rightDiff.text = cardRight.difficulty.ToString();
	}

	// Loan in Progess functions -----------------------------------------------
	public void EnterLoanInProgressScreenUI(Player player)
	{
		currentAddress.text = player.currentProperty.address;
		currentPrice.text = player.currentProperty.price.ToString();
		currentSqFoot.text = player.currentProperty.sqFoot.ToString();
		currentDiff.text = player.currentProperty.difficulty.ToString();

        	progressBar.maxValue = player.currentProperty.numToClose;
        	progressBar.value = player.currentProperty.currentProgress;
	}

        public void RollDiceUI (Player player, int rollNum, GameObject PopUpPanel, bool loanComplete)
	{
		progressBar.value = player.currentProperty.currentProgress;
		HUDscoreText.text = "Score: " + player.score.ToString ();
		HUDincomeText.text = "Income: " + player.income.ToString ();
		HUDassetsText.text = "Assets: " + player.assets.ToString ();
		HUDcreditText.text = "Credit: " + player.credit.ToString ();
		HUDturnText.text = "Turns Left: " + player.numTurnsLeft.ToString ();
		if ((player.currentProperty.currentProgress >= progressBar.maxValue / 9) && player.currentProperty.subgoal1Complete == false)
		{
			PopUpPanel.SetActive(true);
			popUpText.text = "Subgoal 1";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal1Complete = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 2) && player.currentProperty.subgoal2Complete == false)
		{
			PopUpPanel.SetActive(true);
			popUpText.text = "Subgoal 2";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal2Complete = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 3) && player.currentProperty.subgoal3Complete == false)
		{
			PopUpPanel.SetActive(true);
			popUpText.text = "Subgoal 3";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal3Complete = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 4) && player.currentProperty.subgoal4Complete == false)
		{
			PopUpPanel.SetActive(true);
			popUpText.text = "Subgoal 4";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal4Complete = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 5) && player.currentProperty.subgoal5Complete == false)
		{
			PopUpPanel.SetActive(true);
			popUpText.text = "Subgoal 5";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal5Complete = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 6) && player.currentProperty.subgoal6Complete == false)
		{
			PopUpPanel.SetActive(true);
			popUpText.text = "Subgoal 6";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal6Complete = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 7) && player.currentProperty.subgoal7Complete == false)
		{
			PopUpPanel.SetActive(true);
			popUpText.text = "Subgoal 7";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal7Complete = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 8) && player.currentProperty.subgoal8Complete == false)
		{
			PopUpPanel.SetActive(true);
			popUpText.text = "Subgoal 8";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal8Complete = true;
		}
		if (loanComplete)
		{
			PopUpPanel.SetActive(true);
			popUpText.text = "Loan Complete!";
			popUpButtonText.text = "Ok";
		}
        }

	public void ProcessOkButtonUI (GameObject popUpPanel, GameObject popUpPanelNeedProp, GameObject propHuntPanel, Player player)
	{
		// fix this and also set last panel to false
		if (player.playerCardsProperty.Count == 0)
		{
			/*if (firstOkComplete)
			{

				firstOkComplete = false;
				propHuntPanel.SetActive(true);
				popUpPanel.SetActive(false);
			} 
			firstOkComplete = true;*/
			popUpPanel.SetActive(false);
			popUpPanelNeedProp.SetActive(true);
		} 
		else
		{
			// turn on pop up
			popUpPanel.SetActive(false);
			EnterLoanInProgressScreenUI(player);

		}
	}

	public void EnterChangePropertyScreenUI (PropertyCard card1, PropertyCard card2, PropertyCard card3)
	{
		// call func from ui cont
	}
}
