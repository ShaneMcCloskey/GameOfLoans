using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIController : MonoBehaviour 
{
	// public vars ---------------------------
	// HUD text elements
	public Text HUDscoreText;
	public Text HUDincomeText;
	public Text HUDassetsText;
	public Text HUDcreditText;
	public Text HUDturnText;

	// Opp knocks card text elements
	public Text leftOppKnocksType;
	public Text leftOppKnocksDesc;
	public Text centerOppKnocksType;
	public Text centerOppKnocksDesc;
	public Text rightOppKnocksType;
	public Text rightOppKnocksDesc;
        public Text cardsLeftText;
        public int cardsLeftCount;

	// Property hunt text element
	public Text leftTitle;
	public Text leftAddressProp;
	public Text leftPriceProp;
	public Text leftDiffProp;
	public GameObject leftPicProp;

	public Text centerTitle;
	public Text centerAddressProp;
	public Text centerPriceProp;
	public Text centerDiffProp;
	public GameObject centerPicProp;

	public Text rightTitle;
	public Text rightAddressProp;
	public Text rightPriceProp;
	public Text rightDiffProp;
	public GameObject rightPicProp;

        // Loan in progress 
        public Text subGoalPanelTitle;
	public Text subGoalPanelDesc;
        public Text currentTitle;
	public Text currentAddress;
	public Text currentPrice;
	public Text currentDiff;
	public GameObject currentPic;
	public Slider progressBar;
	public Text sgText;

	// Pop up elements
	public Text popUpText;
	public Text popUpButtonText;
	public Text popUpRandEventText;
   	public Text QuizQuestionText;
	public Text AnswerAText;
	public Text AnswerBText;
   	public Text AnswerCText;
	public Text AnswerDText;
        public Text confirmPropText;

	// Change propety text elements
	public GameObject firstCardDisplay;
	public GameObject secondCardDisplay;
	public GameObject thirdCardDisplay;

	public Text firstAddress;
	public Text firstPrice;
	public Text firstDiff;
	public Text secondAddress;
	public Text secondPrice;
	public Text secondDiff;
	public Text thirdAddress;
	public Text thirdPrice;
	public Text thirdDiff;

	// private vars -----------------------------------------

	// Quiz vars -------------------------
	private bool quizFailed = false;
	private string correctAnswer = "";
	private int currentQuizNum = 0;
	private List<int> completedQuizes = new List<int>();

	public CardFlip cfLeft;
	public CardFlip cfCenter;
	public CardFlip cfRight;

	private float max = 0f;
	private Player playerLocal;
	private GameObject popUpLocal;
	private bool badLocal;
	private bool goodLocal;

	private bool needToUpdateBar = false;

	private Color textColor;
	private float r;
	private float g;
	private float b;
	private float newAlpha;

	private bool check = false;

	private bool decrease = false;

	/*private Color red;
	private Color green;
	private Color blue;*/

	private string[] posText;
	private int[] posValue;
	private int posIncValue;
	private string[] negText;
	private int[] negValue;
	private int negDecValue;

	// bottompanel private vars---------
	private string[] subTitles = {"Initial Contact","Application","Loan Set Up Complete", "Folder Received", "Conditionally Approved","Final Sign Off", "Closing Signing Scheduled", "Docs out to Settlement Agent", "Closed"};
	private string[] subDesc = {"Client e-signs the application and sends in supporting documents for review (pay stub, W2,etc.",
		"The Quality Assurance team makes sure the underwriter has everything they need to underwrite the loan.",
		"The underwriter reviews the documents for accuracy and compliance with guidelines. If anything else is needed, the underwriter adds a condition(tracking item) for it.",
		"The CCS calls to introduce him or herself to the client, review the info on the loan, and request the client conditions.",
		"All client conditions and vendor conditions are being viewed as they're received. The CCS is following up with the client every 3-5 days.",
		"When all documents are received and cleared and the loan is approved, the CCS calls the client to confirm the final terms and structure of the loan.",
		"If the client agrees to the terms, the loan goes to the final signoff underwriter for final approval.",
		" The Closing Team reviews the final numbers with the client and schedules the closing. Closing documents are printed and sent to the Closing Agent and client.",
		"Progress the loan to completion and answer the question correctly to close the loan."
	};

	public void AwakeUI ()
	{
		posText = new string[10];
		posValue = new int[10];
		posText[0] = "Documents are sent electronically.\n\n+4 Progress";
		posValue[0] = 4;
		posText[1] = "Clear communication with the CSS.\n\n+3 Progress";
		posValue[1] = 3;
		posText[2] = "Underwriter receives requested third party item in a timely manner..\n\n+2 Progress";
		posValue[2] = 2;
		posText[3] = "Application is accurate.\n\n+6 Progress";
		posValue[3] = 6;
		posText[4] = "Conditions are reviewed quickly.\n\n+5 Progress";
		posValue[4] = 5;
		negText = new string[10];
		negValue = new int[10];
		negText[0] = "Client W2 is missing.\n\n-4 Progress";
		negValue[0] = 4;
		negText[1] = "Client pay stubs are missing.\n\n-4 Progress";
		negValue[1] = 4;
		negText[2] = "Missed call from CCS.\n\n-1 Progress";
		negValue[2] = 1;
		negText[3] = "Client documents are inaccurate.\n\n-6 Progress";
		negValue[3] = 6;
		negText[4] = "Communication documents are lost in mail transportation. \n\n-5 Progress";
		negValue[4] = 5;
		negText[5] = "The underwriter is missing client information.\n\n-3 Progress";
		negValue[5] = 5;
		negText[6] = "Lack of client communication with the CSS.\n\n-3 Progress";
		negValue[6] = 3;
		negText[7] = "Additional client payoff documents requested.\n\n-2 Progress";
		negValue[7] = 2;
		negText[8] = "Additional client homeowners insurance documents requested.\n\n-2 Progress";
		negValue[8] = 2;
		negText[9] = "Additional client verification of employment documents requested.\n\n-2 Progress";
		negValue[9] = 2;
		/*red = new Color(255,0,16, 255);
		green = new Color(23,181,17,255);
		blue = new Color(17,52,181, 255);*/
		HUDscoreText.text = "0";
		HUDincomeText.text = "0";
		HUDassetsText.text = "0";
		HUDcreditText.text = "0";
		HUDturnText.text = "40";
	        cardsLeftCount = 10;
	        SetOppCardsLeft();
	        Debug.Log(posValue[0]);
	}

	void IncreaseBar ()
	{
		if (progressBar.value <= max && needToUpdateBar == true)
		{
			if (progressBar.value >= max - 1)
			{
				progressBar.value += .05f;
			}
			else if (progressBar.value >= max - 0.05f)
			{
				progressBar.value += .025f;
			}
			else
			{
				progressBar.value += .1f;
			}
		}
		else
		{	
			check = true;
			needToUpdateBar = false;
		}
	}

	void DecreaseBar ()
	{
		if (progressBar.value >= max)
		{
			if (progressBar.value <= max + 1)
			{
				progressBar.value -= .05f;
			}
			else if (progressBar.value <= max + 0.05f)
			{
				progressBar.value -= .025f;
			}
			else
			{
				progressBar.value -= .1f;
			}
		}
		else
		{
			check = true;
			decrease = false;
		}
	}

	void Update ()
	{
		if (needToUpdateBar)
		{
			if (playerLocal.CurrentProperty.CurrentProgress <= max)
			{
				IncreaseBar ();
			}
		}
		else
		{
			if (check)
			{
				CheckRandomEvent (goodLocal, badLocal, popUpLocal, playerLocal);
				check = false;
			}
		}

		if (decrease)
		{
			DecreaseBar();
		}

		CheckSubGoal (playerLocal, popUpLocal);


		ShowSubgoalText();
	}

	void ShowSubgoalText ()
	{
		if (sgText.text != "")
		{
			textColor = sgText.color;

			newAlpha = textColor.a - .01f;
			r = sgText.color.r;
			g = sgText.color.g;
			b = sgText.color.b;

			textColor = new Color (r, g, b, newAlpha);

			sgText.color = textColor;
		}
		if (sgText.color.a <= 0f)
		{
			sgText.text = "";
			sgText.color = new Color (r, g, b, 1.0f);
		}
	}

	public void UpdateTurnsLeft (Player player)
	{
		HUDturnText.text = player.NumTurnsLeft.ToString();
	}

	public void UpdateOppKnocksCardTextAndPlayerStatsUI (OppKnocksCard card, Player player, string leftRightOrCenter)
	{
        	cardsLeftCount = cardsLeftCount - 1;
		if (leftRightOrCenter == "left")
		{
			cfLeft.Hit(card);
			if (card.Category == 1) 
			{
				leftOppKnocksType.text = "Income Card";
				leftOppKnocksDesc.text = card.Desc;
				HUDincomeText.text = player.Income.ToString();
			} 
			else if (card.Category == 2) 
			{
				leftOppKnocksType.text = "Asset Card";
				leftOppKnocksDesc.text = card.Desc;
				HUDassetsText.text = player.Assets.ToString();
			} 
			else 
			{
				leftOppKnocksType.text = "Credit Card";
				leftOppKnocksDesc.text = card.Desc;
				HUDcreditText.text = player.Credit.ToString();
			}
		}
		else if (leftRightOrCenter == "center")
		{
			cfCenter.Hit(card);
			if (card.Category == 1) 
			{
				centerOppKnocksType.text = "Income Card";
				centerOppKnocksDesc.text = card.Desc;
				HUDincomeText.text = player.Income.ToString();
			} 
			else if (card.Category == 2) 
			{
				centerOppKnocksType.text = "Asset Card";
				centerOppKnocksDesc.text = card.Desc;
				HUDassetsText.text = player.Assets.ToString();
			} 
			else 
			{
				centerOppKnocksType.text = "Credit Card";
				centerOppKnocksDesc.text = card.Desc;
				HUDcreditText.text = player.Credit.ToString();
			}
		}
		else if (leftRightOrCenter == "right")
		{
			cfRight.Hit(card);
			if (card.Category == 1) 
			{
				rightOppKnocksType.text = "Income Card";
				rightOppKnocksDesc.text = card.Desc;
				HUDincomeText.text = player.Income.ToString();
			} 
			else if (card.Category == 2) 
			{
				rightOppKnocksType.text = "Asset Card";
				rightOppKnocksDesc.text = card.Desc;
				HUDassetsText.text = player.Assets.ToString();
			} 
			else 
			{
				rightOppKnocksType.text = "Credit Card";
				rightOppKnocksDesc.text = card.Desc;
				HUDcreditText.text = player.Credit.ToString();
			}
		}
        	SetOppCardsLeft();
	}

	public void EnterPropertyHuntScreeUI(PropertyCard cardLeft, PropertyCard cardCenter, PropertyCard cardRight)
	{
		leftTitle.text = cardLeft.Title;
		leftAddressProp.text = cardLeft.Address;
		leftPriceProp.text = cardLeft.Price.ToString();
		leftDiffProp.text = cardLeft.Difficulty.ToString();
		leftPicProp.GetComponent<Image>().sprite = cardLeft.Pic;

		centerTitle.text = cardCenter.Title;
		centerAddressProp.text = cardCenter.Address;
		centerPriceProp.text = cardCenter.Price.ToString();
		centerDiffProp.text = cardCenter.Difficulty.ToString();
		centerPicProp.GetComponent<Image>().sprite = cardCenter.Pic;

		rightTitle.text = cardRight.Title;
		rightAddressProp.text = cardRight.Address;
		rightPriceProp.text = cardRight.Price.ToString();
		rightDiffProp.text = cardRight.Difficulty.ToString();
		rightPicProp.GetComponent<Image>().sprite = cardRight.Pic;
	}

	// Loan in Progess functions -----------------------------------------------
	public void EnterLoanInProgressScreenUI (Player player)
	{
		currentTitle.text = player.CurrentProperty.Title;
		currentAddress.text = player.CurrentProperty.Address;
		currentPrice.text = player.CurrentProperty.Price.ToString();
		currentDiff.text = player.CurrentProperty.Difficulty.ToString();
		currentPic.GetComponent<Image>().sprite = player.CurrentProperty.Pic;

	        progressBar.maxValue = player.CurrentProperty.NumToClose;
	        progressBar.value = player.CurrentProperty.CurrentProgress;

	        max = player.CurrentProperty.CurrentProgress;

		if (player.CurrentProperty.Difficulty == "Easy")
		{
			currentDiff.color = Color.green;
		}
		else if (player.CurrentProperty.Difficulty == "Medium")
		{
			currentDiff.color = Color.blue;
		}
		else
		{
			currentDiff.color = Color.red;
		}
	}

    	public void RollDiceUI (Player player, GameObject popUpPanel, bool quiz, bool randEventGood, bool randEventBad)
	{
		// need to have the panel in here
		max = player.CurrentProperty.CurrentProgress;
		needToUpdateBar = true;

		HUDscoreText.text = player.Score.ToString ();
		HUDincomeText.text =  player.Income.ToString ();
		HUDassetsText.text = player.Assets.ToString ();
		HUDcreditText.text = player.Credit.ToString ();
		HUDturnText.text = player.NumTurnsLeft.ToString ();

		playerLocal = player;
		popUpLocal = popUpPanel;
		goodLocal = randEventGood;
		badLocal = randEventBad;

	        if (quiz)
	        {
	            ShowQuiz(popUpPanel);
	        }
	}	


        void CheckSubGoal (Player player, GameObject popUpPanel)
	{
		if ((progressBar.value >= progressBar.maxValue / 9) && player.CurrentProperty.Subgoal1Complete == false)
		{		
			sgText.text = "Subgoal 1 Achieved!";
			player.CurrentProperty.Subgoal1Complete = true;
			subGoalPanelTitle.text = "Application"; 
		}
		else if ((progressBar.value >= (progressBar.maxValue / 9) * 2) && player.CurrentProperty.Subgoal2Complete == false)
		{
			sgText.text = "Subgoal 2 Achieved!";
			player.CurrentProperty.Subgoal2Complete = true;
			subGoalPanelTitle.text = "Loan Set Up";

		}
		else if ((progressBar.value >= (progressBar.maxValue / 9) * 3) && player.CurrentProperty.Subgoal3Complete == false)
		{
			sgText.text = "Subgoal 3 Achieved!";
			player.CurrentProperty.Subgoal3Complete = true;
			subGoalPanelTitle.text = "Folder Received";
		}
		else if ((progressBar.value >= (progressBar.maxValue / 9) * 4) && player.CurrentProperty.Subgoal4Complete == false)
		{
			sgText.text = "Subgoal 4 Achieved!";
			player.CurrentProperty.Subgoal4Complete = true;
		}
		else if ((progressBar.value >= (progressBar.maxValue / 9) * 5) && player.CurrentProperty.Subgoal5Complete == false)
		{
			sgText.text = "Subgoal 5 Achieved!";
			player.CurrentProperty.Subgoal5Complete = true;
		}
		else if ((progressBar.value >= (progressBar.maxValue / 9) * 6) && player.CurrentProperty.Subgoal6Complete == false)
		{
			sgText.text = "Subgoal 6 Achieved!";
			player.CurrentProperty.Subgoal6Complete = true;
		}
		else if ((progressBar.value >= (progressBar.maxValue / 9) * 7) && player.CurrentProperty.Subgoal7Complete == false)
		{
			sgText.text = "Subgoal 7 Achieved!";
			player.CurrentProperty.Subgoal7Complete = true;
		}
		else if ((progressBar.value >= (progressBar.maxValue / 9) * 8) && player.CurrentProperty.Subgoal8Complete == false)
		{
			sgText.text = "Subgoal 8 Achieved!";
			player.CurrentProperty.Subgoal8Complete = true;
		}
		ChangeSubgoalPanel (player);
	}

	void CheckRandomEvent (bool randEventGood, bool randEventBad, GameObject popUpPanel, Player player)
	{
		int randNum;
		if (randEventGood)
		{
			randNum = Random.Range(0,5);
			posIncValue = posValue[randNum];
			ShowPopUp(posText[randNum], popUpPanel);

		}
		if (randEventBad)
		{
			randNum = Random.Range(0,10);
			negDecValue = negValue[randNum];
			ShowPopUp(negText[randNum], popUpPanel);
		}

	}

	void ProcessNegativeEvent (Player player)
	{
		player.CurrentProperty.CurrentProgress -= negDecValue;
		max = player.CurrentProperty.CurrentProgress;
		decrease = true;
		badLocal = false;
		if ((player.CurrentProperty.CurrentProgress <= progressBar.maxValue / 9) && player.CurrentProperty.Subgoal1Complete == true)
		{
			player.CurrentProperty.Subgoal1Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 2) && player.CurrentProperty.Subgoal2Complete == true)
		{
			player.CurrentProperty.Subgoal2Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 3) && player.CurrentProperty.Subgoal3Complete == true)
		{
			player.CurrentProperty.Subgoal3Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 4) && player.CurrentProperty.Subgoal4Complete == true)
		{
			player.CurrentProperty.Subgoal4Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 5) && player.CurrentProperty.Subgoal5Complete == true)
		{
			player.CurrentProperty.Subgoal5Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 6) && player.CurrentProperty.Subgoal6Complete == true)
		{
			player.CurrentProperty.Subgoal6Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 7) && player.CurrentProperty.Subgoal7Complete == true)
		{
			player.CurrentProperty.Subgoal7Complete = false;
		}
		else if ((player.CurrentProperty.CurrentProgress <= (progressBar.maxValue / 9) * 8) && player.CurrentProperty.Subgoal8Complete == true)
		{
			player.CurrentProperty.Subgoal8Complete = false;
		}
	}

	void ProcessPositiveEvent(Player player)
	{
		player.CurrentProperty.CurrentProgress += posIncValue;
		max = player.CurrentProperty.CurrentProgress;
		needToUpdateBar = true;
		goodLocal = false;
	}

	// add param to check if need to be sent to diff panel
	public void ShowPopUp (string Text, GameObject PopUpPanel)
	{
		PopUpPanel.SetActive (true);
		popUpText.text = Text;
		popUpButtonText.text = "Ok";
	}

    	// still need to pop up subgoal hit after random event ok click if hit subgoal
	public void ProcessOkButtonUI (GameObject popUpPanel, GameObject popUpPanelNeedProp, GameObject propHuntPanel, GameObject quizPanel, Player player)
	{
	        if (quizFailed)
	        {
	            popUpPanel.SetActive(false);
	            ShowQuiz(quizPanel);
	        }

		else if (player.PlayerCardsProperty.Count == 0)  // if player completes loan and has none in queue
		{
			popUpPanel.SetActive (false);
			popUpPanelNeedProp.SetActive (true);
		}

		popUpPanel.SetActive (false);

		if (badLocal)
		{
			ProcessNegativeEvent (player);
		}
		else if (goodLocal)
		{
			ProcessPositiveEvent(player);
		}
	}

	//Set quiz question and answers
    void ShowQuiz(GameObject PopUpPanel)
    {
        PopUpPanel.SetActive(true);

        // If player has already completed all available quizes, reset them
        if (completedQuizes.Count == 22)
        {
            completedQuizes.Clear();
        }

        //set random quiz number 1-22
        currentQuizNum = Random.Range(1, 23);

        // Make sure player has not already completed current quiz
        if (completedQuizes.Contains(currentQuizNum))
        {
            while (completedQuizes.Contains(currentQuizNum))
            {
                currentQuizNum = Random.Range(1, 23);
            }
        }

        switch (currentQuizNum)
        {
            case 1:
                QuizQuestionText.text = "What is the step when the client e-signs the application and sends in supporting documents for review(pay stubs, W2, etc.)?";
                AnswerAText.text = "A: Initial Contact";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerAText.text;
                break;
              
            case 2:
                QuizQuestionText.text = "What is the step when the Quality Assurance team makes sure the underwriter has everything they need to underwrite the loan?";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Application"; 
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerBText.text;
                break;
            
            case 3:
                QuizQuestionText.text = "This step is when the underwriter reviews the documents for accuracy and compliance with guidelines. If anything else is needed, the underwriter adds a condition (tracking item) for it.";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Loan Set Up Complete";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerCText.text;
                break;

            case 4:
                QuizQuestionText.text = "At this step the CCS calls to introduce him or herself to the client, review the info on the loan, and request the client conditions.";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Folder Received";

                correctAnswer = AnswerDText.text;
                break;

            case 5:
                QuizQuestionText.text = "At this step all client conditions and vendor conditions are being reviewed as they’re received. The CCS is following up with the client every 3-5 days. ";
                AnswerAText.text = "A: Conditionally Approved";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerAText.text;
                break;

            case 6:
                QuizQuestionText.text = "When all documents are received and cleared and the loan is approved, the CCS calls the client to confirm the final terms and structure of the loan. This is called the _______.";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Final Signoff";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerBText.text;
                break;

            case 7:
                QuizQuestionText.text = "When ______________ the client agrees to the terms, and the loan goes to the final signoff underwriter for final approval.";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Closing Signing has been scheduled";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerCText.text;
                break;
            
            case 8:
                QuizQuestionText.text = "The Closing Team reviews the final numbers with the client and schedules the closing. Closing documents are printed and sent to the Closing Agent and client. This stage is when…";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Docs out to Settlement Agent";

                correctAnswer = AnswerDText.text;
                break;
            
            case 9:
                QuizQuestionText.text = "In the Conditionally Approved stage, how many days do the CCS follow up with the client for?";
                AnswerAText.text = "A: 3-5 days";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerAText.text;
                break;

            case 10:
                QuizQuestionText.text = "T/F If the client does not agree with the terms, the loan still goes to the final signoff underwriter for final approval?";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: F";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerBText.text;
                break;

            case 11:
                QuizQuestionText.text = "T/F A client only needs an old W2 to be approved for a loan?";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: F";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerCText.text;
                break;

            case 12:
                QuizQuestionText.text = "Which team makes sure the underwriter has everything they need to underwrite the loan?";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: The Quality Assurance team";

                correctAnswer = AnswerDText.text;
                break;

            case 13:
                QuizQuestionText.text = "The ____ calls to introduce him or herself to the client in the Folder Received step.";
                AnswerAText.text = "A: CCS";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerAText.text;
                break;

            case 14:
                QuizQuestionText.text = "The initial contact stage is when...";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: The client e-signs the application and sends in supporting documents for review(pay stubs, W2, etc.)";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerBText.text;
                break;

            case 15:
                QuizQuestionText.text = "The application stage is when…";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: The Quality Assurance team makes sure the underwriter has everything they need to underwrite the loan";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerCText.text;
                break;
            
            case 16:
                QuizQuestionText.text = "The Loan Set Up Complete stage is when…";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: The underwriter reviews the documents for accuracy and compliance with guidelines. If anything else is needed, the underwriter adds a condition (tracking item) for it.";

                correctAnswer = AnswerDText.text;
                break;

            case 17:
                QuizQuestionText.text = "The Folder Received stage is when…";
                AnswerAText.text = "A: The CCS calls to introduce him or herself to the client, review the info on the loan, and request the client conditions.";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerAText.text;
                break;
            
            case 18:
                QuizQuestionText.text = "The Conditionally Approved stage is when…";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: All client conditions and vendor conditions are being reviewed as they’re received. The CCS is following up with the client every 3-5 days.";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerBText.text;
                break;
            
            case 19:
                QuizQuestionText.text = "The Final Signoff stage is when…";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: All documents are received and cleared and the loan is approved, the CCS calls the client to confirm the final terms and structure of the loan.";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerCText.text;
                break;
            
            case 20:
                QuizQuestionText.text = "The Closing Signing has been scheduled when...";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: The client agrees to the terms, and the loan goes to the final signoff underwriter for final approval";

                correctAnswer = AnswerDText.text;
                break;
            
            case 21:
                QuizQuestionText.text = "The Documents go out to the settlement agent when….";
                AnswerAText.text = "A: The Closing Team reviews the final numbers with the client and schedules the closing. Closing documents are printed and sent to the Closing Agent and client.";
                AnswerBText.text = "B: Blah";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerAText.text;
                break;

            case 22:
                QuizQuestionText.text = "Who is the person that reviews the documents for accuracy and compliance with guidelines?";
                AnswerAText.text = "A: Blah";
                AnswerBText.text = "B: The Underwriter";
                AnswerCText.text = "C: Blah";
                AnswerDText.text = "D: Blah";

                correctAnswer = AnswerBText.text;
                break;
        }
    }

    // Display and process quiz pass or fail
    public void ProcessAnswerUI(GameObject quizPanel, GameObject popUpPanel, Player player, string letter)
    {
        string chosenAnswer ="";

        switch (letter)
        {
            case "A":
                chosenAnswer = AnswerAText.text;
                break;
            case "B":
                chosenAnswer = AnswerBText.text;
                break;
            case "C":
                chosenAnswer = AnswerCText.text;
                break;
            case "D":
                chosenAnswer = AnswerDText.text;
                break;
        }
        
        if (chosenAnswer == correctAnswer)
        {
            PassQuiz(quizPanel, popUpPanel, player);
        }

        else
        {
            FailQuiz(quizPanel, popUpPanel, player);
        }
    }

    public void PassQuiz(GameObject quizPanel, GameObject popUpPanel, Player player)
    {
        completedQuizes.Add(currentQuizNum);
        quizFailed = false;
        quizPanel.SetActive(false);
        ShowPopUp("Correct!\n\nLoan Closed!", popUpPanel);

        player.Score += 1000;
        RollDiceUI(player, popUpPanel, false, false, false);
        player.PlayerCardsProperty.Remove(player.CurrentProperty);
        player.CurrentProperty = null;
        if (player.PlayerCardsProperty.Count >= 1)
        {
            player.CurrentProperty = player.PlayerCardsProperty[0];

            // Update UI to display current property card
            EnterLoanInProgressScreenUI(player);
        }
    }

    public void FailQuiz(GameObject quizPanel, GameObject popUpPanel, Player player)
    {
        player.NumTurnsLeft--;
        RollDiceUI(player, popUpPanel, false, false, false);

        quizFailed = true;
        quizPanel.SetActive(false);
        ShowPopUp("Incorrect!\n\nThe correct answer is \"" + correctAnswer + "\"", popUpPanel);
    }

    // Display the cards the player current has, up to 3 prop cards
	public void EnterChangePropertyScreenUI (Player player)
	{
	        firstCardDisplay.SetActive(false);
	        secondCardDisplay.SetActive(false);
	        thirdCardDisplay.SetActive(false);

	        // First Prop card

	        if (player.PlayerCardsProperty.Count >= 1)
	        {
	            firstCardDisplay.SetActive(true);

	            firstAddress.text = player.PlayerCardsProperty[0].Address;
	            firstPrice.text = player.PlayerCardsProperty[0].Price.ToString();
	            firstDiff.text = player.PlayerCardsProperty[0].Difficulty.ToString();
	        }

	        // Second Prop card

	        if (player.PlayerCardsProperty.Count >= 2)
	        {
	            secondCardDisplay.SetActive(true);

	            secondAddress.text = player.PlayerCardsProperty[1].Address;
	            secondPrice.text = player.PlayerCardsProperty[1].Price.ToString();
	            secondDiff.text = player.PlayerCardsProperty[1].Difficulty.ToString();
	        }
	        
	        // Third Prop card

	        if (player.PlayerCardsProperty.Count >= 3)
	        {
	            thirdCardDisplay.SetActive(true);

	            thirdAddress.text = player.PlayerCardsProperty[2].Address;
	            thirdPrice.text = player.PlayerCardsProperty[2].Price.ToString();
	            thirdDiff.text = player.PlayerCardsProperty[2].Difficulty.ToString();
	        }
	}
	public void ChangeSubgoalPanel(Player player)
	{
		int index = 0;
		if (player.CurrentProperty.Subgoal1Complete) 
		{
			index++;
		}
		if (player.CurrentProperty.Subgoal2Complete)
		{
			index++;
		}
		if (player.CurrentProperty.Subgoal3Complete) 
		{
			index++;
		}
		if (player.CurrentProperty.Subgoal4Complete) 
		{
			index++;
		}
		if (player.CurrentProperty.Subgoal5Complete)
		{
			index++;
		}
		if (player.CurrentProperty.Subgoal6Complete) 
		{
			index++;
		}
		if (player.CurrentProperty.Subgoal7Complete) 
		{
			index++;
		}
		if (player.CurrentProperty.Subgoal8Complete) 
		{
			index++;
		}
		subGoalPanelTitle.text = subTitles[index];
		subGoalPanelDesc.text = subDesc [index];
	}

    public void SetOppCardsLeft()
    {
        if (cardsLeftCount == 10)
        {
            cardsLeftText.text = "Choose " + cardsLeftCount.ToString() + " cards to increase your stats";
        }
        else if (cardsLeftCount < 10 && cardsLeftCount > 1)
        {
            cardsLeftText.text = "Choose " + cardsLeftCount.ToString() + " more cards to increase your stats";
        }
        else if (cardsLeftCount == 1)
        {
            cardsLeftText.text = "Choose " + cardsLeftCount.ToString() + " more card to increase your stats";
        }
        else
        {
            cardsLeftText.text = "Draw a card to increase your stats";
        }
    }
    public void SetConfirmText(PropertyCard cardChoice)
    {
        confirmPropText.text = "Are you sure you want to select the " + cardChoice.Title + " property?";
    }
}
