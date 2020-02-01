using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetPlayerName : MonoBehaviour
{
    private TMP_InputField _inputField;

    private void Start()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputField.onEndEdit.AddListener(delegate { LockInput(_inputField); });
    }

    void LockInput(TMP_InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log("Text has been entered");
            FindObjectOfType<CustomNetworkManager>().SetPlayerName(_inputField.text);
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("Main Input Empty");
        }
    }
}
