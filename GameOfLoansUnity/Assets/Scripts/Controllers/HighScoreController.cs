using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine.UI;
using Newtonsoft.Json;


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

	public IEnumerable GetScores(WWW www)
	{
		return JsonConvert.DeserializeObject<List<GameScore>>(www.text);
	}
		


}
