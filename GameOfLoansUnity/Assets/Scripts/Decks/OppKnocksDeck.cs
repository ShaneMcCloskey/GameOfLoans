using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OppKnocksDeck : MonoBehaviour 
{
	private List<OppKnocksCard> cards = new List<OppKnocksCard>();

	public List<OppKnocksCard> Cards
	{
		get { return cards; }
	}

	void Awake()
	{
		// 1 = income, 2 = assets, 3 = credit
		cards.Add(new OppKnocksCard("Card 1", 10, 1));
		cards.Add(new OppKnocksCard("Card 2", 20, 2));
		cards.Add(new OppKnocksCard("Card 3", 30, 3));
		cards.Add(new OppKnocksCard("Card 4", 10, 1));
		cards.Add(new OppKnocksCard("Card 5", 20, 2));
		cards.Add(new OppKnocksCard("Card 6", 30, 3));
		cards.Add(new OppKnocksCard("Card 7", 10, 1));
		cards.Add(new OppKnocksCard("Card 8", 20, 2));
		cards.Add(new OppKnocksCard("Card 9", 30, 3));
		cards.Add(new OppKnocksCard("Card 10", 10, 1));
		cards.Add(new OppKnocksCard("Card 11", 20, 2));
		cards.Add(new OppKnocksCard("Card 12", 30, 3));
		cards.Add(new OppKnocksCard("Card 13", 10, 1));
		cards.Add(new OppKnocksCard("Card 14", 20, 2));
		cards.Add(new OppKnocksCard("Card 15", 30, 3));
		cards.Add(new OppKnocksCard("Card 16", 10, 1));
		cards.Add(new OppKnocksCard("Card 17", 20, 2));
		cards.Add(new OppKnocksCard("Card 18", 30, 3));
		cards.Add(new OppKnocksCard("Card 19", 10, 1));
		cards.Add(new OppKnocksCard("Card 20", 20, 2));
		cards.Add(new OppKnocksCard("Card 21", 30, 3));
		cards.Add(new OppKnocksCard("Card 22", 10, 1));
		cards.Add(new OppKnocksCard("Card 23", 20, 2));
		cards.Add(new OppKnocksCard("Card 24", 30, 3));
		cards.Add(new OppKnocksCard("Card 25", 10, 1));
		cards.Add(new OppKnocksCard("Card 26", 20, 2));
		cards.Add(new OppKnocksCard("Card 27", 30, 3));
		cards.Add(new OppKnocksCard("Card 28", 10, 1));
		cards.Add(new OppKnocksCard("Card 29", 20, 2));
		cards.Add(new OppKnocksCard("Card 30", 30, 3));
		cards.Add(new OppKnocksCard("Card 31", 10, 1));
		cards.Add(new OppKnocksCard("Card 32", 20, 2));
		cards.Add(new OppKnocksCard("Card 33", 30, 3));
		cards.Add(new OppKnocksCard("Card 34", 10, 1));
		cards.Add(new OppKnocksCard("Card 35", 20, 2));
		cards.Add(new OppKnocksCard("Card 36", 30, 3));
		cards.Add(new OppKnocksCard("Card 37", 10, 1));
		cards.Add(new OppKnocksCard("Card 38", 20, 2));
		cards.Add(new OppKnocksCard("Card 39", 30, 3));
		cards.Add(new OppKnocksCard("Card 40", 10, 1));
		cards.Add(new OppKnocksCard("Card 41", 20, 2));
		cards.Add(new OppKnocksCard("Card 42", 30, 3));
		cards.Add(new OppKnocksCard("Card 43", 10, 1));
		cards.Add(new OppKnocksCard("Card 44", 20, 2));
		cards.Add(new OppKnocksCard("Card 45", 30, 3));
		cards.Add(new OppKnocksCard("Card 46", 10, 1));
		cards.Add(new OppKnocksCard("Card 47", 20, 2));
		cards.Add(new OppKnocksCard("Card 48", 30, 3));
		cards.Add(new OppKnocksCard("Card 49", 30, 3));
		cards.Add(new OppKnocksCard("Card 50", 30, 3));
	}
}
