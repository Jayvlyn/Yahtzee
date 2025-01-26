using GameEvents;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public List<DiceRoller> dice;
	[SerializeField] protected List<DiceRoller> selectedDice;

    public int[] diceRolls = new int[5];
    public bool rollFinished = false;

    public static DiceManager i;

    [SerializeField] private VoidEvent onRollFinished;

	[SerializeField] TMP_Text diceResultText;

	void Start()
    {
        i = this;
        Init();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                //Debug.Log(hit.transform.gameObject.name);
                if(hit.collider.gameObject.TryGetComponent(out DiceRoller die))
                {
                    if (selectedDice.Contains(die)) // Already in selected dice, deselect
                    {
                        selectedDice.Remove(die);
                    }
                    else // Not found in selected dice, add to selected dice
                    {
						selectedDice.Add(die);
					}

                }
            }
        }

        if (!rollFinished)
        {
            bool negOneFound = false;
            for (int i = 0; i < diceRolls.Length; i++)
            {
                if (diceRolls[i] == -1)
                {
                    negOneFound = true;
                    break;
                }
            }
            if (!negOneFound)
            {
                rollFinished = true;
                onRollFinished.Raise();
            }
        }
    }

    public void UpdateRollResultText()
    {
        string txt = "<mspace=10>  " + diceRolls[0] + "      " + diceRolls[1] + "      " + diceRolls[2] + "      " + diceRolls[3] + "      " + diceRolls[4] + "  <color=#FFFFFF00>."; // transparent font period at end to preserve white space at end of text mesh display
        txt = txt.Replace("  0  ", "     ");
        diceResultText.text = txt;
	}

    public void Init()
    {
        selectedDice = new List<DiceRoller>(dice);
        diceRolls = new int[5];
        foreach(DiceRoller d in dice)
        {
            d.transform.position = new Vector3(1000, 1000, 1000);
        }
        UpdateRollResultText();
    }

	public void RollDice()
    {
        int startCount = selectedDice.Count - 1;
        for (int i = startCount; i >= 0; i--)
        {
            selectedDice[i].RollDice();
            selectedDice.Remove(selectedDice[i]);
        }
    }
}
