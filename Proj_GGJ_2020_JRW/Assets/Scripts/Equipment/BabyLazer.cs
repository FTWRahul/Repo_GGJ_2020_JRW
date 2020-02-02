using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BabyLazer : NetworkBehaviour
{

    //Todo 
    //add animation controller reference
    public AudioClip fireSound;
    public float chargeTime = 0;
    public float fireThreshold = 1f;
    public bool reloading = false;



    private void Update()
    {
        if (!isLocalPlayer)
        {
            //not local
            return;
        }
        if (reloading != true)
        {

            if (Input.GetKey(KeyCode.Mouse0))
            {
                //charge the laser, then check if its charged
                chargeTime += Time.deltaTime;
                Fire();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //if you stop chargining reset charging variable
                chargeTime = 0;
            }
        }
    }

    private void Fire()
    {

        if (chargeTime > fireThreshold)
        {
            //if charged fire it
            CmdRay();
            chargeTime = 0;
            reloading = true;
            StartCoroutine(ReloadDelay());
        }
        else
        {
            //do nothing
            return;
        }
        
    }

    IEnumerator ReloadDelay()
    {
        yield return new WaitForSeconds(1);
        reloading = false;
        //laserLine.SetPosition(1, transform.position);
        yield break;

    }

    [Command]
    private void CmdRay()
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