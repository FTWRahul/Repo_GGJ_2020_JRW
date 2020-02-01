using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BabyLazer : NetworkBehaviour, IGunInterface
{

    //Todo 
    //add animation controller reference
    public AudioClip fireSound;
    public float chargeTime =0;
    public float fireThreshold = 1f;
    public bool Reloading = false;



    private void Update()
    {
        if (!isLocalPlayer)
        {
            //not local
            return;
        }
        if (Reloading != true)
        {

            if (Input.GetKey(KeyCode.Mouse0))
            {
                //charge the laser, then check if its charged
                chargeTime += Time.deltaTime;
                fire();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //if you stop chargining reset charging variable
                chargeTime = 0;
            }
        }
       
    }

    public void fire()
    {
       
        if (chargeTime> fireThreshold)
        {
            //if charged fire it
            CmdRay();
            chargeTime = 0;
            Reloading = true;
            StartCoroutine(reloadDelay());
        }
        else
        {
            //do nothing
            return;
        }
  


    }

    IEnumerator reloadDelay()
    {
        yield return new WaitForSeconds(1);
        Reloading = false;
        //laserLine.SetPosition(1, transform.position);
        yield break;

    }

    [Command]
    public void CmdRay()
    {
        //hitscan gun, raycast if it hits an enemy deal damage
        RaycastHit hit;
        //LayerMask.GetMask("Player")
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Player"))
            {
                //dedbug ray
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
                //deal damage

            }


        }
    }

}
