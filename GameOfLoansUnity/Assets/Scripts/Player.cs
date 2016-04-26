using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
	private int score = 0;
	private int numTurnsLeft = 50;
	private float income = 1000f;
	private float assets = 1000f;
	private float credit = 450f;
    private float startingCredit = 450f;
	private float maxIncome = 10000f;
	private float maxAssets = 45000f;
	private float maxCredit = 800f;
    private float baseMultiplier = 3f;
	private PropertyCard currentProperty;
	private int numPropertiesClosed = 0;
	private List<OppKnocksCard> playerCardsOppKnocks = new List<OppKnocksCard>();
	private List<PropertyCard> playerCardsProperty = new List<PropertyCard>();

	public int Score
	{
		get { return score; }
		set { score = value; }
	}

	public int NumTurnsLeft
	{
		get { return numTurnsLeft; }
		set { numTurnsLeft = value; }
	}

	public float Income
	{
		get { return income; }
		set { income = value; }
	}

	public float Assets
	{
		get { return assets; }
		set { assets = value; }
	}

	public float Credit
	{
		get { return credit; }
		set { credit = value; }
	}

	public PropertyCard CurrentProperty
	{
		get { return currentProperty; }
		set { currentProperty = value; }
	}

	public int NumPropertiesClosed
	{
		get { return numPropertiesClosed; }
		set { numPropertiesClosed = value; }
	}

	public List<OppKnocksCard> PlayerCardsOppKnocks
	{
		get { return playerCardsOppKnocks; }
		set { playerCardsOppKnocks = value; }
	}

	public List<PropertyCard> PlayerCardsProperty
	{
		get { return playerCardsProperty; }
		set { playerCardsProperty = value; }
	}

	public float GetMultiplier()
	{
		return baseMultiplier + (2f * (income / maxIncome + ((credit - startingCredit) / (maxCredit - startingCredit)) + assets / maxAssets) / 3);
    }

    public float GetBaseMultiplier()
    {
        return baseMultiplier;
    }
}
