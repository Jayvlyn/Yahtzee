using System;
using UnityEngine;

public class ScoreCard : MonoBehaviour
{
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
        if (FourCount > quantity) quantity = FiveCount;
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
}
