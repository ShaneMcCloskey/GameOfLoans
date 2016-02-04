using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour 
{
	public GameObject grid;
	List<HighScore> scores = new List<HighScore> ();
	// Use this for initialization
	void Start () 
	{

		scores.Add (new HighScore("Tim","Team1",5000,5));
	}

}
