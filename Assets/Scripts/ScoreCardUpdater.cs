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

	public void UpdateScoreCard(Player currentPlayer)
	{
		// Upper Scores
		UpdateScore(acesBtnText, currentPlayer.acesScore);
		UpdateScore(twosBtnText, currentPlayer.twosScore);
		UpdateScore(threesBtnText, currentPlayer.threesScore);
		UpdateScore(foursBtnText, currentPlayer.foursScore);
		UpdateScore(fivesBtnText, currentPlayer.fivesScore);
		UpdateScore(sixesBtnText, currentPlayer.sixesScore);

		// Calculated Upper
		UpdateScore(upperPreBonusTotalText, currentPlayer.upperPreBonusTotal);
		UpdateScore(upperBonusText, currentPlayer.upperBonus);
		UpdateScore(upperTotalText, currentPlayer.upperTotal);


		// Lower Scores
		UpdateScore(threeKindBtnText, currentPlayer.threeKindScore);
		UpdateScore(fourKindBtnText, currentPlayer.fourKindScore);
		UpdateScore(fullHouseBtnText, currentPlayer.fullHouseScore);
		UpdateScore(smStraightBtnText, currentPlayer.smStraightScore);
		UpdateScore(lgStraightBtnText, currentPlayer.lgStraightScore);
		UpdateScore(yahtzeeBtnText, currentPlayer.yahtzeeScore);
		UpdateScore(chanceBtnText, currentPlayer.chanceScore);

		// Calculated Lower
		UpdateScore(yahtzeeBonusText, currentPlayer.yahtzeeBonus);
		UpdateScore(lowerTotalText, currentPlayer.lowerTotal);
		UpdateScore(grandTotalText, currentPlayer.grandTotal);
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
}
