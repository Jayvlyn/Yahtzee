using UnityEngine;

public class Player
{
    // Upper section
    public int acesScore = -1;
    public int twosScore = -1;
    public int threesScore = -1;
    public int foursScore = -1;
    public int fivesScore = -1;
    public int sixesScore = -1;

    public int upperPreBonusTotal = 0;
    public int upperBonus = 0;

    public int upperTotal = 0; // shown twice on the scorecard

    // Lower Section
    public int threeKindScore = -1;
    public int fourKindScore = -1;
    public int fullHouseScore = -1;
    public int smStraightScore = -1;
    public int lgStraightScore = -1;
    public int yahtzeeScore = -1;
    public int chanceScore = -1;

    public int yahtzeeBonus = 0;

    public int lowerTotal = 0;

    public int grandTotal = 0;

    // Helper Vars
    public bool bonusYahtzeeUnlocked = false;
}
