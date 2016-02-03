using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	private Player player;
	private OppKnocksDeck oppKnocksDeck;

	private List<OppKnocksCard> cardsOppKnocks = new List<OppKnocksCard>();

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
		oppKnocksDeck = gameObject.GetComponent<OppKnocksDeck>();
		cardsOppKnocks = oppKnocksDeck.cards;
		incomeText.text = "Income: 0";
		assetsText.text = "Assets: 0";
		creditText.text = "Credit: 0";
		turnText.text = "Turns Left: 40";
	}

	public void DrawOppKnocksCard ()
	{
		int randNum = Random.Range (0, cardsOppKnocks.Count);   // pick random number
		Debug.Log (randNum);
		OppKnocksCard card = cardsOppKnocks[randNum];           // draw card with random number
		UpdateOppKnocksCardTextAndPlayerStats(card);            // update text and player score
		player.numTurnsLeft--;
		turnText.text = "Turns Left: " + player.numTurnsLeft;
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
}
