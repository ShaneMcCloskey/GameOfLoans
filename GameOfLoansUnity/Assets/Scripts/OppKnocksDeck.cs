using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OppKnocksDeck : MonoBehaviour 
{
	public List<OppKnocksCard> cards = new List<OppKnocksCard>();

	void Awake()
	{
		// 1 = income, 2 = assets, 3 = credit
		cards.Add(new OppKnocksCard("Wealthy relative passes away, increase assts by $50,000", 50000, 2));
		cards.Add(new OppKnocksCard("Land a new job with a nice salary, increase income by $80,000", 80000, 1));
		cards.Add(new OppKnocksCard("You always pay your bills on time, increase credit score by 200", 200, 3));
		//cards.Add(
	}
}
