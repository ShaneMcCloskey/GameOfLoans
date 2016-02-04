using UnityEngine;
using System.Collections;
using System;

public class HighScore : IComparable<HighScore>{

	public string name;
	public string team;
	public int score;
	public int loansClosed;
	public HighScore(string Name,string Team,int Score,int LoansClosed){
	
		name = Name;
		team = Team;
		score = Score;
		loansClosed = LoansClosed;

	}

	public int CompareTo(HighScore other){
	
		if (other == null) {
			return 1;
		}
		return score - other.score;
	}
	
}

