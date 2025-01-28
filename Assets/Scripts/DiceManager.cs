using GameEvents;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public List<DiceRoller> dice;
	public List<DiceRoller> selectedDice;

    public int[] diceRolls = new int[5];
    public bool rollFinished = true;

    public static DiceManager i;

    [SerializeField] private VoidEvent onRollFinished;

	[SerializeField] TMP_Text diceResultText;

	public Material defaultMat;
	public Material highlightedMat;

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

            if (Physics.Raycast(ray, out hit, 100) && GameManager.i.RollsLeft > 0)
            {
                //Debug.Log(hit.transform.gameObject.name);
                if(hit.collider.gameObject.TryGetComponent(out DiceRoller die))
                {
                    if (selectedDice.Contains(die)) // Already in selected dice, deselect
                    {
                        selectedDice.Remove(die);


                        die.ChangeMaterial(defaultMat);
                    }
                    else // Not found in selected dice, add to selected dice
                    {
						selectedDice.Add(die);

                        die.ChangeMaterial(highlightedMat, true);
					}

                    if(selectedDice.Count < 1)
                    {
                        GameManager.i.rollButton.interactable = false;
                    }
                    else
                    {
                        GameManager.i.rollButton.interactable = true;
                    }

                }
            }
        }

        if (!rollFinished)
        {
            bool zeroFound = false;
            for (int i = 0; i < diceRolls.Length; i++)
            {
                if (diceRolls[i] == 0)
                {
                    zeroFound = true;
                    break;
                }
            }
            if (!zeroFound)
            {
                rollFinished = true;
                onRollFinished.Raise();
				GameManager.i.scoreCardButtonBlocker.SetActive(false);
				GameManager.i.diceButtonBlocker.SetActive(false);
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
        rollFinished = true;
		GameManager.i.scoreCardButtonBlocker.SetActive(true);
		GameManager.i.diceButtonBlocker.SetActive(true);
        GameManager.i.rollButton.interactable = true;
        GameManager.i.RollsLeft = 3;
        selectedDice = new List<DiceRoller>(dice);
        diceRolls = new int[5];
        foreach(DiceRoller d in dice)
        {
            d.transform.position = new Vector3(-1000, -1000, -1000);
			d.ChangeMaterial(defaultMat, true);
		}
        UpdateRollResultText();
	}

	public void RollDice()
    {
        GameManager.i.rollButton.interactable = false;
		GameManager.i.scoreCardButtonBlocker.SetActive(true);
		GameManager.i.diceButtonBlocker.SetActive(true);
		rollFinished = false;
        GameManager.i.RollsLeft--;
        int startCount = selectedDice.Count - 1;
        for (int i = startCount; i >= 0; i--)
        {
            selectedDice[i].RollDice();
            selectedDice[i].ChangeMaterial(defaultMat);
            selectedDice.Remove(selectedDice[i]);
        }
    }
}
