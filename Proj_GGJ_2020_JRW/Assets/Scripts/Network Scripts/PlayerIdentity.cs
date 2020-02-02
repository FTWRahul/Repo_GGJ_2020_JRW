using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerIdentity : NetworkBehaviour
{
   [SerializeField]
   private GameObject playerPrefab;

   public GameObject gameManager;

   private GameManager gm;

   private void Awake()
   {
       //CmdSpawnGameManager();
       //gameManager = FindObjectOfType<GameManager>();
       gm = FindObjectOfType<GameManager>();
//      Debug.Log("Is I the local boi?" + isLocalPlayer);
//      Debug.Log("Do I have Athority?" + hasAuthority);
       gm.playerList.Add(this);
//      Debug.Log("Added to list");
   }

   [Command]
   void CmdSpawnGameManager()
   {
       GameObject go = Instantiate(gameManager);
       NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
   }
   
   [ClientRpc]
   public void RpcSpawnPlayer(Vector3 spawnPosi)
   {
       if (isLocalPlayer)
       {
           GameObject player = Instantiate(playerPrefab, spawnPosi, Quaternion.identity);
           player.transform.parent = this.transform;
           NetworkServer.SpawnWithClientAuthority(player, connectionToClient);
           gm.CmdLaunchPlayers();
       }
   }

   public override void OnStartLocalPlayer()
   {
      base.OnStartLocalPlayer();
//      Debug.Log("Started");
//      Debug.Log("Is I the local boi?" + isLocalPlayer);
//      Debug.Log("Do I have Athority?" + hasAuthority);
   }
}
