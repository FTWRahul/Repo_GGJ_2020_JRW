using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{

    public List<GameObject> Head;
    public List<GameObject> Weapon;
    public List<GameObject> Feet;
    public int currentHead;
    public int currentWeapon;
    public int currentFeet;

    void EquipCorrect(bodyComponent component, int newID)
    {
        
       
        switch (component)
        {
            case bodyComponent.HEAD:
                Head[currentHead].SetActive(false);
                //drop server side
                currentHead = newID;
                Head[newID].SetActive(true);
                //equip server side

                break;
            case bodyComponent.WEAPON:
                Weapon[currentWeapon].SetActive(false);
                //drop server side
                currentWeapon = newID;
                Weapon[newID].SetActive(true);
                //equip server side

                break;
            case bodyComponent.FEET:
                Feet[currentFeet].SetActive(false);
                //drop server side
                currentFeet = newID;
                Feet[newID].SetActive(true);
                //equip server side

                break;

        }


    }


}
