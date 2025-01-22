using TMPro; // Use UnityEngine.UI if using InputField
using UnityEngine;


// Generated with ChatGPT-4 https://chatgpt.com/share/679122df-72fc-800d-b374-cce24d5f17f2
public class IntegerInputValidator : MonoBehaviour
{
	[SerializeField] private TMP_InputField inputField; // Replace with InputField if needed
	[SerializeField] private int minValue = 2;
	[SerializeField] private int maxValue = 99;

	private void Start()
	{
		if (inputField == null)
			inputField = GetComponent<TMP_InputField>();

		inputField.onEndEdit.AddListener(ValidateInput);
	}

	private void ValidateInput(string input)
	{
		if (int.TryParse(input, out int value))
		{
			if (value < minValue || value > maxValue)
			{
				inputField.text = Mathf.Clamp(value, minValue, maxValue).ToString();
			}
		}
		else
		{
			inputField.text = minValue.ToString(); // Default to the minimum value if invalid
		}
	}
}
