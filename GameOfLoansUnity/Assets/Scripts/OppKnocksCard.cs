using UnityEngine;
using System.Collections;
using System;

public class OppKnocksCard : IComparable<OppKnocksCard>
{
	//public Image pic;
	public string desc;
	public int value;
	public int category;

	public OppKnocksCard (string Desc, int Value, int Category)
	{
		desc = Desc;
		value = Value;	
		category = Category;
	}

	public int CompareTo(OppKnocksCard other)
	{
		if(other == null)
		{
			return 1;
		}

		// Return the difference in value.
		return value - other.value;
	}
}

