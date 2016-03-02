using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropertyDeck : MonoBehaviour 
{
	private List<PropertyCard> cards = new List<PropertyCard>();

	public List<PropertyCard> Cards
	{
		get { return cards; }
	}

	void Awake()
	{
		// difficulty, easy = 1, medium = 2, hard = 3
		cards.Add(new PropertyCard("Address 1", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 2", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 3", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 4", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 5", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 6", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 7", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false,false, false));
		cards.Add(new PropertyCard("Address 8", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 9", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 10", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 11", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 12", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 13", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 14", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 15", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 16", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 17", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 18", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 19", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 20", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 21", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 22", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 23", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 24", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 25", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 26", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 27", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 28", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 29", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 30", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 31", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 32", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 33", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 34", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 35", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 36", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 37", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 38", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 39", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 40", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 41", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 42", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 43", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 44", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 45", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 46", 100, 1000, "Easy", 54, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 47", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 48", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 49", 200, 2000, "Medium", 81, 0, false, false, false, false, false, false, false, false));
		cards.Add(new PropertyCard("Address 50", 300, 3000, "Hard", 108, 0, false, false, false, false, false, false, false, false));
	}
}
