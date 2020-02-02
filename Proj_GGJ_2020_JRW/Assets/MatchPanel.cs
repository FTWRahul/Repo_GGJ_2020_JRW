using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.Networking.Match;

public class MatchPanel : MonoBehaviour
{
    [SerializeField]
    private JoinButton joinButtonPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        AviliableMatchesList.OnAvailableMatchesChanged += OnAvailableMatchesChanged;
    }

    private void OnAvailableMatchesChanged(List<MatchInfoSnapshot> matches)
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
            button.initialize(match, transform);
        }
    }
}
