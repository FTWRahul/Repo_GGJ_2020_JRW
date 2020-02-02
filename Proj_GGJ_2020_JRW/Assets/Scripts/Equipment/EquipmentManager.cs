using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public Vector3 playerPos;
    public List<GameObject> Head;
    public List<GameObject> Weapon;
    public List<GameObject> Feet;
    public int currentHead;
    public int currentWeapon;
    public int currentFeet;
    
    private ServerEquipment _serverEquips;
    public int[] aEquipment = { 0, 0, 0 };
    
    private void Start()
    {
        _serverEquips = FindObjectOfType<ServerEquipment>();
    }
    
    public void EquipCorrect(bodyComponent componentType, int newID, GameObject component)
    {
        
        //Server destroy spawned object
        _serverEquips.CmdServerDestroy(component);
        

        switch (componentType)
        {
            case bodyComponent.HEAD:
                Head[currentHead].SetActive(false);
                //drop server side
                /*ServerEquips.Equip(bodyComponent.HEAD, newID);*/
                currentHead = newID;
                aEquipment[0] = newID;
                Head[newID-1].SetActive(true);
                //equip server side

                break;
            case bodyComponent.WEAPON:
                Weapon[currentWeapon].SetActive(false);
                //drop server side
                /*ServerEquips.Equip(bodyComponent.WEAPON, newID);*/
                currentWeapon = newID;
                aEquipment[1] = newID;
                Weapon[newID-1].SetActive(true);
                //equip server side

                break;
            case bodyComponent.FEET:
                Feet[currentFeet].SetActive(false);
                //drop server side
                /*ServerEquips.Equip(bodyComponent.FEET, newID);*/
                currentFeet = newID;
                aEquipment[2] = newID;
                Feet[newID-1].SetActive(true);
                //equip server side

                break;
        }
    }
    public void DropAll()
    {
        //random drop

        //systematically unequip each piece of equipment

        //dunno what you're goign to do for server equipment to make it work

        _serverEquips.Unequip(bodyComponent.HEAD, currentHead, playerPos);
        currentHead = 0;
        _serverEquips.Unequip(bodyComponent.FEET, currentFeet, playerPos);
        currentFeet = 0;
        _serverEquips.Unequip(bodyComponent.WEAPON, currentWeapon, playerPos);
        currentWeapon = 0;
    }
    public void DopRandom()
    {
        int rEquip = Random.Range(0, aEquipment.Length -1);
        while(aEquipment[rEquip] == 0)
        {
            rEquip = Random.Range(0, aEquipment.Length - 1);
        }
        bodyComponent[] aComponents = { bodyComponent.HEAD, bodyComponent.WEAPON, bodyComponent.FEET };

        //List<bodyComponent> equipment = new List<bodyComponent>();
        //if (currentHead != 0)
        //{
        //    equipment.Add(bodyComponent.HEAD);
        //}
        //if (currentWeapon != 0)
        //{
        //    equipment.Add(bodyComponent.WEAPON);
        //}
        //if (currentFeet != 0)
        //{
        //    equipment.Add(bodyComponent.FEET);
        //}


        _serverEquips.Unequip(aComponents[rEquip] , aEquipment[rEquip], playerPos);
        aEquipment[rEquip] = 0;
    }

}
