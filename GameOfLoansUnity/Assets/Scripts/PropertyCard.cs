using UnityEngine;
using System.Collections;
using System;

public class PropertyCard : IComparable<PropertyCard> 
{
	//public Image pic;
	public string address;
	public int price;
	public int sqFoot;
	public int difficulty;

	public PropertyCard (string Address, int Price, int SqFoot, int Difficulty)
	{
		//info = newInfo;
		address = Address;
		price = Price;
		sqFoot = SqFoot;
		difficulty = Difficulty;
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
