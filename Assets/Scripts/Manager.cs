using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] List<DiceRoller> dice;
    protected List<DiceRoller> selectedDice;

    public static Manager i;

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
    }

	public void Init()
	{
		selectedDice = dice;
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
