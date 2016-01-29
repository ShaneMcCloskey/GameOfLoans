using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OppKnocksCard : MonoBehaviour 
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
}

