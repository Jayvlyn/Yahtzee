using UnityEngine;

public class UIDiceSelector : MonoBehaviour
{
    public int index = 0;

    public void OnClick()
    {
		DiceRoller die = DiceManager.i.dice[index];
		if (DiceManager.i.selectedDice.Contains(die)) // Already in selected dice, deselect
		{
			DiceManager.i.selectedDice.Remove(die);

			die.ChangeMaterial(DiceManager.i.defaultMat);
		}
		else // Not found in selected dice, add to selected dice
		{
			DiceManager.i.selectedDice.Add(die);

			die.ChangeMaterial(DiceManager.i.highlightedMat, true);
		}
	}
}
