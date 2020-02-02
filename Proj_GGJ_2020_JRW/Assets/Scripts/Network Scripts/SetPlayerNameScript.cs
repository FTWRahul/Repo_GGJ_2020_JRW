﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetPlayerNameScript : MonoBehaviour
{
    TMP_InputField inputField;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.onEndEdit.AddListener(delegate { LockInput(inputField); });
    }

    void LockInput(TMP_InputField input)
    {
        if (input.text.Length > 0)
        {
            Debug.Log("Text has been entered");
            FindObjectOfType<CustomNetworkManager>().SetPlayerName(inputField.text);
        }
        else if (input.text.Length == 0)
        {
            Debug.Log("Main Input Empty");
        }
    }

}
