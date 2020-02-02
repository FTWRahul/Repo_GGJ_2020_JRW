using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

public class CustomNetworkManager : NetworkManager
{
    public string playerName;
    public GameObject gameManager;
    private bool _isOutOfAss;

    public void StartHosting()
    {
        StartMatchMaker();
        matchMaker.CreateMatch(playerName, 5, true, "", "", "", 0, 0, OnMatchCreated);
        Debug.Log(" For Server Address "+networkAddress);
        Debug.Log( " For Server Port "+networkPort);
        GameObject go = Instantiate(gameManager);
        NetworkServer.Spawn(gameManager);
    }

    private void OnMatchCreated(bool success, string extendedInfo, MatchInfo responseData)
    {
        base.StartHost(responseData);
        RefreshMatches();
    }

    public void RefreshMatches()
    {
        if(matchMaker == null)
        {
            StartMatchMaker();
            Debug.Log("Match maker started on client because it was null");
        }

        matchMaker.ListMatches(0,10, "", true, 0,0, HandleListMatchesComplet);
    }

    internal void JoinMatch(MatchInfoSnapshot match)
    {
        if(matchMaker == null)
        {
            StartMatchMaker();
            Debug.Log("Match maker started on client because it was null");
            //Debug.Log("  " );
        }
        matchMaker.JoinMatch(match.networkId, "", "", "", 0, 0, HandleJoinedMatch);
    }

    private void HandleJoinedMatch(bool success, string extendedInfo, MatchInfo responseData)
    {
        StartCoroutine(JoinWithDelay(responseData));
    }

    IEnumerator JoinWithDelay(MatchInfo responseData)
    {
        if (!_isOutOfAss)
        {
            _isOutOfAss = true;
            yield return null;
            Debug.Log(" Address "+networkAddress);
            Debug.Log( " Port "+networkPort);
            Debug.Log("Server address "+ responseData.address);
            Debug.Log("Server port "+ responseData.port);
            StartClient(responseData);
        }
        
    }

    private void HandleListMatchesComplet(bool success, string extendedInfo, List<MatchInfoSnapshot> responseData)
    {
        if(success)
        {
            AviliableMatchesList.HandleNewMatchList(responseData);
        }
        else
        {
            //No matches found
        }
    }

    public void SetPlayerName(string inName)
    {
        playerName = inName;
    }
}