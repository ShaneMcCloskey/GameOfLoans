using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Runtime.Serialization;


public class HighScoreController : MonoBehaviour {
	public Player player;
	public Text textbox;

	public string getscores = "http://35.9.22.106/Api/HighScores/GetHighScores?n=4";

	public void Start(){
		WWW www = new WWW (getscores);
		StartCoroutine (WaitRequestGet (www));
	}

	private IEnumerator WaitRequestGet(WWW www){
	
		yield return www;
		GetScores (www);
	}

	public void GetScores(WWW www)
	{
		 
		ArrayOfGameScores data = JsonUtility.FromJson<ArrayOfGameScores> (www.text);

		textbox.text = data.ArrayOfGameScore[0].Name;

	}
		


}
