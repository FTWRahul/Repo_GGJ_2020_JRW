using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerIdentity : NetworkBehaviour
{
   [SerializeField]
   private GameObject playerPrefab;

   public GameManager gameManager;

   private void Awake()
   {
      gameManager = FindObjectOfType<GameManager>();
//      Debug.Log("Is I the local boi?" + isLocalPlayer);
//      Debug.Log("Do I have Athority?" + hasAuthority);
      gameManager.playerList.Add(this);
//      Debug.Log("Added to list");
   }
   
   [ClientRpc]
   public void RpcSpawnPlayer(Vector3 spawnPosi)
   {

         GameObject player = Instantiate(playerPrefab, spawnPosi, Quaternion.identity);
         player.transform.parent = this.transform;
         NetworkServer.SpawnWithClientAuthority(player, connectionToClient);
         gameManager.CmdLaunchPlayers();
   }

   public override void OnStartLocalPlayer()
   {
      base.OnStartLocalPlayer();
//      Debug.Log("Started");
//      Debug.Log("Is I the local boi?" + isLocalPlayer);
//      Debug.Log("Do I have Athority?" + hasAuthority);
   }
}
