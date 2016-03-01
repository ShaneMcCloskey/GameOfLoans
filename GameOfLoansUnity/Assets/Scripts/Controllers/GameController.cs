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
		player.NumTurnsLeft--;
		if (player.NumTurnsLeft == 40) // after 10 turns
		{
			isPickingStats = false;
		}
		int randNum = Random.Range (0, cardsOppKnocks.Count);   // pick random number
 
		OppKnocksCard card = cardsOppKnocks[randNum];           // draw card with random number
		UpdateOppKnocksCardTextAndPlayerStats(card);            // update text and player score

		player.PlayerCardsOppKnocks.Add (card);					// add card to player deck
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
			player.Income += card.value;
		} 
		else if (card.category == 2) 
		{
			player.Assets += card.value;
		} 
		else 
		{
			player.Credit += card.value;
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
			} 
			else
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
		player.NumTurnsLeft--;

		if (leftRightOrCenter == "left") 
		{
			player.PlayerCardsProperty.Add (cardLeft);
			player.CurrentProperty = cardLeft;
			cardsPropertyHunt.Remove(cardLeft); 
		} 
		else if (leftRightOrCenter == "center") 
		{
			player.PlayerCardsProperty.Add (cardCenter);
			player.CurrentProperty = cardCenter;
			cardsPropertyHunt.Remove(cardCenter); 
		} 
		else if (leftRightOrCenter == "right") 
		{
			player.PlayerCardsProperty.Add (cardRight);
			player.CurrentProperty = cardRight;
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
		player.PlayerCardsProperty.Remove(player.CurrentProperty);
		player.CurrentProperty = player.PlayerCardsProperty[0];
	}

        public void RollDie (GameObject PopUpPanel)
	{
		player.NumTurnsLeft--;
		int num = Random.Range (1, 7);
		player.CurrentProperty.currentProgress += num;

		int randEventNum = Random.Range (0, 100);
		bool randEventGood = false;
		bool randEventBad = false;

		if (randEventNum <= 10)
		{
			//bad
			randEventBad = true;

		}
		if (randEventNum > 10 && randEventNum <= 20)
		{
			// good
			randEventGood = true;
		}

		if (player.CurrentProperty.currentProgress >= player.CurrentProperty.numToClose)
		{
			player.Score += 1000;
			uiController.RollDiceUI (player, PopUpPanel, true, false, false);
			player.PlayerCardsProperty.Remove (player.CurrentProperty);
			player.CurrentProperty = null;
			if (player.PlayerCardsProperty.Count >= 1)
			{
				player.CurrentProperty = player.PlayerCardsProperty [0];
			}
		}
		else
		{	
			uiController.RollDiceUI(player,PopUpPanel, false, randEventGood, randEventBad);
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
