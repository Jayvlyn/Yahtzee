using UnityEngine;

public class DiceRoller : MonoBehaviour
{
    [SerializeField] RollRetriever rollRetriever;
    [SerializeField] Transform StartSpot;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform ThrowTarget;
    [SerializeField] float throwForce = 3;

	public void RollDice()
    {
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
    }
}
