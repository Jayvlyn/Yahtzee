using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject playerCountScreen;
    
    public void OnQuit()
    {
        Application.Quit();
    }

    public void OnNewGame() // Change to screen where user selects player count
    {
        playerCountScreen.SetActive(true);
    }

    public void OnStart() // Player count entered, start game with x players
    {
        SceneManager.LoadScene("Game");
    }

    public void OnBack() // Back to main menu
    {
        playerCountScreen.SetActive(false);
    }
}
