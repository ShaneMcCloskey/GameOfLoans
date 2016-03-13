using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour 
{
	// public vars ----------------------
	// HUD text elements
	public Text HUDscoreText;
	public Text HUDincomeText;
	public Text HUDassetsText;
	public Text HUDcreditText;
	public Text HUDturnText;
	// Opp knocks card text elements
	public Text textOppKnocksType;
	public Text textOppKnocksDesc;
	// Property hunt text element
	public Text leftAddress;
	public Text leftPrice;
	public Text leftSqFoot;
	public Text leftDiff;
	public Text centerAddress;
	public Text centerPrice;
	public Text centerSqFoot;
	public Text centerDiff;
	public Text rightAddress;
	public Text rightPrice;
	public Text rightSqFoot;
	public Text rightDiff;
        // Loan in progress 
	public Text currentAddress;
	public Text currentPrice;
	public Text currentSqFoot;
	public Text currentDiff;
	public Slider progressBar;
	// Pop up elements
	public Text popUpText;
	public Text popUpButtonText;
	public Text popUpRandEventText;
    public Text QuizQuestionText;
	// Change propety text elements

	// private vars ----------------------
	private bool randEventGoodOccured = false;
	private bool randEventBadOccured = false;
	private bool subgoalPopUpActive = false;

	public void AwakeUI()
	{
		HUDscoreText.text = "0";
		HUDincomeText.text = "0";
		HUDassetsText.text = "0";
		HUDcreditText.text = "0";
		HUDturnText.text = "40";
	}

	public void EnterOppKnocksScreenUI()
	{
		textOppKnocksDesc.text = "Click to draw card";
		textOppKnocksType.text = "";
	}

	public void UpdateTurnsLeft (Player player)
	{
		HUDturnText.text = player.NumTurnsLeft.ToString();
	}

	public void UpdateOppKnocksCardTextAndPlayerStatsUI(OppKnocksCard card, Player player)
	{
		textOppKnocksDesc.text = card.Desc;

		if (card.Category == 1) 
		{
			textOppKnocksType.text = "Income Card";
			HUDincomeText.text = player.Income.ToString();
		} 
		else if (card.Category == 2) 
		{
			textOppKnocksType.text = "Asset Card";
			HUDassetsText.text = player.Assets.ToString();
		} 
		else 
		{
			textOppKnocksType.text = "Credit Card";
			HUDcreditText.text = player.Credit.ToString();
		}
	}

	public void EnterPropertyHuntScreeUI(PropertyCard cardLeft, PropertyCard cardCenter, PropertyCard cardRight)
	{
		leftAddress.text = cardLeft.Address;
		leftPrice.text = cardLeft.Price.ToString();
		leftSqFoot.text = cardLeft.SqFoot.ToString();
		leftDiff.text = cardLeft.Difficulty.ToString();

		centerAddress.text = cardCenter.Address;
		centerPrice.text = cardCenter.Price.ToString();
		centerSqFoot.text = cardCenter.SqFoot.ToString();
		centerDiff.text = cardCenter.Difficulty.ToString();

		rightAddress.text = cardRight.Address;
		rightPrice.text = cardRight.Price.ToString();
		rightSqFoot.text = cardRight.SqFoot.ToString();
		rightDiff.text = cardRight.Difficulty.ToString();
	}

	// Loan in Progess functions -----------------------------------------------
	public void EnterLoanInProgressScreenUI(Player player)
	{
		currentAddress.text = player.CurrentProperty.Address;
		currentPrice.text = player.CurrentProperty.Price.ToString();
		currentSqFoot.text = player.CurrentProperty.SqFoot.ToString();
		currentDiff.text = player.CurrentProperty.Difficulty.ToString();

        	progressBar.maxValue = player.CurrentProperty.NumToClose;
        	progressBar.value = player.CurrentProperty.CurrentProgress;
	}

        public void RollDiceUI (Player player, GameObject popUpPanel, bool quiz, bool loanComplete, bool randEventGood, bool randEventBad)
	{
		// need to have the panel in here
		progressBar.value = player.CurrentProperty.CurrentProgress;
		HUDscoreText.text = player.Score.ToString ();
		HUDincomeText.text =  player.Income.ToString ();
		HUDassetsText.text = player.Assets.ToString ();
		HUDcreditText.text = player.Credit.ToString ();
		HUDturnText.text = player.NumTurnsLeft.ToString ();

		CheckSubGoal(player, popUpPanel);
		CheckRandomEvent(randEventGood, randEventBad, popUpPanel, player);

        if (quiz)
        {
            ShowQuiz(popUpPanel);
            //loanComplete = true;
        }

		if (loanComplete)
		{
            //ShowPopUp("Test Quiz", popUpPanel);
            ShowPopUp("Loan Complete!", popUpPanel);
            //ShowQuiz(popUpPanel);
		}
    }


        void CheckSubGoal (Player player, GameObject popUpPanel)
	{
		if ((player.CurrentProperty.CurrentProgress >= progressBar.maxValue / 9) && player.CurrentProperty.Subgoal1Complete == false)
		{
			//Debug.Log("1");			
			ShowPopUp("Subgoal 1", popUpPanel);
			player.CurrentProperty.Subgoal1Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 2) && player.CurrentProperty.Subgoal2Complete == false)
		{
			ShowPopUp("Subgoal 2", popUpPanel);
			player.CurrentProperty.Subgoal2Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 3) && player.CurrentProperty.Subgoal3Complete == false)
		{
			ShowPopUp("Subgoal 3", popUpPanel);
			player.CurrentProperty.Subgoal3Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 4) && player.CurrentProperty.Subgoal4Complete == false)
		{
			ShowPopUp("Subgoal 4", popUpPanel);
			player.CurrentProperty.Subgoal4Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 5) && player.CurrentProperty.Subgoal5Complete == false)
		{
			ShowPopUp("Subgoal 5", popUpPanel);
			player.CurrentProperty.Subgoal5Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 6) && player.CurrentProperty.Subgoal6Complete == false)
		{
			ShowPopUp("Subgoal 6", popUpPanel);
			player.CurrentProperty.Subgoal6Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 7) && player.CurrentProperty.Subgoal7Complete == false)
		{
			ShowPopUp("Subgoal 7", popUpPanel);
			player.CurrentProperty.Subgoal7Complete = true;
			subgoalPopUpActive = true;
		}
		else if ((player.CurrentProperty.CurrentProgress >= (progressBar.maxValue / 9) * 8) && player.CurrentProperty.Subgoal8Complete == false)
		{
			ShowPopUp("Subgoal 8", popUpPanel);
			player.CurrentProperty.Subgoal8Complete = true;
			subgoalPopUpActive = true;
		}
	}

	void CheckRandomEvent (bool randEventGood, bool randEventBad, GameObject popUpPanel, Player player)
	{
		randEventGoodOccured = randEventGood;
		randEventBadOccured = randEventBad;
		if (subgoalPopUpActive == false)
		{
			if (randEventGood)
			{
				ShowPopUp("Positive Random Event", popUpPanel);

			}
			if (randEventBad)
			{
				ShowPopUp("Negative Random Event", popUpPanel);
			}
		}
	}

	void ProcessNegativeEvent (Player player)
	{
		player.CurrentProperty.CurrentProgress -= 3;
		progressBar.value = player.CurrentProperty.CurrentProgress;
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
		player.CurrentProperty.CurrentProgress += 3;
		progressBar.value = player.CurrentProperty.CurrentProgress;
	}

	// add param to check if need to be sent to diff panel
	void ShowPopUp (string Text, GameObject PopUpPanel)
	{
		PopUpPanel.SetActive (true);
		popUpText.text = Text;
		popUpButtonText.text = "Ok";
	}

    //Set quiz question and answers
    void ShowQuiz(GameObject PopUpPanel)
    {
        PopUpPanel.SetActive(true);
        //set random number 1-22
        int num = Random.Range(1, 22);
        if (num == 1)
        {
            QuizQuestionText.text = "What is the step when the client e-signs the application and sends in supporting documents for review(pay stubs, W2, etc.)?";
            popUpButtonText.text = "Initial Contact";
        }
        if (num == 2)
        {
            QuizQuestionText.text = "What is the step when the Quality Assurance team makes sure the underwriter has everything they need to underwrite the loan?";
            popUpButtonText.text = "Application";
        }
        if (num == 3)
        {
            QuizQuestionText.text = "This step is when the underwriter reviews the documents for accuracy and compliance with guidelines. If anything else is needed, the underwriter adds a condition (tracking item) for it.";
            popUpButtonText.text = "Loan Set Up Complete";
        }
        if (num == 4)
        {
            QuizQuestionText.text = "At this step the CCS calls to introduce him or herself to the client, review the info on the loan, and request the client conditions.";
            popUpButtonText.text = "Folder Received";
        }
        if (num == 5)
        {
            QuizQuestionText.text = "At this step all client conditions and vendor conditions are being reviewed as they’re received. The CCS is following up with the client every 3-5 days. ";
            popUpButtonText.text = "Conditionally Approved";
        }
        if (num == 6)
        {
            QuizQuestionText.text = "When all documents are received and cleared and the loan is approved, the CCS calls the client to confirm the final terms and structure of the loan. This is called the _______.";
            popUpButtonText.text = "Final Signoff";
        }
        if (num == 7)
        {
            QuizQuestionText.text = "When ______________ the client agrees to the terms, and the loan goes to the final signoff underwriter for final approval.";
            popUpButtonText.text = "Closing Signing has been scheduled";
        }
        if (num == 8)
        {
            QuizQuestionText.text = "The Closing Team reviews the final numbers with the client and schedules the closing. Closing documents are printed and sent to the Closing Agent and client. This stage is when…";
            popUpButtonText.text = "Docs out to Settlement Agent";
        }
        if (num == 9)
        {
            QuizQuestionText.text = "In the Conditionally Approved stage, how many days do the CCS follow up with the client for?";
            popUpButtonText.text = "3-5 days";
        }
        if (num == 10)
        {
            QuizQuestionText.text = "T/F If the client does not agree with the terms, the loan still goes to the final signoff underwriter for final approval?";
            popUpButtonText.text = "F";
        }
        if (num == 11)
        {
            QuizQuestionText.text = "T/F A client only needs an old W2 to be approved for a loan?";
            popUpButtonText.text = "F";
        }
        if (num == 12)
        {
            QuizQuestionText.text = "Which team makes sure the underwriter has everything they need to underwrite the loan?";
            popUpButtonText.text = "The Quality Assurance team";
        }
        if (num == 13)
        {
            QuizQuestionText.text = "The ____ calls to introduce him or herself to the client in the Folder Received step.";
            popUpButtonText.text = "CCS";
        }
        if (num == 14)
        {
            QuizQuestionText.text = "The initial contact stage is when...";
            popUpButtonText.text = "The client e-signs the application and sends in supporting documents for review(pay stubs, W2, etc.)";
        }
        if (num == 15)
        {
            QuizQuestionText.text = "The application stage is when…";
            popUpButtonText.text = "The Quality Assurance team makes sure the underwriter has everything they need to underwrite the loan";
        }
        if (num == 16)
        {
            QuizQuestionText.text = "The Loan Set Up Complete stage is when…";
            popUpButtonText.text = "The underwriter reviews the documents for accuracy and compliance with guidelines. If anything else is needed, the underwriter adds a condition (tracking item) for it.";
        }
        if (num == 17)
        {
            QuizQuestionText.text = "The Folder Received stage is when…";
            popUpButtonText.text = "The CCS calls to introduce him or herself to the client, review the info on the loan, and request the client conditions.";
        }
        if (num == 18)
        {
            QuizQuestionText.text = "The Conditionally Approved stage is when…";
            popUpButtonText.text = "All client conditions and vendor conditions are being reviewed as they’re received. The CCS is following up with the client every 3-5 days.";
        }
        if (num == 19)
        {
            QuizQuestionText.text = "The Final Signoff stage is when…";
            popUpButtonText.text = "All documents are received and cleared and the loan is approved, the CCS calls the client to confirm the final terms and structure of the loan.";
        }
        if (num == 20)
        {
            QuizQuestionText.text = "The Closing Signing has been scheduled when...";
            popUpButtonText.text = "the client agrees to the terms, and the loan goes to the final signoff underwriter for final approval";
        }
        if (num == 21)
        {
            QuizQuestionText.text = "The Documents go out to the settlement agent when….";
            popUpButtonText.text = "The Closing Team reviews the final numbers with the client and schedules the closing. Closing documents are printed and sent to the Closing Agent and client.";
        }
        if (num == 22)
        {
            QuizQuestionText.text = "Who is the person that reviews the documents for accuracy and compliance with guidelines?";
            popUpButtonText.text = "The Underwriter";
        }
       
        //popUpText.text = Text;
        //popUpButtonText.text = "Ok";

    }

        // still need to pop up subgoal hit after random event ok click if hit subgoal
	public void ProcessOkButtonUI (GameObject popUpPanel, GameObject popUpPanelNeedProp, GameObject propHuntPanel, Player player)
	{
		if (player.PlayerCardsProperty.Count == 0)  // if player completes loan and has none in queue
		{
			popUpPanel.SetActive (false);
			popUpPanelNeedProp.SetActive (true);
		}

		popUpPanel.SetActive (false);

		if (subgoalPopUpActive)
		{
			subgoalPopUpActive = false;
			CheckRandomEvent (randEventGoodOccured, randEventBadOccured, popUpPanel, player);
		}
		else if (randEventBadOccured)
		{
			ProcessNegativeEvent (player);
		}
		else if (randEventGoodOccured)
		{
			ProcessPositiveEvent(player);
			CheckSubGoal(player,popUpPanel);
		}
	}

    public void ProcessAnswerButtonUI(GameObject popUpPanel, GameObject popUpPanelNeedProp, GameObject propHuntPanel, Player player)
    {
        popUpPanel.SetActive(false);
    }


	public void EnterChangePropertyScreenUI (PropertyCard card1, PropertyCard card2, PropertyCard card3)
	{
		// call func from ui cont
	}
}