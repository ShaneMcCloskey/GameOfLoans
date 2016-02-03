﻿using UnityEngine;
using System.Collections;
using System;

public class PropertyCard : IComparable<PropertyCard> 
{
	//public Image pic;
	public string address;
	public int price;
	public int numBeds;
	public int numBaths;
	public int sqFoot;
	public int sqFootLot;
	public string type;
	public int difficulty;
	public int numRollsToClose;

	public PropertyCard (string Address, int Price, int NumBeds, int NumBaths, int SqFoot, int SqFootLot, string Type, int Difficulty, int NumRollsToClose)
	{
		//info = newInfo;
		address = Address;
		price = Price;
		numBeds = NumBeds;
		numBaths = NumBaths;
		sqFoot = SqFoot;
		sqFootLot = SqFootLot;
		type = Type;
		difficulty = Difficulty;
		numRollsToClose = NumRollsToClose;
	}

	public int CompareTo(PropertyCard other)
	{
		if(other == null)
		{
			return 1;
		}

		// Return the difference in value.
		return price - other.price;
	}
}
