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
	// Property hunt text element
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
	public Text popUpRandEventText;
	// Change propety text elements

	// private vars ----------------------
	private bool randEventGoodOccured = false;
	private bool randEventBadOccured = false;
	private bool subgoalPopUpActive = false;

	public void AwakeUI()
	{
		HUDscoreText.text = "0";
		HUDincomeText.text = "0";
		HUDassetsText.text = "0";
		HUDcreditText.text = "0";
		HUDturnText.text = "40";
	}

	public void EnterOppKnocksScreenUI()
	{
		textOppKnocksDesc.text = "Click to draw card";
		textOppKnocksType.text = "";
	}

	public void UpdateTurnsLeft (Player player)
	{
		HUDturnText.text = player.NumTurnsLeft.ToString();
	}

	public void UpdateOppKnocksCardTextAndPlayerStatsUI(OppKnocksCard card, Player player)
	{
		textOppKnocksDesc.text = card.Desc;

		if (card.Category == 1) 
		{
			textOppKnocksType.text = "Income Card";
			HUDincomeText.text = player.Income.ToString();
		} 
		else if (card.Category == 2) 
		{
			textOppKnocksType.text = "Asset Card";
			HUDassetsText.text = player.Assets.ToString();
		} 
		else 
		{
			textOppKnocksType.text = "Credit Card";
			HUDcreditText.text = player.Credit.ToString();
		}
	}

	public void EnterPropertyHuntScreeUI(PropertyCard cardLeft, PropertyCard cardCenter, PropertyCard cardRight)
	{
		leftAddress.text = cardLeft.Address;
		leftPrice.text = cardLeft.Price.ToString();
		leftSqFoot.text = cardLeft.SqFoot.ToString();
		leftDiff.text = cardLeft.Difficulty.ToString();

		centerAddress.text = cardCenter.Address;
		centerPrice.text = cardCenter.Price.ToString();
		centerSqFoot.text = cardCenter.SqFoot.ToString();
		centerDiff.text = cardCenter.Difficulty.ToString();

		rightAddress.text = cardRight.Address;
		rightPrice.text = cardRight.Price.ToString();
		rightSqFoot.text = cardRight.SqFoot.ToString();
		rightDiff.text = cardRight.Difficulty.ToString();
	}

	// Loan in Progess functions -----------------------------------------------
	public void EnterLoanInProgressScreenUI(Player player)
	{
		currentAddress.text = player.CurrentProperty.Address;
		currentPrice.text = player.CurrentProperty.Price.ToString();
		currentSqFoot.text = player.CurrentProperty.SqFoot.ToString();
		currentDiff.text = player.CurrentProperty.Difficulty.ToString();

        	progressBar.maxValue = player.CurrentProperty.NumToClose;
        	progressBar.value = player.CurrentProperty.CurrentProgress;
	}

        public void RollDiceUI (Player player, GameObject popUpPanel, bool loanComplete, bool randEventGood, bool randEventBad)
	{
		// need to have the panel in here
		progressBar.value = player.CurrentProperty.CurrentProgress;
		HUDscoreText.text = player.Score.ToString ();
		HUDincomeText.text =  player.Income.ToString ();
		HUDassetsText.text = player.Assets.ToString ();
		HUDcreditText.text = player.Credit.ToString ();
		HUDturnText.text = player.NumTurnsLeft.ToString ();

		CheckSubGoal(player, popUpPanel);
		CheckRandomEvent(randEventGood, randEventBad, popUpPanel, player);

		if (loanComplete)
		{
			ShowPopUp("Loan Complete!", popUpPanel);
		}
        }

        void CheckSubGoal (Player player, GameObject popUpPanel)
	{
		if ((player.CurrentProperty.CurrentProgress >= progressBar.maxValue / 9) && player.CurrentProperty.Subgoal1Complete == false)
		{
			//Debug.Log("1");			
			ShowPopUp("Subgoal 1", popUpPanel);
			player.CurrentProperty.Subgoal1Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 2) && player.CurrentProperty.Subgoal2Complete == false)
		{
			ShowPopUp("Subgoal 2", popUpPanel);
			player.CurrentProperty.Subgoal2Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 3) && player.CurrentProperty.Subgoal3Complete == false)
		{
			ShowPopUp("Subgoal 3", popUpPanel);
			player.CurrentProperty.Subgoal3Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 4) && player.CurrentProperty.Subgoal4Complete == false)
		{
			ShowPopUp("Subgoal 4", popUpPanel);
			player.CurrentProperty.Subgoal4Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 5) && player.CurrentProperty.Subgoal5Complete == false)
		{
			ShowPopUp("Subgoal 5", popUpPanel);
			player.CurrentProperty.Subgoal5Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 6) && player.CurrentProperty.Subgoal6Complete == false)
		{
			ShowPopUp("Subgoal 6", popUpPanel);
			player.CurrentProperty.Subgoal6Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 7) && player.CurrentProperty.Subgoal7Complete == false)
		{
			ShowPopUp("Subgoal 7", popUpPanel);
			player.CurrentProperty.Subgoal7Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 8) && player.CurrentProperty.Subgoal8Complete == false)
		{
			ShowPopUp("Subgoal 8", popUpPanel);
			player.CurrentProperty.Subgoal8Complete = true;
			subgoalPopUpActive = true;
		}
	}

	void CheckRandomEvent (bool randEventGood, bool randEventBad, GameObject popUpPanel, Player player)
	{
		randEventGoodOccured = randEventGood;
		randEventBadOccured = randEventBad;
		if (subgoalPopUpActive == false)
		{
			if (randEventGood)
			{
				ShowPopUp("Positive Random Event", popUpPanel);

			}
			if (randEventBad)
			{
				ShowPopUp("Negative Random Event", popUpPanel);
			}
		}
	}

	void ProcessNegativeEvent (Player player)
	{
		player.CurrentProperty.CurrentProgress -= 3;
		progressBar.value = player.CurrentProperty.CurrentProgress;
		if ((player.CurrentProperty.CurrentProgress <= progressBar.maxValue / 9) && player.CurrentProperty.Subgoal1Complete == true)
		{
			player.CurrentProperty.Subgoal1Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 2) && player.CurrentProperty.Subgoal2Complete == true)
		{
			player.CurrentProperty.Subgoal2Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 3) && player.CurrentProperty.Subgoal3Complete == true)
		{
			player.CurrentProperty.Subgoal3Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 4) && player.CurrentProperty.Subgoal4Complete == true)
		{
			player.CurrentProperty.Subgoal4Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 5) && player.CurrentProperty.Subgoal5Complete == true)
		{
			player.CurrentProperty.Subgoal5Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 6) && player.CurrentProperty.Subgoal6Complete == true)
		{
			player.CurrentProperty.Subgoal6Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 7) && player.CurrentProperty.Subgoal7Complete == true)
		{
			player.CurrentProperty.Subgoal7Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 8) && player.CurrentProperty.Subgoal8Complete == true)
		{
			player.CurrentProperty.Subgoal8Complete = false;
		}
	}

	void ProcessPositiveEvent(Player player)
	{
		player.CurrentProperty.CurrentProgress += 3;
		progressBar.value = player.CurrentProperty.CurrentProgress;
	}

	// add param to check if need to be sent to diff panel
	void ShowPopUp (string Text, GameObject PopUpPanel)
	{
		PopUpPanel.SetActive (true);
		popUpText.text = Text;
		popUpButtonText.text = "Ok";
	}

        // still need to pop up subgoal hit after random event ok click if hit subgoal
	public void ProcessOkButtonUI (GameObject popUpPanel, GameObject popUpPanelNeedProp, GameObject propHuntPanel, Player player)
	{
		if (player.PlayerCardsProperty.Count == 0)  // if player completes loan and has none in queue
		{
			popUpPanel.SetActive (false);
			popUpPanelNeedProp.SetActive (true);
		}

		popUpPanel.SetActive (false);

		if (subgoalPopUpActive)
		{
			subgoalPopUpActive = false;
			CheckRandomEvent (randEventGoodOccured, randEventBadOccured, popUpPanel, player);
		}
		else if (randEventBadOccured)
		{
			ProcessNegativeEvent (player);
		}
		else if (randEventGoodOccured)
		{
			ProcessPositiveEvent(player);
			CheckSubGoal(player,popUpPanel);
		}
	}



	public void EnterChangePropertyScreenUI (PropertyCard card1, PropertyCard card2, PropertyCard card3)
	{
		// call func from ui cont
	}
}