using System.Linq;
using UnityEngine;

public class RollRetriever : MonoBehaviour
{
    GameObject parent;
    Vector3[] directions;
    [SerializeField] string CurrentUpFace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = gameObject;
        directions = new Vector3[6];
        
    }

    // Update is called once per frame
    void Update()
    {
        directions[(int)JDirection.up] = gameObject.transform.up;
        directions[(int)JDirection.down] = -gameObject.transform.up;
        directions[(int)JDirection.right] = gameObject.transform.right;
        directions[(int)JDirection.left] = -gameObject.transform.right;
        directions[(int)JDirection.forward] = gameObject.transform.forward;
        directions[(int)JDirection.backward] = -gameObject.transform.forward;
        Vector3 up = new Vector3(0,1,0);
        float[] outputs = new float[6];
        for (int i = 0; i < 6; i++)
        {
            outputs[i] = Vector3.Dot(up, directions[i]);
        }
        var output = (JDirection)System.Array.IndexOf(outputs, outputs.Max());
        CurrentUpFace = output.ToString();
    }

    public enum JDirection
    {
        up, down, right, left, forward, backward
    }
}
