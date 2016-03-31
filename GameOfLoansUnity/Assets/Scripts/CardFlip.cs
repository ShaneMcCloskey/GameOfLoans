using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardFlip : MonoBehaviour 
{
	public int fps;
	public float rotateDegPerSec;
	public bool isFaceUp = false;
	const float FLIP_LIMIT_DEG = 180f;
	float waitTime;

	public GameObject front;
	public GameObject back;
	public GameObject typeText;
	public GameObject descText;

	public float downSpeed = 100f;
	public float offScreenTimerCheck = 1.0f;
	public float holdAfterFlipTimerCheck = 1.0f;

	public bool isAnimationProcessing = false;
	private bool isFlipDone = false;

	private float holdAfterFlipTimer;
	private float offScreenTimer;
	private float startPosX;
	private float startPosY;
	private float startPosZ;

	private bool check = false;

	public Sprite assetsSprite;
	public Sprite incomeSprite;
	public Sprite creditSprite;

	void Start ()
	{
		startPosX = transform.position.x;
		startPosY = transform.position.y;
		startPosZ = transform.position.z;
		Init();
	}

	void Init()
	{
		fps = 60;
		rotateDegPerSec = 180f;
		isFaceUp = false;
		isAnimationProcessing = false;
		isFlipDone = false;
		offScreenTimer = 0.0f;
		holdAfterFlipTimer = 0.0f;

		waitTime = 1.0f / fps;
		typeText.SetActive(false);
		descText.SetActive(false);
		check = false;
	}

	void Update ()
	{
		if (transform.rotation.eulerAngles.y >= 90f && check == false)
		{
			ShowFace ();
		}
		// move down
		if (isAnimationProcessing == false && isFlipDone == true)
		{

			holdAfterFlipTimer += Time.deltaTime;
			if (holdAfterFlipTimer >= holdAfterFlipTimerCheck)
			{
				transform.Translate (new Vector3 (0, -1 * downSpeed * Time.deltaTime, 0));
				offScreenTimer += Time.deltaTime;
				if (offScreenTimer >= offScreenTimerCheck)
				{
					ResetPos();
					isFlipDone = false;
				}	
			}
		}
	}

	void ShowFace()
	{
		back.SetActive (false);
		front.SetActive (true);
		typeText.SetActive (true);
		descText.SetActive(true);
		check = true;
	}

	void ResetPos()
	{
		transform.rotation = new Quaternion(0,0,0,0);
		back.SetActive(true);
		typeText.SetActive(false);
		descText.SetActive(false);
		front.SetActive(false);
		transform.position = new Vector3(startPosX, startPosY, startPosZ);
		Init();
	}

	public void Hit (OppKnocksCard card)
	{
		if (isAnimationProcessing)
		{
			return;
		}
		StartCoroutine (flip ());

		if (card.Category == 1)
		{
			front.GetComponent<Image> ().sprite = incomeSprite;
		}
		else if (card.Category == 2)
		{
			front.GetComponent<Image> ().sprite = assetsSprite;
		}
		else
		{
			front.GetComponent<Image> ().sprite = creditSprite;
		}
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


			yield return new WaitForSeconds (waitTime);
		}
		isFaceUp = !isFaceUp;
		isAnimationProcessing = false;
		isFlipDone = true;
	}
}
