using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class MainMenu : MonoBehaviour
{
    public GameObject playerCountScreen;
    public GameObject playerNamesScreen;

    public TMP_Text playerCountInput;

    public TMP_InputField playerNameInput;
    public TMP_Text playerNameInputPrompt;

    private int playerCount = 0;
    
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
		GameManager.i.OnGameStart(playerCount);
    }

    public void OnBack() // Back to main menu
    {
        playerCountScreen.SetActive(false);
    }

    public void OnConfirm()
    {
		string input = playerCountInput.text;

		// idk whats going on here, but the input string has zero width invisible character in it so i have to clean it up
		string cleanedInput = input.Trim().Replace("\u200B", "");

		if (int.TryParse(cleanedInput, out int pCount))
		{
            playerCount = pCount;
		}
		else
		{
			Debug.LogError("Invalid input somehow, despite my awesome chat gpt generated input validator");
		}

        UpdatePrompt();
        GameManager.inputNames.Clear();
		playerNamesScreen.SetActive(true);
    }

    private int namesEntered = 0;
    public void OnDone()
    {
        string inputName = playerNameInput.text;
        GameManager.inputNames.Add(inputName);
        namesEntered++;

        if(namesEntered == playerCount)
        {
            OnStart();
        }
        else
        {
            // Set up for next input
            playerNameInput.text = "";
            UpdatePrompt();
        }
    }

    private void UpdatePrompt()
    {
		playerNameInputPrompt.text = "Enter Player " + (namesEntered + 1) + "'s Name";
	}    
}
