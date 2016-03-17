using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour 
{
	
	public float scrollSpeed = 0.5F;
	public Renderer rend;
	public bool scroll = true;
	public Texture x;

	void Start() 
	{
		rend = GetComponent<Renderer>();
    	}

    	void Update ()
	{	
		if (scroll)
		{
			float offset = Time.time * scrollSpeed;
        		rend.material.mainTextureOffset = new Vector2(offset, 0);
		}
    	}

    	public void Change ()
	{
		rend.material.mainTexture = x;
	}
}
