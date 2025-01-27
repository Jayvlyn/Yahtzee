using UnityEngine;
using TMPro;

public class ScoreCardUpdater : MonoBehaviour
{
	public static ScoreCardUpdater i;

	private void Start()
	{
		i = this;
	}

	// upper
	public TMP_Text acesBtnText;
	public TMP_Text twosBtnText;
	public TMP_Text threesBtnText;
	public TMP_Text foursBtnText;
	public TMP_Text fivesBtnText;
	public TMP_Text sixesBtnText;

	public TMP_Text upperPreBonusTotalText;
	public TMP_Text upperBonusText;
	public TMP_Text upperTotalText;
	public TMP_Text upperTotalText2;

	// lower
	public TMP_Text threeKindBtnText;
	public TMP_Text fourKindBtnText;
	public TMP_Text fullHouseBtnText;
	public TMP_Text smStraightBtnText;
	public TMP_Text lgStraightBtnText;
	public TMP_Text yahtzeeBtnText;
	public TMP_Text chanceBtnText;

	public TMP_Text yahtzeeBonusText;
	public TMP_Text lowerTotalText;
	public TMP_Text grandTotalText;

	public void UpdateScoreCard(Player p)
	{
		GameManager.i.scoreCardButtonBlocker.SetActive(true);

		CalculateOtherScores(p);

		// Upper Scores
		UpdateScore(acesBtnText, p.acesScore);
		UpdateScore(twosBtnText, p.twosScore);
		UpdateScore(threesBtnText, p.threesScore);
		UpdateScore(foursBtnText, p.foursScore);
		UpdateScore(fivesBtnText, p.fivesScore);
		UpdateScore(sixesBtnText, p.sixesScore);

		// Calculated Upper
		UpdateScore(upperPreBonusTotalText, p.upperPreBonusTotal);
		UpdateScore(upperBonusText, p.upperBonus);
		UpdateScore(upperTotalText, p.upperTotal);
		UpdateScore(upperTotalText2, p.upperTotal);

		// Lower Scores
		UpdateScore(threeKindBtnText, p.threeKindScore);
		UpdateScore(fourKindBtnText, p.fourKindScore);
		UpdateScore(fullHouseBtnText, p.fullHouseScore);
		UpdateScore(smStraightBtnText, p.smStraightScore);
		UpdateScore(lgStraightBtnText, p.lgStraightScore);
		UpdateScore(yahtzeeBtnText, p.yahtzeeScore);
		UpdateScore(chanceBtnText, p.chanceScore);

		// Calculated Lower
		UpdateScore(yahtzeeBonusText, p.yahtzeeBonus);
		UpdateScore(lowerTotalText, p.lowerTotal);
		UpdateScore(grandTotalText, p.grandTotal);
	}

	public void UpdateScore(TMP_Text tmp, int score)
	{
		if(score == -1)
		{
			tmp.text = "";
		}
		else
		{
			tmp.text = score.ToString();
		}
	}

	public void CalculateOtherScores(Player p)
	{
		// Upper
		p.upperPreBonusTotal = 0;
		if(p.acesScore > -1) p.upperPreBonusTotal += p.acesScore;
		if(p.twosScore > -1) p.upperPreBonusTotal += p.twosScore;
		if(p.threesScore > -1) p.upperPreBonusTotal += p.threesScore;
		if(p.foursScore > -1) p.upperPreBonusTotal += p.foursScore;
		if(p.fivesScore > -1) p.upperPreBonusTotal += p.fivesScore;
		if(p.sixesScore > -1) p.upperPreBonusTotal += p.sixesScore;
		
		p.upperBonus = (p.upperPreBonusTotal >= 63) ? 35 : 0;
		p.upperTotal = p.upperPreBonusTotal + p.upperBonus;

		// Lower
		p.lowerTotal = p.yahtzeeBonus;
		if (p.threeKindScore > -1) p.lowerTotal += p.threeKindScore;
		if (p.fourKindScore > -1) p.lowerTotal += p.fourKindScore;
		if (p.fullHouseScore > -1) p.lowerTotal += p.fullHouseScore;
		if (p.smStraightScore > -1) p.lowerTotal += p.smStraightScore;
		if (p.lgStraightScore > -1) p.lowerTotal += p.lgStraightScore;
		if (p.yahtzeeScore > -1) p.lowerTotal += p.yahtzeeScore;
		if (p.chanceScore > -1) p.lowerTotal += p.chanceScore;

		p.grandTotal = p.lowerTotal + p.upperTotal;
	}
}
