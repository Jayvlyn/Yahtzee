using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    [SerializeField] RollRetriever rollRetriever;
    public Transform StartSpot;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform ThrowTarget;
    [SerializeField] float throwForce = 3;

    int diceListIndex;

	public void RollDice()
    {
        rb.mass = 1f;

		diceListIndex = DiceManager.i.dice.IndexOf(this);
		DiceManager.i.diceRolls[diceListIndex] = 0;
        DiceManager.i.UpdateRollResultText();

        transform.position = StartSpot.position;
        transform.rotation = Random.rotation;
        rb.angularVelocity = new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        if(ThrowTarget != null )
        {
            rb.linearVelocity = (ThrowTarget.position - StartSpot.position).normalized * throwForce;
        }
        else
        {
            rb.linearVelocity = new Vector3(Random.Range(-3, 3), Random.Range(3, 15), Random.Range(-3, 3));
        }

        StartCoroutine(WaitForResult());
    }


    private IEnumerator WaitForResult()
    {
        while(rb.linearVelocity.magnitude > 0.05f && rb.angularVelocity.magnitude > 0.05f)
        {
            yield return null; // waiting for dice to stop moving
        }
        DiceManager.i.diceRolls[diceListIndex] = rollRetriever.QueryUpFace();
        DiceManager.i.UpdateRollResultText();
		rb.mass = 10000;
    }
}
