using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{
    	public GameObject itemPrefab;
    	public Text[] cardText;
    	public Scrollbar scrollBar;

    	private RectTransform colRectTransform;
    	private RectTransform containerRectTransform;
    	private float cardHeight;
    	private float cardWidth;
    	private float scrollWidth;
    	private float fill;
	private GameObject newItem;
	private List<GameObject> itemList = new List<GameObject>();


    	void Start()
    	{
		colRectTransform = itemPrefab.GetComponent<RectTransform> ();
		containerRectTransform = gameObject.GetComponent<RectTransform> ();
		cardHeight = containerRectTransform.rect.height;
		cardWidth = colRectTransform.rect.width;
    	}

    	public void PopulateList (Player player, bool first)
	{
		// need to get what has already been drawn on panel and get rid or it or add to it
		if (first)
		{
			colRectTransform = itemPrefab.GetComponent<RectTransform> ();
			containerRectTransform = gameObject.GetComponent<RectTransform> ();
			cardHeight = containerRectTransform.rect.height;
			cardWidth = colRectTransform.rect.width;
			//adjust the height of the container so that it will just barely fit all its children
			scrollWidth = cardWidth * (player.PlayerCardsProperty.Count - 1);
			fill = scrollWidth / 2;
			containerRectTransform.offsetMin = new Vector2 (-fill, containerRectTransform.offsetMin.y);
			containerRectTransform.offsetMax = new Vector2 (fill, containerRectTransform.offsetMax.y);
		} else
		{
			scrollWidth = cardWidth * (player.PlayerCardsProperty.Count - 1);
			fill = scrollWidth / 2;
			containerRectTransform.offsetMin = new Vector2 (-fill, containerRectTransform.offsetMin.y);
			containerRectTransform.offsetMax = new Vector2 (fill, containerRectTransform.offsetMax.y);
		}

		if (first)
		{
			Populate(player);
		} 
		else
		{
			foreach (Transform child in transform)
			{
			  	Debug.Log(child.name);
			  	Destroy(child);
			}
			Populate(player);
		}
	}

	void Populate(Player player)
	{
		for (int i = 0; i < player.PlayerCardsProperty.Count - 1; i++)
		{
			for (int k = 0; k < player.PlayerCardsProperty.Count - 1; k++)
			{
				newItem = Instantiate (itemPrefab) as GameObject;
				itemList.Add (newItem);
			}

			itemList [i].name = gameObject.name + " item at (" + i + ")";
			itemList [i].transform.SetParent (gameObject.transform, false);

			       
			//move and size the new item
			RectTransform rectTransform = itemList [i].GetComponent<RectTransform> ();

			float x = -containerRectTransform.rect.width / 2 + cardWidth * i;
			float y = containerRectTransform.rect.height / 2 - cardHeight;
			rectTransform.offsetMin = new Vector2 (x, y);

			x = rectTransform.offsetMin.x + cardWidth;
			y = rectTransform.offsetMin.y + cardHeight;
			rectTransform.offsetMax = new Vector2 (x, y);

			cardText = itemList[i].GetComponentsInChildren<Text> ();
			string address = player.PlayerCardsProperty [i].address;
			int price = player.PlayerCardsProperty [i].price;
			int sqFoot = player.PlayerCardsProperty [i].sqFoot;
			string diff = player.PlayerCardsProperty [i].difficulty;

			for (int j = 0; j < cardText.Length; j++)
			{
				if (j == 0)
				{
					cardText [j].text = address;
				}
				if (j == 2)
				{
					cardText [j].text = price.ToString ();
				}
				if (j == 4)
				{
					cardText [j].text = sqFoot.ToString ();
				}
				if (j == 6)
				{
					cardText [j].text = diff.ToString ();
				}				
			}
		}
	}
}
