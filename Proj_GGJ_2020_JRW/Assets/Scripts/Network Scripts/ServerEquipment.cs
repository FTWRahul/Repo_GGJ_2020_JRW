using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerEquipment : MonoBehaviour
{

    public List<GameObject> PHead;
    public List<GameObject> PWeapon;
    public List<GameObject> PFeet;

    public void equip(bodyComponent component, int newID)
    {
        switch (component)
        {
            case bodyComponent.HEAD:
                PHead[newID].SetActive(false);
                break;
            case bodyComponent.WEAPON:
                PWeapon[newID].SetActive(false);
                break;
            case bodyComponent.FEET:
                PFeet[newID].SetActive(false);
                break;

        }


    }

    public void unEquip(bodyComponent component, int newID, Transform DropLocation)
    {
        switch (component)
        {
            case bodyComponent.HEAD:
                PHead[newID].transform.position = DropLocation.position;
                PHead[newID].SetActive(true);
                break;
            case bodyComponent.WEAPON:
                PWeapon[newID].transform.position = DropLocation.position;
                PWeapon[newID].SetActive(true);
                break;
            case bodyComponent.FEET:
                PFeet[newID].transform.position = DropLocation.position;
                PFeet[newID].SetActive(true);
                break;

        }
        gameObject.transform.localPosition = Spawn.position;
        gameObject.SetActive(true);

    }

}
