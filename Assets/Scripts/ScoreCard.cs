using UnityEngine;

public class ScoreCard
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

    int ThreeOfAKind(int[] DiceRolls)
    {
        int TotalPoints = 0;

        return TotalPoints;
    }

    int FourOfAKind(int[] DiceRolls)
    {
        int TotalPoints = 0;

        return TotalPoints;
    }

    bool FullHouse(int[] DiceRolls)
    {

        return false;
    }

    bool SmallStraight(int[] DiceRolls)
    {

        return false;
    }

    bool LargeStraight(int[] DiceRolls)
    {

        return false;
    }

    bool Yahtzee(int[] DiceRolls)
    {

        return false;
    }
}
