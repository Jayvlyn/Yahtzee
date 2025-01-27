using GameEvents;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Player[] players;

    public static GameManager i;

	public static int currentPlayerCount;

	private static int currentTurn = 1;
	public static int CurrentTurn
	{
		get { return currentTurn; }
		set
		{
			if (value > players.Length) currentTurn = 1;
			else currentTurn = value;


		}
	}

	public static int CurrentPlayerIndex => CurrentTurn - 1;
	public static Player CurrentPlayer => players[CurrentPlayerIndex];

	public GameObject scoreCardButtonBlocker;
	public Button rollButton;
	public TMP_Text rollsLeftText;
	private int rollsLeft = 3;
	public int RollsLeft
	{
		get { return rollsLeft; }
		set
		{
			rollsLeft = value;
			rollsLeftText.text = "Rolls: " + rollsLeft + "/3";
			if (rollsLeft <= 0)
			{
				rollButton.interactable = false;
				scoreCardButtonBlocker.SetActive(false);
			}
			else if (rollsLeft < 3)
			{
				rollButton.interactable = true;
				scoreCardButtonBlocker.SetActive(false);
			}
			else
			{
				rollButton.interactable = true;
				scoreCardButtonBlocker.SetActive(true);
			}
		}
	}

	public IntEvent onTurnUpdate;

	private void Start()
	{
		i = this;

		if(SceneManager.GetActiveScene().name.Equals("Game"))
		{
			players = new Player[currentPlayerCount];
			for(int i = 0; i < currentPlayerCount; i ++)
			{
				players[i] = new Player();
			}

			CurrentTurn = 1;
			UpdateUI();
		}
	}

	public void OnGameStart(int playerCount)
	{
		currentPlayerCount = playerCount;
		SceneManager.LoadScene("Game");
	}

	public void OnTurnEnd()
	{
		StartCoroutine(TurnSwitchDelay());
	}

	public IEnumerator TurnSwitchDelay()
	{
		yield return new WaitForSeconds(3);

		CurrentTurn++;

		UpdateUI();

		DiceManager.i.Init();
	}

	private void UpdateUI()
	{
		onTurnUpdate.Raise(CurrentTurn);
		ScoreCardUpdater.i.UpdateScoreCard(CurrentPlayer);
	}
}
