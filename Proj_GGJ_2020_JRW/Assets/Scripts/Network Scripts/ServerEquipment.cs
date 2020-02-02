using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ServerEquipment : NetworkBehaviour
{
    public List<GameObject> PHeadPrefabs;
    public List<GameObject> PWeaponPrefabs;
    public List<GameObject> PFeetPrefabs;

    /*public void Equip(bodyComponent Component, int newID)
    {
        switch (Component)
        {
            case bodyComponent.HEAD:
                PHeadPrefabs[newID-1].SetActive(false);
                break;
            case bodyComponent.WEAPON:
                PWeaponPrefabs[newID-1].SetActive(false);
                break;
            case bodyComponent.FEET:
                PFeetPrefabs[newID-1].SetActive(false);
                break;
        }
    }*/

    public void Unequip(bodyComponent Component, int newID, Vector3 DropLocation)
    {
        switch (Component)
        {
            case bodyComponent.HEAD:
                CmdSpawnEquipment(PHeadPrefabs[newID-1], DropLocation);
                /*PHeadPrefabs[newID-1].transform.position = DropLocation;
                PHeadPrefabs[newID-1].SetActive(true);*/
                break;
            case bodyComponent.WEAPON:
                CmdSpawnEquipment(PWeaponPrefabs[newID-1], DropLocation);
                /*PWeaponPrefabs[newID-1].transform.position = DropLocation;
                PWeaponPrefabs[newID-1].SetActive(true);*/
                break;
            case bodyComponent.FEET:
                CmdSpawnEquipment(PFeetPrefabs[newID-1], DropLocation);
                /*PFeetPrefabs[newID-1].transform.position = DropLocation;
                PFeetPrefabs[newID-1].SetActive(true);*/
                break;
        }
    }

    [Command]
    public void CmdServerDestroy(GameObject equipment)
    {
        NetworkServer.Destroy(equipment);
    }
    
    [Command]
    public void CmdSpawnEquipment(GameObject equipment, Vector3 pos)
    {
        GameObject eq = Instantiate(equipment, pos, Quaternion.identity);
        NetworkServer.Spawn(eq);
    }
}
