using UnityEngine;
using System.Collections;
using System;

public class OppKnocksCard : IComparable<OppKnocksCard>
{
	//public Image pic;
	private string desc;
	private int val;
	private int category;

	public OppKnocksCard (string Desc, int Value, int Category)
	{
		desc = Desc;
		val = Value;	
		category = Category;
	}

	public string Desc
	{
		get { return desc; }
		set { desc = value; }
	}

	public int Value
	{
		get { return val; }
		set { val = value; }
	}

	public int Category
	{
		get { return category; }
		set { category = value; }
	}

	public int CompareTo(OppKnocksCard other)
	{
		if(other == null)
		{
			return 1;
		}

		// Return the difference in value.
		return val - other.val;
	}
}

