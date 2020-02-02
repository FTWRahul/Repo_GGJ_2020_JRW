using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerIdentity : NetworkBehaviour
{
   private GameObject playerPrefab;

   private void Awake()
   {
      if (isLocalPlayer)
      {
         GameManager.instance.PlayerList.Add(this);
      }
   }
   
   [Command]
   public void CmdSpawnPlayer(Vector3 spawnPosi)
   {
      if (isLocalPlayer)
      {
         Instantiate(playerPrefab, spawnPosi, Quaternion.identity);
      }
   }
}
