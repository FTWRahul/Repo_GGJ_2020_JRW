﻿using UnityEngine;
using UnityEngine.Networking.Match;
using TMPro;
using UnityEngine.UI;

public class JoinButton : MonoBehaviour
{
    TextMeshProUGUI buttonText;
    MatchInfoSnapshot match;
    // Start is called before the first frame update
    void Awake()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        GetComponent<Button>().onClick.AddListener(JoinMatch);
    }

    internal void Initialize(MatchInfoSnapshot match, Transform panelTransform)
    {
        this.match = match;
        buttonText.text = match.name;
        transform.SetParent(panelTransform);
        transform.localScale = Vector3.one;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
    }

    public void JoinMatch()
    {
        FindObjectOfType<CustomNetworkManager>().JoinMatch(match);
    }
}
