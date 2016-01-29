using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropertyDeck : MonoBehaviour 
{
	public List<PropertyCard> cards = new List<PropertyCard>();

	void Awake()
	{
		cards.Add(new PropertyCard("Test 1"));
		cards.Add(new PropertyCard("Test 2"));
		cards.Add(new PropertyCard("Test 2"));
		//cards.Add(
	}
}
