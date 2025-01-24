using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    public GameObject playerCountScreen;

    public TMP_Text playerCountInput;
    
    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnNewGame() // Change to screen where user selects player count
    {
        playerCountScreen.SetActive(true);
    }

    public void OnStart()
    {
		string input = playerCountInput.text;

        // idk whats going on here, but the input string has zero width invisible character in it so i have to clean it up
		string cleanedInput = input.Trim().Replace("\u200B", "");


		if (int.TryParse(cleanedInput, out int playerCount))
		{
			Debug.Log("Parsed Player Count: " + playerCount);
			GameManager.i.OnGameStart(playerCount);
		}
		else
		{
			Debug.LogError("Invalid input somehow, despite my awesome chat gpt generated input validator");
		}


		GameManager.i.OnGameStart(playerCount);
    }

    public void OnBack() // Back to main menu
    {
        playerCountScreen.SetActive(false);
    }
}
