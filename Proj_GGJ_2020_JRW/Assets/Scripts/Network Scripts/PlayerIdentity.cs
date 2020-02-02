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

   private void Start()
   {
       //CmdSpawnGameManager();
       //gameManager = FindObjectOfType<GameManager>();
//      Debug.Log("Is I the local boi?" + isLocalPlayer);
//      Debug.Log("Do I have Athority?" + hasAuthority);
//      Debug.Log("Added to list");

       StartCoroutine(StartWithDelay());
   }

   IEnumerator StartWithDelay()
   {
       yield return new WaitForSeconds(2f);
       //gm = FindObjectOfType<GameManager>();
       if (isLocalPlayer)
       {
           CmdSpawnPlayer(Vector3.one * 2);
           GameManager.instance.playerList.Add(this);
       }
   }

   [Command]
   void CmdSpawnGameManager()
   {
       GameObject go = Instantiate(gameManager);
       NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
   }
   
   [Command]
   public void CmdSpawnPlayer(Vector3 spawnPosi)
   {
       GameObject player = Instantiate(playerPrefab, spawnPosi, Quaternion.identity);
       player.transform.parent = this.transform;
       NetworkServer.SpawnWithClientAuthority(player, connectionToClient);
   }

   public override void OnStartLocalPlayer()
   {
      base.OnStartLocalPlayer();
//      Debug.Log("Started");
//      Debug.Log("Is I the local boi?" + isLocalPlayer);
//      Debug.Log("Do I have Athority?" + hasAuthority);
   }
}
