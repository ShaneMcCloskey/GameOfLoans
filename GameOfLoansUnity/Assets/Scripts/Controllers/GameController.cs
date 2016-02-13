using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	// private vars ---------------------------------------
	private Player player;
	private UIController uiController;
	private OppKnocksDeck fullOppKnocksDeck;
	private PropertyDeck fullPropertyDeck;
	private List<OppKnocksCard> cardsOppKnocks = new List<OppKnocksCard>();
	private List<PropertyCard> cardsPropertyHunt = new List<PropertyCard> ();
	private bool isPickingStats = true;
	private PropertyCard cardLeft;
	private PropertyCard cardRight;
	private bool firstEnterIntoChangeProp = false;
	//private 


        // public vars ---------------------------------------

        // Game init ------------------------------------
        void Awake()
	{
		player = gameObject.GetComponent<Player> ();
		uiController = gameObject.GetComponent<UIController>();
		fullOppKnocksDeck = gameObject.GetComponent<OppKnocksDeck>();
		fullPropertyDeck = gameObject.GetComponent<PropertyDeck> ();
		cardsOppKnocks = fullOppKnocksDeck.cards;
		cardsPropertyHunt = fullPropertyDeck.cards;
		uiController.AwakeUI();

	
	}

	// Opp knocks functions ------------------------------
	public void EnterOppKnocksScreen()
	{
		uiController.EnterOppKnocksScreenUI();
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
			uiController.UpdateTurnsLeft(player);
		} 
	}

	void UpdateOppKnocksCardTextAndPlayerStats(OppKnocksCard card)
	{
		if (card.category == 1) 
		{
			player.income += card.value;
		} 
		else if (card.category == 2) 
		{
			player.assets += card.value;
		} 
		else 
		{
			player.credit += card.value;
		}
		uiController.UpdateOppKnocksCardTextAndPlayerStatsUI(card, player);
	}

	// Property hunt functions ------------------------------------------------
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

		uiController.EnterPropertyHuntScreeUI(cardLeft, cardRight);
	}

	public void DrawPropertyCard(string leftOrRight)
	{
		player.numTurnsLeft--;

		if (leftOrRight == "left") 
		{
			player.playerCardsProperty.Add (cardLeft);
			player.currentProperty = cardLeft; 
		} 
		else if (leftOrRight == "right") 
		{
			player.playerCardsProperty.Add (cardRight);
			player.currentProperty = cardRight;
		}
	}

	// Loan in Progess functions -----------------------------------------------
	public void EnterLoanInProgressScreen()
	{
		uiController.EnterLoanInProgressScreenUI(player);
	}

	public void EnterChangePropertyScreen ()
	{
		// call function on scrollable list
		GameObject go = GameObject.FindGameObjectWithTag ("ScrollableProperty");
		ScrollableList other = (ScrollableList)go.GetComponent (typeof(ScrollableList));
		if (firstEnterIntoChangeProp == false)
		{
			other.PopulateList(player);
			firstEnterIntoChangeProp = true;
		}
		// else call function to add to current list
	}

	public void CancelCurrentLoan ()
	{
		player.playerCardsProperty.Remove(player.currentProperty);
		player.currentProperty = player.playerCardsProperty[0];
	}

        public void RollDie()
        {
        	int num = Random.Range(1, 7);
        	Debug.Log(num);
        	uiController.RollDiceUI(player, num);
        }
}
