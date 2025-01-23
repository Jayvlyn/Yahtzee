using System.Linq;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] DiceRoller[] dice;
    private int dieCount;
    protected DiceRoller[] selectedDice;

    void Start()
    {
        selectedDice = dice;
        dieCount = selectedDice.Length;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            DiceRoller die;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log(hit.transform.gameObject.name);
                die = hit.collider.gameObject.GetComponent<DiceRoller>();
                if (die != null && !selectedDice.Contains(die)) { selectedDice[dieCount] = die; dieCount++; }
            }
        }
    }

    public void RollDice()
    {
        for (var i = 0; i < dieCount; i++)
        {
            selectedDice[i].RollDice();
            selectedDice[i] = null;
        }
        dieCount = 0;
    }
}
