using System.Collections;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
using Color = UnityEngine.Color;

public class DiceRoller : MonoBehaviour
{
    [SerializeField] RollRetriever rollRetriever;
    public Transform StartSpot;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform ThrowTarget;
    [SerializeField] float throwForce = 3;
    [SerializeField] TrailRenderer tr;
    public Image diceUI;

    public MeshRenderer meshRenderer;

    int diceListIndex;

	public void RollDice()
    {
        rb.mass = 1f;

		diceListIndex = DiceManager.i.dice.IndexOf(this);
		DiceManager.i.diceRolls[diceListIndex] = 0;
        DiceManager.i.UpdateRollResultText();

        tr.enabled = false;
        transform.position = StartSpot.position;
        tr.enabled = true;
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

    public Color unselectedColor;
    public Color selectedColor;
	public void ChangeMaterial(Material mat, bool on = false)
	{
		Material[] materials = meshRenderer.materials;
        materials[0] = mat;
		meshRenderer.materials = materials;

        if(on)
		{
            diceUI.color = selectedColor;
			
		}
        else
        {
            diceUI.color = unselectedColor;
        }
	}
}
