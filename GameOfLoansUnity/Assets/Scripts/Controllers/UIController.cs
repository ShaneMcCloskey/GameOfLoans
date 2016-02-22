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
	private bool badDecrease = false;
	private bool goodIncrease = false;

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

        public void RollDiceUI (Player player, GameObject popUpPanel, bool loanComplete, bool randEventGood, bool randEventBad)
	{
		// need to have the panel in here
		progressBar.value = player.currentProperty.currentProgress;
		HUDscoreText.text = "Score: " + player.score.ToString ();
		HUDincomeText.text = "Income: " + player.income.ToString ();
		HUDassetsText.text = "Assets: " + player.assets.ToString ();
		HUDcreditText.text = "Credit: " + player.credit.ToString ();
		HUDturnText.text = "Turns Left: " + player.numTurnsLeft.ToString ();

		if ((player.currentProperty.currentProgress >= progressBar.maxValue / 9) && player.currentProperty.subgoal1Complete == false)
		{
			//Debug.Log("1");
			popUpPanel.SetActive (true);
			popUpText.text = "Subgoal 1";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal1Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 2) && player.currentProperty.subgoal2Complete == false)
		{
			popUpPanel.SetActive (true);
			popUpText.text = "Subgoal 2";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal2Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 3) && player.currentProperty.subgoal3Complete == false)
		{
			popUpPanel.SetActive (true);
			popUpText.text = "Subgoal 3";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal3Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 4) && player.currentProperty.subgoal4Complete == false)
		{
			popUpPanel.SetActive (true);
			popUpText.text = "Subgoal 4";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal4Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 5) && player.currentProperty.subgoal5Complete == false)
		{
			popUpPanel.SetActive (true);
			popUpText.text = "Subgoal 5";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal5Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 6) && player.currentProperty.subgoal6Complete == false)
		{
			popUpPanel.SetActive (true);
			popUpText.text = "Subgoal 6";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal6Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 7) && player.currentProperty.subgoal7Complete == false)
		{
			popUpPanel.SetActive (true);
			popUpText.text = "Subgoal 7";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal7Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.currentProperty.currentProgress >= (progressBar.maxValue / 9) * 8) && player.currentProperty.subgoal8Complete == false)
		{
			popUpPanel.SetActive (true);
			popUpText.text = "Subgoal 8";
			popUpButtonText.text = "Ok";
			player.currentProperty.subgoal8Complete = true;
			subgoalPopUpActive = true;
		}
		if (loanComplete)
		{
			popUpPanel.SetActive (true);
			popUpText.text = "Loan Complete!";
			popUpButtonText.text = "Ok";
		}

		if (subgoalPopUpActive == false)
		{
			if (randEventGood)
			{
				randEventGood = true;
				PopUpRandEvent (true, false, popUpPanel);
			}
			if (randEventBad)
			{
				randEventBadOccured = true;
				PopUpRandEvent (false, true, popUpPanel);
			}
		}
		if (randEventBad)
		{
			randEventBadOccured = true;
		}
		if (randEventGood)
		{
			randEventGoodOccured = true;
		}
        }

        void PopUpRandEvent(bool randEventGood, bool randEventBad, GameObject popUpPanel)
        {
		if (randEventGood)
		{
			popUpPanel.SetActive(true);
			popUpText.text = "Positive Random Event";
			popUpButtonText.text = "Ok";
		}
		if (randEventBad)
		{
			popUpPanel.SetActive(true);
			popUpText.text = "Negative Random Event";
			popUpButtonText.text = "Ok";
		}
        }
        // still need to pop up subgoal hit after random event ok click if hit subgoal
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
			popUpPanel.SetActive (false);
			popUpPanelNeedProp.SetActive (true);
		}
		else if (subgoalPopUpActive == false) // normal rand event
		{
			if (randEventGoodOccured)
			{
				player.currentProperty.currentProgress += 3;
				RollDiceUI(player, popUpPanel, false, false, false);
				randEventGoodOccured = false;
			}
			else if (randEventBadOccured)
			{
				player.currentProperty.currentProgress -= 3;
				progressBar.value -= 3;
				if ((player.currentProperty.currentProgress <= progressBar.maxValue / 9) && player.currentProperty.subgoal1Complete == true)
				{
					player.currentProperty.subgoal1Complete = false;
				}
				else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 2) && player.currentProperty.subgoal2Complete == true)
				{
					player.currentProperty.subgoal2Complete = false;
				}
				else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 3) && player.currentProperty.subgoal3Complete == true)
				{
					player.currentProperty.subgoal3Complete = false;
				}
				else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 4) && player.currentProperty.subgoal4Complete == true)
				{
					player.currentProperty.subgoal4Complete = false;
				}
				else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 5) && player.currentProperty.subgoal5Complete == true)
				{
					player.currentProperty.subgoal5Complete = false;
				}
				else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 6) && player.currentProperty.subgoal6Complete == true)
				{
					player.currentProperty.subgoal6Complete = false;
				}
				else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 7) && player.currentProperty.subgoal7Complete == true)
				{
					player.currentProperty.subgoal7Complete = false;
				}
				else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 8) && player.currentProperty.subgoal8Complete == true)
				{
					player.currentProperty.subgoal8Complete = false;
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
					player.currentProperty.currentProgress -= 3;
					progressBar.value -= 3;
					if ((player.currentProperty.currentProgress <= progressBar.maxValue / 9) && player.currentProperty.subgoal1Complete == true)
					{
						player.currentProperty.subgoal1Complete = false;
					}
					else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 2) && player.currentProperty.subgoal2Complete == true)
					{
						player.currentProperty.subgoal2Complete = false;
					}
					else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 3) && player.currentProperty.subgoal3Complete == true)
					{
						player.currentProperty.subgoal3Complete = false;
					}
					else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 4) && player.currentProperty.subgoal4Complete == true)
					{
						player.currentProperty.subgoal4Complete = false;
					}
					else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 5) && player.currentProperty.subgoal5Complete == true)
					{
						player.currentProperty.subgoal5Complete = false;
					}
					else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 6) && player.currentProperty.subgoal6Complete == true)
					{
						player.currentProperty.subgoal6Complete = false;
					}
					else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 7) && player.currentProperty.subgoal7Complete == true)
					{
						player.currentProperty.subgoal7Complete = false;
					}
					else if ((player.currentProperty.currentProgress <= (progressBar.maxValue / 9) * 8) && player.currentProperty.subgoal8Complete == true)
					{
						player.currentProperty.subgoal8Complete = false;
					}
					badDecrease = false;
				}
				if (goodIncrease)
				{
					//Debug.Log("in good inc");
					player.currentProperty.currentProgress += 3;
					RollDiceUI(player, popUpPanel, false, false, false);
					randEventGoodOccured = false;
					goodIncrease = false;
				}
				EnterLoanInProgressScreenUI (player);
			}
		}


	}

	public void EnterChangePropertyScreenUI (PropertyCard card1, PropertyCard card2, PropertyCard card3)
	{
		// call func from ui cont
	}
}
