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
	// Change propety text elements

	// private vars ----------------------

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

	public void EnterPropertyHuntScreeUI(PropertyCard cardLeft, PropertyCard cardRight)
	{
		
		leftAddress.text = cardLeft.address;
		leftPrice.text = cardLeft.price.ToString();
		leftSqFoot.text = cardLeft.sqFoot.ToString();
		leftDiff.text = cardLeft.difficulty.ToString();
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

    public void RollDiceUI(Player player, int rollNum)
    {
        player.currentProperty.currentProgress += rollNum;
        progressBar.value = player.currentProperty.currentProgress;
    }

	public void EnterChangePropertyScreenUI (PropertyCard card1, PropertyCard card2, PropertyCard card3)
	{
		// call func from ui cont
	}
}
