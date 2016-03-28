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
	public HighScoreController ScoreController;
	private OppKnocksDeck fullOppKnocksDeck;
	private PropertyDeck fullPropertyDeck;
	private List<OppKnocksCard> cardsOppKnocks = new List<OppKnocksCard>();
	private List<PropertyCard> cardsPropertyHunt = new List<PropertyCard>();
	private bool isPickingStats = true;
	private PropertyCard cardLeft;
	private PropertyCard cardCenter;
	private PropertyCard cardRight;
	private AudioSource audioNew;

	// public vars ---------------------------------------
	public AudioClip diceRoll;

	// Game init ------------------------------------
	void Awake()
	{
		player = gameObject.GetComponent<Player>();
		uiController = gameObject.GetComponent<UIController>();
		fullOppKnocksDeck = gameObject.GetComponent<OppKnocksDeck>();
		fullPropertyDeck = gameObject.GetComponent<PropertyDeck>();
		cardsOppKnocks = fullOppKnocksDeck.Cards;
		cardsPropertyHunt = fullPropertyDeck.Cards;
		uiController.AwakeUI();
		audioNew = gameObject.GetComponent<AudioSource>();
	}

	// Opp knocks functions ------------------------------

	public void DrawOppKnocksCard (string leftRightOrCenter)
	{
		player.NumTurnsLeft--;

		if (player.NumTurnsLeft == 40) // after 10 turns
		{
		    isPickingStats = false;
		}
		int randNum = Random.Range(0, cardsOppKnocks.Count);    

		OppKnocksCard card = cardsOppKnocks[randNum];           		   // draw card with random number
		UpdateOppKnocksCardTextAndPlayerStats(card, leftRightOrCenter);            // update text and player score

		player.PlayerCardsOppKnocks.Add(card);                  		   // add card to player deck
		cardsOppKnocks.Remove(card);                	      			   // remove it from overall deck

		if (isPickingStats == false)
		{
		    uiController.UpdateTurnsLeft(player);
		}
	}

	void UpdateOppKnocksCardTextAndPlayerStats(OppKnocksCard card, string leftRightOrCenter)
	{
		if (card.Category == 1)
		{
		    player.Income += card.Value;
		}
		else if (card.Category == 2)
		{
		    player.Assets += card.Value;
		}
		else
		{
		    player.Credit += card.Value;
		}
		uiController.UpdateOppKnocksCardTextAndPlayerStatsUI(card, player, leftRightOrCenter);
	}

	// Property hunt functions ------------------------------------------------
	public void EnterPropertyHuntScreen()
	{
		int randLeft = Random.Range(0, cardsPropertyHunt.Count);
		int randCenter = Random.Range(0, cardsPropertyHunt.Count);
		int randRight = Random.Range(0, cardsPropertyHunt.Count);
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
		cardLeft = cardsPropertyHunt[randLeft];
		cardCenter = cardsPropertyHunt[randCenter];
		cardRight = cardsPropertyHunt[randRight];
		while (cardLeft.Difficulty != "Easy")
		{
		    randLeft = Random.Range(0, cardsPropertyHunt.Count);
		    cardLeft = cardsPropertyHunt[randLeft];
		}
		while (cardCenter.Difficulty != "Medium")
		{
		    randCenter = Random.Range(0, cardsPropertyHunt.Count);
		    cardCenter = cardsPropertyHunt[randCenter];
		}
		while (cardRight.Difficulty != "Hard")
		{
		    randRight = Random.Range(0, cardsPropertyHunt.Count);
		    cardRight = cardsPropertyHunt[randRight];
		}
		uiController.EnterPropertyHuntScreeUI(cardLeft, cardCenter, cardRight);
	}

	public void DrawPropertyCard(string leftRightOrCenter)
	{
		player.NumTurnsLeft--;

		if (leftRightOrCenter == "left")
		{
		    player.PlayerCardsProperty.Add(cardLeft);
		    player.CurrentProperty = cardLeft;
		    cardsPropertyHunt.Remove(cardLeft);
		}
		else if (leftRightOrCenter == "center")
		{
		    player.PlayerCardsProperty.Add(cardCenter);
		    player.CurrentProperty = cardCenter;
		    cardsPropertyHunt.Remove(cardCenter);
		}
		else if (leftRightOrCenter == "right")
		{
		    player.PlayerCardsProperty.Add(cardRight);
		    player.CurrentProperty = cardRight;
		    cardsPropertyHunt.Remove(cardRight);
		}
	}

	// Loan in Progess functions -----------------------------------------------
	public void EnterLoanInProgressScreen()
	{
		uiController.EnterLoanInProgressScreenUI(player);
	}

	public void EnterChangePropertyScreen()
	{
		uiController.EnterChangePropertyScreenUI(player);
	}

	public void ChangePropertyTo(int num)
	{
		player.CurrentProperty = player.PlayerCardsProperty[num];
	}

	public void CancelCurrentLoan()
	{
		player.PlayerCardsProperty.Remove(player.CurrentProperty);
		player.CurrentProperty = player.PlayerCardsProperty[0];
	}

	public void RollDie(GameObject PopUpPanel, GameObject PopUpPanelQuiz)
	{
		player.NumTurnsLeft--;
		int num = Random.Range(1, 7);
		player.CurrentProperty.CurrentProgress += num;

		int randEventNum = Random.Range(0, 100);
		bool randEventGood = false;
		bool randEventBad = false;

		audioNew.PlayOneShot(diceRoll, .7F);

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

		if (player.CurrentProperty.CurrentProgress >= player.CurrentProperty.NumToClose)
		{
		    //Quiz Time
		    uiController.RollDiceUI(player, PopUpPanelQuiz, true, false, false);
		}

		else
		{
		    uiController.RollDiceUI(player, PopUpPanel, false, randEventGood, randEventBad);
		}
	}

	public void ProcessOkButton(GameObject popUpPanel, GameObject popUpPanelNeedProp, GameObject propHuntPanel, GameObject quizPanel)
	{
		// call ui function...
		uiController.ProcessOkButtonUI(popUpPanel, popUpPanelNeedProp, propHuntPanel, quizPanel, player);
	}

	// Process Quiz Button Answer
	public void ProcessAnswer(GameObject quizPanel, GameObject popUpPanel, string letter)
	{
		// call ui function...
		uiController.ProcessAnswerUI(quizPanel, popUpPanel, player, letter);
	}
}
