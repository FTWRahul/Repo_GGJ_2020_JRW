using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.Networking.Match;
using System;

public class MatchListPanel : MonoBehaviour
{
    [SerializeField]
    private JoinButton joinButtonPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        AviliableMatchesList.OnAvailableMatchesChanged += AviliableMatchesListOnAvailableMatchesChanged;
    }

    private void AviliableMatchesListOnAvailableMatchesChanged(List<MatchInfoSnapshot> matches)
    {
        ClearExistingButtons();
        CreateNewJoinGameButtons(matches);
    }


    private void ClearExistingButtons()
    {
        var buttons = GetComponentsInChildren<JoinButton>();
        foreach (var button in buttons)
        {
            Destroy(button.gameObject);
        }
    }

    private void CreateNewJoinGameButtons(List<MatchInfoSnapshot> matches)
    {
        foreach (var match in matches)
        {
            var button = Instantiate(joinButtonPrefab);
            button.Initialize(match, transform);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
