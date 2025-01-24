using UnityEngine;
using TMPro;

public class TurnTextUpdater : MonoBehaviour
{
    public TMP_Text turnText;

    public void UpdateText(int playerNum)
    {
        turnText.text = "Player " + playerNum + "'s Turn";
    }
}
