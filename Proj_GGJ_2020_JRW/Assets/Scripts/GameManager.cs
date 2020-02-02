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

    private List<PlayerIdentity> _playerList;

    public List<PlayerIdentity> PlayerList
    {
        get
        {
            if (_playerList.Count == 2)
            {
                LaunchPlayers();
            }
            return _playerList;
        }
    }


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
    public void LaunchPlayers()
    {
        for (int i = 0; i < _playerList.Count; i++)
        {
            int rand = UnityEngine.Random.Range(0, playerSpawnPositions.Count);
            _playerList[i].CmdSpawnPlayer(playerSpawnPositions[rand].position);
            playerSpawnPositions.RemoveAt(rand);
        }
    }
}
