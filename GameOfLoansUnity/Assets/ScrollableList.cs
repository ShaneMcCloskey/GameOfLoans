using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ScrollableList : MonoBehaviour
{
    public GameObject itemPrefab;
    public int itemCount = 1;

    void Start()
    {
        RectTransform colRectTransform = itemPrefab.GetComponent<RectTransform>();
        RectTransform containerRectTransform = gameObject.GetComponent<RectTransform>();

        //float width = containerRectTransform.rect.width / columnCount;
	float height = containerRectTransform.rect.height;
        //float ratio = width / rowRectTransform.rect.width;
        float ratio = height / colRectTransform.rect.height;
        //float height = rowRectTransform.rect.height * ratio;
        float width = colRectTransform.rect.width * ratio;
        //int rowCount = itemCount / columnCount;
       

        //adjust the height of the container so that it will just barely fit all its children
        //float scrollHeight = height * rowCount;
        float scrollWidth = width * itemCount;
        //containerRectTransform.offsetMin = new Vector2(containerRectTransform.offsetMin.x, -scrollHeight / 2);
        containerRectTransform.offsetMin = new Vector2(-scrollWidth / 2, containerRectTransform.offsetMin.y);
        //containerRectTransform.offsetMax = new Vector2(containerRectTransform.offsetMax.x, scrollHeight / 2);
	containerRectTransform.offsetMax = new Vector2(scrollWidth / 2, containerRectTransform.offsetMax.y);




        for (int i = 0; i < itemCount; i++)
        {
            //create a new item, name it, and set the parent
            GameObject newItem = Instantiate(itemPrefab) as GameObject;
            newItem.name = gameObject.name + " item at (" + i + ")";
            newItem.transform.parent = gameObject.transform;

	    //move and size the new item
            RectTransform rectTransform = newItem.GetComponent<RectTransform>();

            //float x = -containerRectTransform.rect.width / 2 + width * (i % columnCount);
            float x = -containerRectTransform.rect.width / 2 + width * i;
            //float y = containerRectTransform.rect.height / 2 - height * j;
            float y = containerRectTransform.rect.height / 2 - height;
            rectTransform.offsetMin = new Vector2(x, y);

            x = rectTransform.offsetMin.x + width;
            y = rectTransform.offsetMin.y + height;
            rectTransform.offsetMax = new Vector2(x, y);
        }


    }

}
