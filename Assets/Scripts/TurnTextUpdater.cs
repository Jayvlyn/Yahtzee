using UnityEngine;
using TMPro;

public class TurnTextUpdater : MonoBehaviour
{
    public TMP_Text turnText;

    public void UpdateText(string playerName)
    {
        turnText.text = playerName + "'s Turn";
    }
}
