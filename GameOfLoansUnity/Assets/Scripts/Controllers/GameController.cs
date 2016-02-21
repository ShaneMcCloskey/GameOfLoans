using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

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
	private PropertyCard cardCenter;
	private PropertyCard cardRight;
	private bool firstEnterIntoChangeProp = true;
	private ScrollableList propertyScrollList;
	//private 

	public EventSystem es;


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
		GameObject go = GameObject.FindGameObjectWithTag ("ScrollableProperty");
		propertyScrollList = (ScrollableList)go.GetComponent (typeof(ScrollableList));
	
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
		cardsOppKnocks.Remove (card);  						// remove it from overall deck

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
	public void EnterPropertyHuntScreen ()
	{
		int randLeft = Random.Range (0, cardsPropertyHunt.Count);
		int randCenter = Random.Range (0, cardsPropertyHunt.Count);
		int randRight = Random.Range (0, cardsPropertyHunt.Count);
		if (randLeft == randRight)
		{
			if (randRight < cardsPropertyHunt.Count)
			{
				randRight++;
			} else
			{
				randRight--;
			}
		}
		cardLeft = cardsPropertyHunt [randLeft];
		cardCenter = cardsPropertyHunt [randCenter];
		cardRight = cardsPropertyHunt [randRight];
		while (cardLeft.difficulty != "Easy")
		{
			randLeft = Random.Range (0, cardsPropertyHunt.Count);
			cardLeft = cardsPropertyHunt [randLeft];
		}
		while (cardCenter.difficulty != "Medium")
		{
			randCenter = Random.Range (0, cardsPropertyHunt.Count);
			cardCenter = cardsPropertyHunt [randCenter];
		}
		while (cardRight.difficulty != "Hard")
		{
			randRight = Random.Range (0, cardsPropertyHunt.Count);
			cardRight = cardsPropertyHunt [randRight];
		}
		uiController.EnterPropertyHuntScreeUI(cardLeft, cardCenter, cardRight);
	}

	public void DrawPropertyCard(string leftRightOrCenter)
	{
		player.numTurnsLeft--;

		if (leftRightOrCenter == "left") 
		{
			player.playerCardsProperty.Add (cardLeft);
			player.currentProperty = cardLeft;
			cardsPropertyHunt.Remove(cardLeft); 
		} 
		else if (leftRightOrCenter == "center") 
		{
			player.playerCardsProperty.Add (cardCenter);
			player.currentProperty = cardCenter;
			cardsPropertyHunt.Remove(cardCenter); 
		} 
		else if (leftRightOrCenter == "right") 
		{
			player.playerCardsProperty.Add (cardRight);
			player.currentProperty = cardRight;
			cardsPropertyHunt.Remove(cardRight);
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

		if (firstEnterIntoChangeProp == true)
		{
			propertyScrollList.PopulateList (player, true);
			firstEnterIntoChangeProp = false;
		} 
		else
		{
			propertyScrollList.PopulateList(player, false);
		}
		// else call function to add to current list
	}

	public void CancelCurrentLoan ()
	{
		player.playerCardsProperty.Remove(player.currentProperty);
		player.currentProperty = player.playerCardsProperty[0];
	}

        public void RollDie (GameObject PopUpPanel)
	{
		player.numTurnsLeft--;
		int num = Random.Range (1, 7);
		player.currentProperty.currentProgress += num;
		if (player.currentProperty.currentProgress >= player.currentProperty.numToClose)
		{
			player.score += 1000;
			uiController.RollDiceUI (player, num, PopUpPanel, true);
			player.playerCardsProperty.Remove (player.currentProperty);
			player.currentProperty = null;
			if (player.playerCardsProperty.Count >= 1)
			{
				player.currentProperty = player.playerCardsProperty[0];
			}
		} 
		else
		{
			uiController.RollDiceUI (player, num, PopUpPanel, false);
		}
        }

        public void ProcessOkButton (GameObject popUpPanel, GameObject popUpPanelNeedProp, GameObject propHuntPanel)
	{
		// call ui function...
		uiController.ProcessOkButtonUI (popUpPanel, popUpPanelNeedProp, propHuntPanel, player);
	}

      

        public void Test ()
	{
	}
}
