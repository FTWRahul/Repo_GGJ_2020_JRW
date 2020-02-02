using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Random = System.Random;

public class GameManager : NetworkBehaviour
{
    public static GameManager instance;
    
    public List<Transform> playerSpawnPositions;

    public List<PlayerIdentity> playerList;
    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    //Spawn the players in the game
    [Command][ContextMenu("Drop Player")]
    public void CmdLaunchPlayers()
    {
        for (int i = 0; i < playerList.Count; i++)
        {
            int rand = UnityEngine.Random.Range(0, playerSpawnPositions.Count);
            playerList[i].RpcSpawnPlayer(playerSpawnPositions[rand].localPosition);
            playerSpawnPositions.RemoveAt(rand);
        }
    }
}
