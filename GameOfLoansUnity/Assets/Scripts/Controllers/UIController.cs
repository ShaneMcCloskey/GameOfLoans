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
	//private bool firstOkComplete = false;
	private bool randEventGoodOccured = false;
	private bool randEventBadOccured = false;
	//private bool badDecreaseOccured = false;
	//private bool goodIncreaseOccured = false;

	private bool subgoalPopUpActive = false;

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
		HUDturnText.text = "Turns Left: " + player.NumTurnsLeft;
	}

	public void UpdateOppKnocksCardTextAndPlayerStatsUI(OppKnocksCard card, Player player)
	{
		textOppKnocksDesc.text = card.desc;

		if (card.category == 1) 
		{
			textOppKnocksType.text = "Income Card";
			HUDincomeText.text = "Income: " + player.Income.ToString();
		} 
		else if (card.category == 2) 
		{
			textOppKnocksType.text = "Asset Card";
			HUDassetsText.text = "Assets: " + player.Assets.ToString();
		} 
		else 
		{
			textOppKnocksType.text = "Credit Card";
			HUDcreditText.text = "Credit: " + player.Credit.ToString();
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
		currentAddress.text = player.CurrentProperty.address;
		currentPrice.text = player.CurrentProperty.price.ToString();
		currentSqFoot.text = player.CurrentProperty.sqFoot.ToString();
		currentDiff.text = player.CurrentProperty.difficulty.ToString();

        	progressBar.maxValue = player.CurrentProperty.numToClose;
        	progressBar.value = player.CurrentProperty.currentProgress;
	}

        public void RollDiceUI (Player player, GameObject popUpPanel, bool loanComplete, bool randEventGood, bool randEventBad)
	{
		// need to have the panel in here
		progressBar.value = player.CurrentProperty.currentProgress;
		HUDscoreText.text = "Score: " + player.Score.ToString ();
		HUDincomeText.text = "Income: " + player.Income.ToString ();
		HUDassetsText.text = "Assets: " + player.Assets.ToString ();
		HUDcreditText.text = "Credit: " + player.Credit.ToString ();
		HUDturnText.text = "Turns Left: " + player.NumTurnsLeft.ToString ();

		CheckSubGoal(player, popUpPanel);
		CheckRandomEvent(randEventGood, randEventBad, popUpPanel, player);

		if (loanComplete)
		{
			ShowPopUp("Loan Complete!", popUpPanel);
		}
        }

        void CheckSubGoal (Player player, GameObject popUpPanel)
	{
		if ((player.CurrentProperty.currentProgress >= progressBar.maxValue / 9) && player.CurrentProperty.subgoal1Complete == false)
		{
			//Debug.Log("1");			
			ShowPopUp("Subgoal 1", popUpPanel);
			player.CurrentProperty.subgoal1Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.currentProgress >= (progressBar.maxValue / 9) * 2) && player.CurrentProperty.subgoal2Complete == false)
		{
			ShowPopUp("Subgoal 2", popUpPanel);
			player.CurrentProperty.subgoal2Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.currentProgress >= (progressBar.maxValue / 9) * 3) && player.CurrentProperty.subgoal3Complete == false)
		{
			ShowPopUp("Subgoal 3", popUpPanel);
			player.CurrentProperty.subgoal3Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.currentProgress >= (progressBar.maxValue / 9) * 4) && player.CurrentProperty.subgoal4Complete == false)
		{
			ShowPopUp("Subgoal 4", popUpPanel);
			player.CurrentProperty.subgoal4Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.currentProgress >= (progressBar.maxValue / 9) * 5) && player.CurrentProperty.subgoal5Complete == false)
		{
			ShowPopUp("Subgoal 5", popUpPanel);
			player.CurrentProperty.subgoal5Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.currentProgress >= (progressBar.maxValue / 9) * 6) && player.CurrentProperty.subgoal6Complete == false)
		{
			ShowPopUp("Subgoal 6", popUpPanel);
			player.CurrentProperty.subgoal6Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.currentProgress >= (progressBar.maxValue / 9) * 7) && player.CurrentProperty.subgoal7Complete == false)
		{
			ShowPopUp("Subgoal 7", popUpPanel);
			player.CurrentProperty.subgoal7Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.currentProgress >= (progressBar.maxValue / 9) * 8) && player.CurrentProperty.subgoal8Complete == false)
		{
			ShowPopUp("Subgoal 8", popUpPanel);
			player.CurrentProperty.subgoal8Complete = true;
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
		player.CurrentProperty.currentProgress -= 3;
		progressBar.value = player.CurrentProperty.currentProgress;
		if ((player.CurrentProperty.currentProgress <= progressBar.maxValue / 9) && player.CurrentProperty.subgoal1Complete == true)
		{
			player.CurrentProperty.subgoal1Complete = false;
		}
		else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 2) && player.CurrentProperty.subgoal2Complete == true)
		{
			player.CurrentProperty.subgoal2Complete = false;
		}
		else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 3) && player.CurrentProperty.subgoal3Complete == true)
		{
			player.CurrentProperty.subgoal3Complete = false;
		}
		else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 4) && player.CurrentProperty.subgoal4Complete == true)
		{
			player.CurrentProperty.subgoal4Complete = false;
		}
		else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 5) && player.CurrentProperty.subgoal5Complete == true)
		{
			player.CurrentProperty.subgoal5Complete = false;
		}
		else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 6) && player.CurrentProperty.subgoal6Complete == true)
		{
			player.CurrentProperty.subgoal6Complete = false;
		}
		else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 7) && player.CurrentProperty.subgoal7Complete == true)
		{
			player.CurrentProperty.subgoal7Complete = false;
		}
		else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 8) && player.CurrentProperty.subgoal8Complete == true)
		{
			player.CurrentProperty.subgoal8Complete = false;
		}
	}

	void ProcessPositiveEvent(Player player)
	{
		player.CurrentProperty.currentProgress += 3;
		progressBar.value = player.CurrentProperty.currentProgress;
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

/*else if (subgoalPopUpActive == false) // normal rand event
		{
			if (randEventGoodOccured)
			{
				player.CurrentProperty.currentProgress += 3;
				RollDiceUI(player, popUpPanel, false, false, false);
				randEventGoodOccured = false;
			}
			else if (randEventBadOccured)
			{
				player.CurrentProperty.currentProgress -= 3;
				progressBar.value -= 3;
				/*if ((player.CurrentProperty.currentProgress <= progressBar.maxValue / 9) && player.CurrentProperty.subgoal1Complete == true)
				{
					player.CurrentProperty.subgoal1Complete = false;
				}
				else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 2) && player.CurrentProperty.subgoal2Complete == true)
				{
					player.CurrentProperty.subgoal2Complete = false;
				}
				else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 3) && player.CurrentProperty.subgoal3Complete == true)
				{
					player.CurrentProperty.subgoal3Complete = false;
				}
				else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 4) && player.CurrentProperty.subgoal4Complete == true)
				{
					player.CurrentProperty.subgoal4Complete = false;
				}
				else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 5) && player.CurrentProperty.subgoal5Complete == true)
				{
					player.CurrentProperty.subgoal5Complete = false;
				}
				else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 6) && player.CurrentProperty.subgoal6Complete == true)
				{
					player.CurrentProperty.subgoal6Complete = false;
				}
				else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 7) && player.CurrentProperty.subgoal7Complete == true)
				{
					player.CurrentProperty.subgoal7Complete = false;
				}
				else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 8) && player.CurrentProperty.subgoal8Complete == true)
				{
					player.CurrentProperty.subgoal8Complete = false;
				}
				randEventBadOccured = false;
				// turn on pop up
				popUpPanel.SetActive (false);
			} 
			// turn on pop up
			//popUpPanel.SetActive (false);
			EnterLoanInProgressScreenUI (player);
		}
		else // subgoal popup is active
		{
			//Debug.Log ("in 1");
			if (randEventGoodOccured)
			{
				//Debug.Log ("in 2");
				PopUpRandEvent (true, false, popUpPanel);
				randEventGoodOccured = false;
				goodIncrease = true;
			}
			else if (randEventBadOccured)
			{
				//Debug.Log ("in 3");
				PopUpRandEvent (false, true, popUpPanel);
				randEventBadOccured = false;
				badDecrease = true;
			}
			else
			{
				//Debug.Log ("in 4");

				// turn on pop up
				popUpPanel.SetActive (false);
				subgoalPopUpActive = false;
				if (badDecrease)
				{
					//Debug.Log("in bad");
					player.CurrentProperty.currentProgress -= 3;
					progressBar.value -= 3;
					if ((player.CurrentProperty.currentProgress <= progressBar.maxValue / 9) && player.CurrentProperty.subgoal1Complete == true)
					{
						player.CurrentProperty.subgoal1Complete = false;
					}
					else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 2) && player.CurrentProperty.subgoal2Complete == true)
					{
						player.CurrentProperty.subgoal2Complete = false;
					}
					else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 3) && player.CurrentProperty.subgoal3Complete == true)
					{
						player.CurrentProperty.subgoal3Complete = false;
					}
					else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 4) && player.CurrentProperty.subgoal4Complete == true)
					{
						player.CurrentProperty.subgoal4Complete = false;
					}
					else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 5) && player.CurrentProperty.subgoal5Complete == true)
					{
						player.CurrentProperty.subgoal5Complete = false;
					}
					else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 6) && player.CurrentProperty.subgoal6Complete == true)
					{
						player.CurrentProperty.subgoal6Complete = false;
					}
					else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 7) && player.CurrentProperty.subgoal7Complete == true)
					{
						player.CurrentProperty.subgoal7Complete = false;
					}
					else if ((player.CurrentProperty.currentProgress <= (progressBar.maxValue / 9) * 8) && player.CurrentProperty.subgoal8Complete == true)
					{
						player.CurrentProperty.subgoal8Complete = false;
					}
					badDecrease = false;
				}
				if (goodIncrease)
				{
					//Debug.Log("in good inc");
					player.CurrentProperty.currentProgress += 3;
					RollDiceUI(player, popUpPanel, false, false, false);
					randEventGoodOccured = false;
					goodIncrease = false;
				}
				EnterLoanInProgressScreenUI (player);
			}
		}

*/