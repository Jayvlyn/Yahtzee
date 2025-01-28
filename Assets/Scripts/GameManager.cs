using GameEvents;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player[] players;
	public static List<string> inputNames = new List<string>();

    public static GameManager i;

	public static int currentPlayerCount;

	public int turnsFinished = 0;
	private int currentTurn = 1;
	public int CurrentTurn
	{
		get { return currentTurn; }
		set
		{
			if (value > players.Length)
			{
				currentTurn = 1;
				turnsFinished++;
				if(turnsFinished >= 13)
				{
					StartCoroutine(OnGameEnd());
				}
			}
			else currentTurn = value;


		}
	}

	public int CurrentPlayerIndex => CurrentTurn - 1;
	public Player CurrentPlayer => players[CurrentPlayerIndex];

	public GameObject scoreCardButtonBlocker;
	public GameObject diceButtonBlocker;
	public Button rollButton;
	public TMP_Text rollsLeftText;
	public TMP_Text winText;
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
			}
		}
	}

	public StringEvent onTurnUpdate;

	private void Start()
	{
		i = this;

		if(SceneManager.GetActiveScene().name.Equals("Game"))
		{
			players = new Player[currentPlayerCount];
			for(int i = 0; i < currentPlayerCount; i ++)
			{
				players[i] = new Player();
				players[i].name = inputNames[i];
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
		scoreCardButtonBlocker.SetActive(true);
		diceButtonBlocker.SetActive(true);
		StartCoroutine(TurnSwitchDelay());
	}

	public IEnumerator TurnSwitchDelay()
	{
		yield return new WaitForSeconds(3);

		CurrentTurn++;

		ScoreCardUpdater.i.SwapEnabledButtons(CurrentPlayer);

		UpdateUI();

		DiceManager.i.Init();
	}

	private void UpdateUI()
	{
		onTurnUpdate.Raise(CurrentPlayer.name);
		ScoreCardUpdater.i.UpdateScoreCard(CurrentPlayer);
	}

	public void OnAbandon()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public IEnumerator OnGameEnd()
	{
		yield return new WaitForSeconds(2);
		Player winner = players[0];
		foreach(Player p in players)
		{
			if (p.grandTotal > winner.grandTotal) winner = p;
		}
		winText.text = winner.name + " Wins!";
		winText.gameObject.SetActive(true);
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene("MainMenu");
	}
}
