using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PropertyDeck : MonoBehaviour 
{
	public List<PropertyCard> cards = new List<PropertyCard>();

	void Awake()
	{
		cards.Add(new PropertyCard("68689 Highland Ct", 250000, 5, 3, 3000, 5000, "Single Family Home", 2, 32));
	}
}
