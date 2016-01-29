using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
	private Player player;
	private OppKnocksDeck deck;

	private List<OppKnocksCard> cards = new List<OppKnocksCard>();

	public Text okText;
	public Text incomeText;
	public Text assetsText;
	public Text creditText;


	void Awake()
	{
		player = gameObject.GetComponent<Player> ();
		deck = gameObject.GetComponent<OppKnocksDeck>();
		cards = deck.cards;
		okText.text = cards[0].info;
		incomeText.text = "Income: 0";
		assetsText.text = "Assets: 0";
		creditText.text = "Credit: 0";
	}

	public void DrawCard ()
	{
		if (cards[0].category == 0) // income
		{ 
			player.income += cards[0].value;
			incomeText.text = "Income: " + player.income.ToString();
		} 
		else if (cards[0].category == 1) // assets
		{ 
			player.assets += cards[0].value;
			assetsText.text = "Assets: " + player.assets.ToString();
		} 
		else if (cards[0].category == 2) // credit
		{
			player.credit += cards[0].value;
			creditText.text = "Credit: " + player.credit.ToString();
		}
	}




}
