using System.Linq;
using UnityEngine;

public class RollRetriever : MonoBehaviour
{
    GameObject parent;
    Vector3[] directions;
    [SerializeField] string CurrentUpFace;
    [SerializeField] int outputNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = gameObject;
        directions = new Vector3[6];
        
    }

    public int QueryUpFace()
    {
		//query the direction vectors
		directions[(int)JDirection.up] = gameObject.transform.up;
		directions[(int)JDirection.down] = -gameObject.transform.up;
		directions[(int)JDirection.right] = gameObject.transform.right;
		directions[(int)JDirection.left] = -gameObject.transform.right;
		directions[(int)JDirection.forward] = gameObject.transform.forward;
		directions[(int)JDirection.backward] = -gameObject.transform.forward;
		Vector3 up = new Vector3(0, 1, 0);
		float[] outputs = new float[6];
		//dot product the direction vectors
		for (int i = 0; i < 6; i++)
		{
			outputs[i] = Vector3.Dot(up, directions[i]);
		}

		//extrapolate JDirection of side facing up
		var output = (JDirection)System.Array.IndexOf(outputs, outputs.Max());
		CurrentUpFace = output.ToString();
		//convert JDirection to number value
		outputNumber = getValue(output);

        return outputNumber;
	}

    public enum JDirection
    {
        up, down, right, left, forward, backward
    }

    private int getValue(JDirection direction)
    {
        //opposite sides should add up to 7
        switch (direction)
        {
            case JDirection.up:
                //return 1;
                return 3;
            case JDirection.down:
                //return 6;
                return 4;
            case JDirection.right:
                //return 2;
                return 1;
            case JDirection.left:
                //return 5;
                return 6;
            case JDirection.forward:
                //return 3;
                return 2;
            case JDirection.backward:
                //return 4;
                return 5;
        }
        return 0;
    }
}
