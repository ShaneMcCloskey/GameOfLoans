using UnityEngine;
using System.Collections;
using System;


public class PropertyCard : IComparable<PropertyCard> 
{
	private string title;
	private string address;
	private int price;
	private string difficulty;
        private int numToClose;
        private int currentProgress;
	private Sprite pic;
        private bool subgoal1Complete;
	private bool subgoal2Complete;
	private bool subgoal3Complete;
	private bool subgoal4Complete;
	private bool subgoal5Complete;
	private bool subgoal6Complete;
	private bool subgoal7Complete;
	private bool subgoal8Complete;

	public PropertyCard (string Title, string Address, int Price, string Difficulty, int NumToClose, int CurrentProgress, Sprite Pic,
		             bool Subgoal1Complete, bool Subgoal2Complete, bool Subgoal3Complete, bool Subgoal4Complete,
		             bool Subgoal5Complete, bool Subgoal6Complete, bool Subgoal7Complete, bool Subgoal8Complete)
	{
		title = Title;
		address = Address;
		price = Price;
		difficulty = Difficulty;
	        numToClose = NumToClose;
	        currentProgress = CurrentProgress;
	        pic = Pic;
	        subgoal1Complete = Subgoal1Complete;
		subgoal2Complete = Subgoal2Complete;
		subgoal3Complete = Subgoal3Complete;
		subgoal4Complete = Subgoal4Complete;
		subgoal5Complete = Subgoal5Complete;
		subgoal6Complete = Subgoal6Complete;
		subgoal7Complete = Subgoal7Complete;
		subgoal8Complete = Subgoal8Complete;
	}

	public string Title
	{
		get { return title; }
		set { title = value; }
	}

	public string Address
	{
		get { return address; }
		set { address = value; }
	}

	public int Price
	{
		get { return price; }
		set { price = value; }
	}

	public string Difficulty
	{
		get { return difficulty; }
		set { difficulty = value; }
	}

	public int NumToClose
	{
		get { return numToClose; }
		set { numToClose = value; }
	}

	public int CurrentProgress
	{
		get { return currentProgress; }
		set { currentProgress = value; }
	}

	public Sprite Pic
	{
		get { return pic; }
		set { pic = value; }
	}

	public bool Subgoal1Complete
	{
		get { return subgoal1Complete; }
		set { subgoal1Complete = value; }
	}

	public bool Subgoal2Complete
	{
		get { return subgoal2Complete; }
		set { subgoal2Complete = value; }
	}

	public bool Subgoal3Complete
	{
		get { return subgoal3Complete; }
		set { subgoal3Complete = value; }
	}

	public bool Subgoal4Complete
	{
		get { return subgoal4Complete; }
		set { subgoal4Complete = value; }
	}

	public bool Subgoal5Complete
	{
		get { return subgoal5Complete; }
		set { subgoal5Complete = value; }
	}

	public bool Subgoal6Complete
	{
		get { return subgoal6Complete; }
		set { subgoal6Complete = value; }
	}

	public bool Subgoal7Complete
	{
		get { return subgoal7Complete; }
		set { subgoal7Complete = value; }
	}

	public bool Subgoal8Complete
	{
		get { return subgoal8Complete; }
		set { subgoal8Complete = value; }
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
