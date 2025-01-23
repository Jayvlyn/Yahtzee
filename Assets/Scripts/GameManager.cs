using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Player[] players;

    public static GameManager i;

	private void Start()
	{
		i = this;
	}

	public void OnGameStart(int playerCount)
	{
		players = new Player[playerCount];
	}
}
