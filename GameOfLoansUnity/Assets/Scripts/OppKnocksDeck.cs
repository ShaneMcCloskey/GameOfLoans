using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OppKnocksDeck : MonoBehaviour 
{
	public List<OppKnocksCard> cards = new List<OppKnocksCard>();

	void Awake()
	{
		cards.Add(new OppKnocksCard("Test 1", 50, 0));
		cards.Add(new OppKnocksCard("Test 2", 40, 1));
		cards.Add(new OppKnocksCard("Test 2", -50, 0));
		//cards.Add(
	}
}
