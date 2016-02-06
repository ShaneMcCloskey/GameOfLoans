using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	public int score = 0;
	public int numTurnsLeft = 50;
	public float income = 100f;
	public float assets = 100f;
	public float credit = 100f;
	public PropertyCard currentProperty;

	public List<OppKnocksCard> playerCardsOppKnocks = new List<OppKnocksCard>();
	public List<PropertyCard> playerCardsProperty = new List<PropertyCard>();
}
