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
	public void DrawOppKnocksCard (string leftRightOrCenter, Button oppKnocksButton, Button propHuntButton, Button loanInProgressButton)
	{
		if (player.NumTurnsLeft > 0) 
		{
			player.NumTurnsLeft--;

			if (player.NumTurnsLeft == 40) 						// after 10 turns
			{ 
				isPickingStats = false;
				propHuntButton.interactable = true;
				//loanInProgressButton.interactable = true;
			}
			int randNum = Random.Range (0, cardsOppKnocks.Count);    

			OppKnocksCard card = cardsOppKnocks [randNum];           		   // draw card with random number
			UpdateOppKnocksCardTextAndPlayerStats (card, leftRightOrCenter);            // update text and player score

			player.PlayerCardsOppKnocks.Add (card);                  		   // add card to player deck
			cardsOppKnocks.Remove (card);                	      			   // remove it from overall deck

			if (isPickingStats == false) {
				uiController.UpdateTurnsLeft (player);
			}
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
		CheckGameOver ();
	}

	// Property hunt functions ------------------------------------------------
	public void EnterPropertyHuntScreen (Button loanInProgressButton)
	{
		if (player.CurrentProperty != null)
		{
			loanInProgressButton.interactable = true;
		}
		else
		{
			loanInProgressButton.interactable = false;
		}
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
		if (player.NumTurnsLeft > 0) {
			player.NumTurnsLeft--;

			if (leftRightOrCenter == "left") {
				player.PlayerCardsProperty.Add (cardLeft);
				player.CurrentProperty = cardLeft;
				cardsPropertyHunt.Remove (cardLeft);
			} else if (leftRightOrCenter == "center") {
				player.PlayerCardsProperty.Add (cardCenter);
				player.CurrentProperty = cardCenter;
				cardsPropertyHunt.Remove (cardCenter);
			} else if (leftRightOrCenter == "right") {
				player.PlayerCardsProperty.Add (cardRight);
				player.CurrentProperty = cardRight;
				cardsPropertyHunt.Remove (cardRight);
			}
		}

	}

	// Loan in Progess functions -----------------------------------------------
	public void EnterLoanInProgressScreen(Button propertyPackButton, Button propHuntButton)
	{
		uiController.EnterLoanInProgressScreenUI(player);

		if (player.PlayerCardsProperty.Count >= 2)
		{
			propertyPackButton.interactable = true;
		}
		else
		{
			propertyPackButton.interactable = false;
		}

        // If player already has 3 properties
        if (player.PlayerCardsProperty.Count >= 3)
        {
            propHuntButton.interactable = false;
        }
        else
        {
            propHuntButton.interactable = true;
        }
	}

	public void EnterChangePropertyScreen()
	{
		uiController.EnterChangePropertyScreenUI(player);
	}

	public void ChangePropertyTo(int num)
	{
		player.CurrentProperty = player.PlayerCardsProperty[num];
	}

	public void CancelCurrentLoan(GameObject popUpPanel)
	{
		uiController.ShowPopUp("Are you sure you want to cancel this loan?", popUpPanel);
	}

	public void CancelCurrentLoanConfirmation ()
	{
		player.PlayerCardsProperty.Remove(player.CurrentProperty);
		player.CurrentProperty = null;
	}

	public void RollDie(GameObject PopUpPanel, GameObject PopUpPanelQuiz)
	{
		if (player.NumTurnsLeft > 0)
		{
			player.NumTurnsLeft--;
			player.CalculateMultiplier ();
			int num = Random.Range (1, 7);
			player.CurrentProperty.CurrentProgress += (int)(num*player.GetMultiplier());

			int randEventNum = Random.Range (0, 100);
			bool randEventGood = false;
			bool randEventBad = false;

			audioNew.PlayOneShot (diceRoll, .7F);


			if (randEventNum <= 5) {
				//bad
				randEventBad = true;

			}
			if (randEventNum > 5 && randEventNum <= 10) {
				// good
				randEventGood = true;
			}

			if (player.CurrentProperty.CurrentProgress >= player.CurrentProperty.NumToClose) {
				//Quiz Time
				uiController.RollDiceUI (player, PopUpPanelQuiz, true, false, false, num);
			} else {
				uiController.RollDiceUI (player, PopUpPanel, false, randEventGood, randEventBad, num);
				CheckGameOver ();
			}
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

	public void CheckGameOver()
	{
		if (player.NumTurnsLeft <= 0) 
		{
			ScoreController.SetPlayer (player);
		}
	}
    
	public void GetPropertyChoiceName(string leftRightOrCenter)
	{
		if(leftRightOrCenter == "left") 
		{
		    uiController.SetConfirmText(cardLeft);
		} 
		else if (leftRightOrCenter == "center")
		{
		    uiController.SetConfirmText(cardCenter);
		}
		else if (leftRightOrCenter == "right")
		{
		    uiController.SetConfirmText(cardRight);
		}
	}
}
