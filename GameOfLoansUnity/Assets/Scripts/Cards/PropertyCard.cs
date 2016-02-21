using UnityEngine;
using System.Collections;
using System;

public class PropertyCard : IComparable<PropertyCard> 
{
	//public Image pic;
	public string address;
	public int price;
	public int sqFoot;
	public string difficulty;
        public int numToClose;
        public int currentProgress;
        public bool subgoal1Complete;
	public bool subgoal2Complete;
	public bool subgoal3Complete;
	public bool subgoal4Complete;
	public bool subgoal5Complete;
	public bool subgoal6Complete;
	public bool subgoal7Complete;
	public bool subgoal8Complete;


	public PropertyCard (string Address, int Price, int SqFoot, string Difficulty, int NumToClose, int CurrentProgress,
		             bool Subgoal1Complete, bool Subgoal2Complete, bool Subgoal3Complete, bool Subgoal4Complete,
		             bool Subgoal5Complete, bool Subgoal6Complete, bool Subgoal7Complete, bool Subgoal8Complete)
	{
		//info = newInfo;
		address = Address;
		price = Price;
		sqFoot = SqFoot;
		difficulty = Difficulty;
	        numToClose = NumToClose;
	        currentProgress = CurrentProgress;
	        subgoal1Complete = Subgoal1Complete;
		subgoal2Complete = Subgoal2Complete;
		subgoal3Complete = Subgoal3Complete;
		subgoal4Complete = Subgoal4Complete;
		subgoal5Complete = Subgoal5Complete;
		subgoal6Complete = Subgoal6Complete;
		subgoal7Complete = Subgoal7Complete;
		subgoal8Complete = Subgoal8Complete;
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
