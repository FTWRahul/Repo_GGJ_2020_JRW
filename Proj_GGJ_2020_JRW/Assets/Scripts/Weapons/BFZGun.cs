using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class BFZGun : NetworkBehaviour, IGunInterface
{
    //Todo 
    //add animation controller reference
    public AudioClip fireSound;
    public float chargeTime = 0;
    public float fireThreshold = 1.5f;
    private void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            chargeTime *= Time.deltaTime;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            chargeTime = 0;
        }
    }

    public void fire()
    {
        if (!isLocalPlayer)
        {
            //not local
            return;
        }
        if (chargeTime > fireThreshold)
        {
            //if charged fire it
            CmdRay();
            chargeTime = 0;
        }
        else
        {
            //do nothing
            return;
        }



    }

    [Command]
    public void CmdRay()
    {
        //hitscan gun, raycast if it hits an enemy deal damage
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, LayerMask.GetMask("Player")))
        {

            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            //deal damage

        }
    }
}
