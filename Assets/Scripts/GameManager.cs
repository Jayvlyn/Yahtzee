using GameEvents;
using UnityEngine;
using UnityEngine.SceneManagement;

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
			if (value >= players.Length) currentTurn = 1;
			else currentTurn = value;
		}
	}

	public static int CurrentPlayerIndex => CurrentTurn - 1;
	public static Player CurrentPlayer => players[CurrentPlayerIndex];

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
		CurrentTurn++;

		UpdateUI();

		Manager.i.Init();
	}

	private void UpdateUI()
	{
		onTurnUpdate.Raise(CurrentTurn);
		ScoreCardUpdater.i.UpdateScoreCard(CurrentPlayer);
	}
}
