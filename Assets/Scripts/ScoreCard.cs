using System;
using UnityEngine;
using System.Collections;

public class ScoreCard : MonoBehaviour
{
    // There are 13 clickable buttons on the scorecard. Each one is selected once per game.

    // Button should be deactivated with text set. Use ScoreCardUpdater singleton to
    // update UI after updating GameManger's CurrentPlayer score.

    int[] DiceRolls => DiceManager.i.diceRolls;
    Player CurrentPlayer => GameManager.i.CurrentPlayer;

	private void Start()
	{
		Test_FullHouse();
        Test_ThreeOfAKind();
        Test_Yahtzee();
	}

    #region Scorecard UI Methods

	public void OnOnesButtonClicked()
    {
        int points = NumberPoints(1, DiceRolls);
        CurrentPlayer.acesScore = points;

        UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}

	public void OnTwosButtonClicked()
	{
		int points = NumberPoints(2, DiceRolls);
		CurrentPlayer.twosScore = points;

        UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}

	public void OnThreesButtonClicked()
	{
		int points = NumberPoints(3, DiceRolls);
		CurrentPlayer.threesScore = points;

        UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}

	public void OnFoursButtonClicked()
	{
		int points = NumberPoints(4, DiceRolls);
		CurrentPlayer.foursScore = points;

        UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}

	public void OnFivesButtonClicked()
	{
		int points = NumberPoints(5, DiceRolls);
		CurrentPlayer.fivesScore = points;

        UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}


	public void OnSixesButtonClicked()
	{
		int points = NumberPoints(6, DiceRolls);
        CurrentPlayer.sixesScore = points;
        
        UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}

	public void On3KindButtonClicked()
	{
        int points = ThreeOfAKind(DiceRolls);
        CurrentPlayer.threeKindScore = points;

        UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}

	public void On4KindButtonClicked()
	{
		int points = FourOfAKind(DiceRolls);
		CurrentPlayer.fourKindScore = points;

		UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}

	public void OnSmStraightButtonClicked()
	{
        bool achieved = SmallStraight(DiceRolls);
        int points = achieved ? 30 : 0;
        CurrentPlayer.smStraightScore = points;

        UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}

	public void OnLgStraightButtonClicked()
	{
		bool achieved = LargeStraight(DiceRolls);
		int points = achieved ? 40 : 0;
		CurrentPlayer.lgStraightScore = points;

		UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}


	public void OnFullHouseButtonClicked()
	{
		bool achieved = FullHouse(DiceRolls);
		int points = achieved ? 25 : 0;
		CurrentPlayer.fullHouseScore = points;

		UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}


	public void OnYahtzeeButtonClicked()
	{
		bool achieved = Yahtzee(DiceRolls);
		int points = achieved ? 50 : 0;
		CurrentPlayer.yahtzeeScore = points;

		UpdateScoreCardUI();
		GameManager.i.OnTurnEnd();
	}


	public void OnChanceButtonClicked()
	{
		int points = Chance(DiceRolls);
		CurrentPlayer.chanceScore = points;

		UpdateScoreCardUI();
        GameManager.i.OnTurnEnd();
	}

	#endregion

    
	void UpdateScoreCardUI()
    {
		ScoreCardUpdater.i.UpdateScoreCard(CurrentPlayer);
	}

	int NumberPoints(int NumberTracking, int[] DiceRolls)
    {
        int TotalPoints = 0;
        foreach (var d in DiceRolls)
        {
            if (d == NumberTracking)
            {
                TotalPoints += NumberTracking;
            }
        }
        return TotalPoints;
    }

    int HighestQuantity(int[] DiceRolls)
    {
        int OneCount = 0;
        int TwoCount = 0;
        int ThreeCount = 0;
        int FourCount = 0;
        int FiveCount = 0;
        int SixCount = 0;
        foreach (var d in DiceRolls)
        {
            switch (d)
            {
                case 1: OneCount++; break;
                case 2: TwoCount++; break;
                case 3: ThreeCount++; break;
                case 4: FourCount++; break;
                case 5: FiveCount++; break;
                case 6: SixCount++; break;
            }
        }
        int quantity = OneCount;
        if (TwoCount > quantity) quantity = TwoCount;
        if (ThreeCount > quantity) quantity = ThreeCount;
        if (FourCount > quantity) quantity = FourCount;
        if (FiveCount > quantity) quantity = FiveCount;
        if (SixCount > quantity) quantity = SixCount;
        return quantity;
    }

    int StraightLength(int[] DiceRolls)
    {
        Array.Sort(DiceRolls);
        int SLength = 1;
        int currLength = 1;
        //if (DiceRolls[0] == 1) { currLength++; SLength++; }
        for (int i = 1; i < DiceRolls.Length; i++)
        {
            if (DiceRolls[i] == DiceRolls[i - 1] + 1) currLength++;
            else if (DiceRolls[i] != DiceRolls[i - 1]) currLength = 1;
            if (currLength > SLength) SLength = currLength;
        }
        return SLength;
    }

    int ThreeOfAKind(int[] DiceRolls)
    {
        int TotalPoints = 0;
        if (HighestQuantity(DiceRolls) < 3) return 0;
        foreach (var d in DiceRolls)
        {
            TotalPoints += d;
        }
        return TotalPoints;
    }

    int FourOfAKind(int[] DiceRolls)
    {
        int TotalPoints = 0;
        if (HighestQuantity(DiceRolls) < 4) return 0;
        foreach (var d in DiceRolls)
        {
            TotalPoints += d;
        }
        return TotalPoints;
    }

    bool FullHouse(int[] DiceRolls)
    {
        int OneCount = 0;
        int TwoCount = 0;
        int ThreeCount = 0;
        int FourCount = 0;
        int FiveCount = 0;
        int SixCount = 0;
        foreach (var d in DiceRolls)
        {
            switch (d)
            {
                case 1: OneCount++; break;
                case 2: TwoCount++; break;
                case 3: ThreeCount++; break;
                case 4: FourCount++; break;
                case 5: FiveCount++; break;
                case 6: SixCount++; break;
            }
        }
        bool Twos = false;
        bool Threes = false;

        if (!Twos && OneCount == 2) Twos = true;
        if (!Threes && OneCount == 3) Threes = true;
        if (!Twos && TwoCount == 2) Twos = true;
        if (!Threes && TwoCount == 3) Threes = true;
        if (!Twos && ThreeCount == 2) Twos = true;
        if (!Threes && ThreeCount == 3) Threes = true;
        if (!Twos && FourCount == 2) Twos = true;
        if (!Threes && FourCount == 3) Threes = true;
        if (!Twos && FiveCount == 2) Twos = true;
        if (!Threes && FiveCount == 3) Threes = true;
        if (!Twos && SixCount == 2) Twos = true;
        if (!Threes && SixCount == 3) Threes = true;
        if (Twos && Threes) return true;
        return false;
    }

    bool SmallStraight(int[] DiceRolls)
    {
        if (StraightLength(DiceRolls) >= 4) return true;
        return false;
    }

    bool LargeStraight(int[] DiceRolls)
    {
        if (StraightLength(DiceRolls) == 5) return true;
        return false;
    }

    bool Yahtzee(int[] DiceRolls)
    {
        if (HighestQuantity(DiceRolls) == 5) return true;
        return false;
    }

    int Chance(int[] DiceRolls)
    {
        int TotalPoints = 0;
        foreach (var d in DiceRolls)
        {
            TotalPoints += d;
        }
        return TotalPoints;
    }


    public GameObject yahtzeePopup;
    // Method to identify whenever yahtzee is rolled, required for UI popup and counting bonus yahtzees
    public void OnRollFinished()
    {
        if (Yahtzee(DiceRolls))
        {
            // Do yahtzee popup
            StartCoroutine(DoYahtzeePopup());

            if(CurrentPlayer.bonusYahtzeeUnlocked) // Only do yahtzee bonus when player has 50 scored in yahtzee box
            {
                CurrentPlayer.yahtzeeBonus += 100;
                UpdateScoreCardUI();
            }
        }
    }

    private IEnumerator DoYahtzeePopup()
    {
		yahtzeePopup.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        yahtzeePopup.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		yahtzeePopup.SetActive(true);
		yield return new WaitForSeconds(0.2f);
		yahtzeePopup.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		yahtzeePopup.SetActive(true);
		yield return new WaitForSeconds(0.2f);
		yahtzeePopup.SetActive(false);
		yield return new WaitForSeconds(0.2f);
		yahtzeePopup.SetActive(true);
		yield return new WaitForSeconds(2f);
		yahtzeePopup.SetActive(false);
	}

    /// <summary>
    /// Tests the 'Yahtzee' function against an array that should pass and shouldn't pass
    /// </summary>
    public void Test_Yahtzee()
    {
        Debug.Log("Running YAHTZEE Test");
        int[] diceRolls = { 3, 3, 3, 3, 3 };
        bool result = Yahtzee(diceRolls); // should return true

        diceRolls = new int[]{ 1, 2, 3, 4, 5 };
        bool result2 = Yahtzee(diceRolls); // should return false

        string testResult = (result && !result2) ? "Test Passed" : "Test Failed";
        Debug.Log(testResult);
    }


	/// <summary>
	/// Tests the 'FullHouse' function against an array that should pass and shouldn't pass
	/// </summary>
	public void Test_FullHouse()
	{
        Debug.Log("Running FULL HOUSE Test");
		int[] diceRolls = { 6, 6, 3, 3, 3 };
		bool result = FullHouse(diceRolls); // should return true

		diceRolls = new int[] { 1, 2, 3, 4, 5 };
		bool result2 = FullHouse(diceRolls); // should return false

		string testResult = (result && !result2) ? "Test Passed" : "Test Failed";
		Debug.Log(testResult);
	}


	/// <summary>
	/// Tests the 'ThreeOfAKind' function against an array that counts and doesn't count
	/// </summary>
	public void Test_ThreeOfAKind()
	{
        Debug.Log("Running THREE OF A KIND Test");
		int[] diceRolls = { 6, 2, 3, 3, 3 };
		int result = ThreeOfAKind(diceRolls); // should return 17 (6+2+3+3+3)

		diceRolls = new int[] { 1, 2, 3, 4, 5 };
		int result2 = ThreeOfAKind(diceRolls); // should return 0

		string testResult = (result == 17 && result2 == 0) ? "Test Passed" : "Test Failed";
		Debug.Log(testResult);
	}
}
