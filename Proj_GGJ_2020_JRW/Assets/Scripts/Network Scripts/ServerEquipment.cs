using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerEquipment : MonoBehaviour
{

    public List<GameObject> PHead;
    public List<GameObject> PWeapon;
    public List<GameObject> PFeet;

    public void Equip(bodyComponent Component, int newID)
    {
        switch (Component)
        {
            case bodyComponent.HEAD:
                PHead[newID-1].SetActive(false);
                break;
            case bodyComponent.WEAPON:
                PWeapon[newID-1].SetActive(false);
                break;
            case bodyComponent.FEET:
                PFeet[newID-1].SetActive(false);
                break;

        }
    }

    public void Unequip(bodyComponent Component, int newID, Vector3 DropLocation)
    {
        switch (Component)
        {
            case bodyComponent.HEAD:
                PHead[newID-1].transform.position = DropLocation;
                PHead[newID-1].SetActive(true);
                break;
            case bodyComponent.WEAPON:
                PWeapon[newID-1].transform.position = DropLocation;
                PWeapon[newID-1].SetActive(true);
                break;
            case bodyComponent.FEET:
                PFeet[newID-1].transform.position = DropLocation;
                PFeet[newID-1].SetActive(true);
                break;

        }

    }

}
