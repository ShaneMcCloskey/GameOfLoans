using UnityEngine;
using System.Collections;
using System;

public class OppKnocksCard : IComparable<OppKnocksCard>
{
	//public Image pic;
	public string info;
	public int value;
	public int category;

	public OppKnocksCard (string newInfo, int newValue, int newCategory)
	{
		info = newInfo;
		value = newValue;	
		category = newCategory;
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

