using UnityEngine;
using System.Collections;

public class CardFlip : MonoBehaviour 
{
	public int fps;
	public float rotateDegPerSec;
	public bool isFaceUp = false;
	const float FLIP_LIMIT_DEG = 180f;
	float waitTime;

	public GameObject front;
	public GameObject back;
	public GameObject x;

	public float downSpeed = 100f;
	public float offScreenTimerCheck = 1.0f;

	private bool isAnimationProcessing = false;
	private bool isFlipDone = false;

	private float offScreenTimer;
	private float startPosX;
	private float startPosY;
	private float startPosZ;

	private bool check = false;

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

		waitTime = 1.0f / fps;
		x.SetActive(false);
		check = false;
	}

	void Update ()
	{
		if (transform.rotation.eulerAngles.y >= 90f && check == false)
		{
			ShowFace();
		}
		// move down
		if (isAnimationProcessing == false && isFlipDone == true)
		{
			transform.Translate (new Vector3 (0, -1 * downSpeed * Time.deltaTime, 0));
			offScreenTimer += Time.deltaTime;
			if (offScreenTimer >= offScreenTimerCheck)
			{
				ResetPos();
				isFlipDone = false;
			}
		}
		Debug.Log(transform.position.y);
	}

	void ShowFace()
	{
		back.SetActive (false);
		front.SetActive (true);
		x.SetActive (true);
		check = true;
	}

	void ResetPos()
	{
		transform.rotation = new Quaternion(0,0,0,0);
		back.SetActive(true);
		x.SetActive(false);
		front.SetActive(false);
		transform.position = new Vector3(startPosX, startPosY, startPosZ);
		Init();
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


			yield return new WaitForSeconds (waitTime);
		}
		isFaceUp = !isFaceUp;
		isAnimationProcessing = false;
		isFlipDone = true;
	}
}
