using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{
    	public GameObject itemPrefab;
    	public Text[] cardText;
    	public Scrollbar scrollBar;

    	public void PopulateList (Player player)
	{
		
		RectTransform colRectTransform = itemPrefab.GetComponent<RectTransform> ();
		RectTransform containerRectTransform = gameObject.GetComponent<RectTransform> ();
	
		float height = containerRectTransform.rect.height;
		float width = colRectTransform.rect.width;
			       
		//adjust the height of the container so that it will just barely fit all its children
		float scrollWidth = width * (player.playerCardsProperty.Count - 1);
		float fill = scrollWidth / 2;
		containerRectTransform.offsetMin = new Vector2 (-fill, containerRectTransform.offsetMin.y);
		containerRectTransform.offsetMax = new Vector2 (fill, containerRectTransform.offsetMax.y);

		for (int i = 0; i < player.playerCardsProperty.Count - 1; i++)
		{
			//create a new item, name it, and set the parent
			GameObject newItem = Instantiate (itemPrefab) as GameObject;
			newItem.name = gameObject.name + " item at (" + i + ")";
			newItem.transform.SetParent (gameObject.transform, false);

			//move and size the new item
			RectTransform rectTransform = newItem.GetComponent<RectTransform> ();

			float x = -containerRectTransform.rect.width / 2 + width * i;
			float y = containerRectTransform.rect.height / 2 - height;
			rectTransform.offsetMin = new Vector2 (x, y);

			x = rectTransform.offsetMin.x + width;
			y = rectTransform.offsetMin.y + height;
			rectTransform.offsetMax = new Vector2 (x, y);

			cardText = newItem.GetComponentsInChildren<Text> ();
			string address = player.playerCardsProperty [i].address;
			int price = player.playerCardsProperty [i].price;
			int sqFoot = player.playerCardsProperty [i].sqFoot;
			string diff = player.playerCardsProperty [i].difficulty;

			for (int j = 0; j < cardText.Length; j++)
			{
				if (j == 0)
				{
					cardText[j].text = address;
				}
				if (j == 2)
				{
					cardText[j].text = price.ToString();
				}
				if (j == 4)
				{
					cardText[j].text = sqFoot.ToString();
				}
				if (j == 6)
				{
					cardText[j].text = diff.ToString();
				}				
			}
	        }
	}
}
