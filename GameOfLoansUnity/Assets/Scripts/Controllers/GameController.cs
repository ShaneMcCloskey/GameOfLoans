using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	private Player player;

	private OppKnocksDeck fullOppKnocksDeck;
	private PropertyDeck fullPropertyDeck;

	private List<OppKnocksCard> cardsOppKnocks = new List<OppKnocksCard>();
	private List<PropertyCard> cardsPropertyHunt = new List<PropertyCard> ();
	private bool isPickingStats = true;
	private PropertyCard cardLeft;
	private PropertyCard cardRight;

	// HUD text elements
	public Text okText;
	public Text incomeText;
	public Text assetsText;
	public Text creditText;
	public Text turnText;
	// Opp knocks card text elements
	public Text textOppKnocksType;
	public Text textOppKnocksDesc;


	void Awake()
	{
		player = gameObject.GetComponent<Player> ();
		fullOppKnocksDeck = gameObject.GetComponent<OppKnocksDeck>();
		cardsOppKnocks = fullOppKnocksDeck.cards;
		incomeText.text = "Income: 0";
		assetsText.text = "Assets: 0";
		creditText.text = "Credit: 0";
		turnText.text = "Turns Left: 40";
	}

	public void DrawOppKnocksCard ()
	{
		player.numTurnsLeft--;
		if (player.numTurnsLeft == 40) // after 10 turns
		{
			isPickingStats = false;
		}
		int randNum = Random.Range (0, cardsOppKnocks.Count);   // pick random number
 
		OppKnocksCard card = cardsOppKnocks[randNum];           // draw card with random number
		UpdateOppKnocksCardTextAndPlayerStats(card);            // update text and player score

		player.playerCardsOppKnocks.Add (card);					// add card to player deck
		cardsOppKnocks.Remove (card);  							// remove it from overall deck

		if (isPickingStats == false) 
		{
			turnText.text = "Turns Left: " + player.numTurnsLeft;
		} 

		Debug.Log (player.numTurnsLeft);
	}

	void UpdateOppKnocksCardTextAndPlayerStats(OppKnocksCard card)
	{
		textOppKnocksDesc.text = card.desc;

		if (card.category == 1) 
		{
			textOppKnocksType.text = "Income Card";
			player.income += card.value;
			incomeText.text = "Income: " + player.income.ToString();
		} 
		else if (card.category == 2) 
		{
			textOppKnocksType.text = "Asset Card";
			player.assets += card.value;
			assetsText.text = "Assets: " + player.assets.ToString();
		} 
		else 
		{
			textOppKnocksType.text = "Credit Card";
			player.credit += card.value;
			creditText.text = "Credit: " + player.credit.ToString();
		}
	}


	public void EnterPropertyHuntScreen()
	{
		int randLeft = Random.Range (0, cardsPropertyHunt.Count);
		int randRight = Random.Range (0, cardsPropertyHunt.Count);
		if (randLeft == randRight) 
		{
			if (randRight < cardsPropertyHunt.Count)
			{
				randRight++;
			} 
			else
			{
				randRight--;
			}
		}
		cardLeft = cardsPropertyHunt [randLeft];
		cardRight = cardsPropertyHunt [randRight];

		/*leftAddress.text = cardLeft.address;
		leftPrice.text = cardLeft.price.ToString();
		leftSqFoot.text = cardLeft.sqFoot.ToString();
		leftDifficulty.text = cardLeft.difficulty.ToString();
		rightAddress.text = cardRight.address;
		rightPrice.text = cardRight.price.ToString();
		rightSqFoot.text = cardRight.sqFoot.ToString();
		rightDifficulty.text = cardRight.difficulty.ToString();*/
	}

	public void DrawPropertyCard(string leftOrRight)
	{
		player.numTurnsLeft--;

		if (leftOrRight == "left") 
		{
			player.playerCardsProperty.Add (cardLeft);
		} 
		else if (leftOrRight == "right") 
		{
			player.playerCardsProperty.Add (cardRight);
		}
	}

}
