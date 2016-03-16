using UnityEngine;
using System.Collections;

public class CardFlip : MonoBehaviour 
{
	public int fps = 60;
	public float rotateDegPerSec = 180f;
	public bool isFaceUp = false;

	const float FLIP_LIMIT_DEG = 180f;

	float waitTime;
	bool isAnimationProcessing = false;
	//bool isMoving = false;
	public bool call = false;

	public GameObject front;
	public GameObject back;
	public GameObject x;

	void Start ()
	{
		waitTime = 1.0f / fps;
		x.SetActive(false);
	}

	void Update ()
	{
		if (transform.rotation.eulerAngles.y >= 90f)
		{
			back.SetActive(false);
			front.SetActive(true);
			x.SetActive(true);
		}
		//Debug.Log(transform.rotation.eulerAngles.y);
	}

	public void Hit ()
	{
		if (isAnimationProcessing)
		{
			return;
		}
		StartCoroutine(flip());
	}

	IEnumerator flip ()
	{
		isAnimationProcessing = true;
		bool done = false;
		while (!done)
		{
			float deg = rotateDegPerSec * Time.deltaTime;
			if (isFaceUp)
			{
				deg = -deg;
			}

			transform.Rotate (new Vector3 (0, deg, 0));

			if (FLIP_LIMIT_DEG < transform.eulerAngles.y)
			{
				transform.Rotate (new Vector3 (0, -deg, 0));
				done = true;
			}


			yield return new WaitForSeconds(waitTime);
		}
		isFaceUp = !isFaceUp;
		isAnimationProcessing = false;
	}

	/*IEnumerator move ()
	{
		Debug.Log ("called");
		isMoving = true;
		bool done = false;
		while (!done)
		{
			float move = 100f * Time.deltaTime;
			transform.Translate (new Vector3 (move * Time.deltaTime, 0, 0));

			if (transform.position.x >= -5 && transform.position.x <= 5)
			{
				transform.Translate (new Vector3 (move * Time.deltaTime, 0, 0));
				done = true;
			}

			yield return new WaitForSeconds(waitTime);
		}
		isMoving = false;
	}*/
}
