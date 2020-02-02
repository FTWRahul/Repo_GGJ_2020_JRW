using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SuccGun : NetworkBehaviour, IGunInterface
{
    private void Start()
    {
        
    }


    //Todo 
    //add animation controller reference
    public AudioClip fireSound;
    public float succTime = 0;
    public float succThreshold = 5f;
    public bool Reloading = false;
    public float succLength = 2;


    // Update is called once per frame
    void Update()
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
                succTime += Time.deltaTime;
                Fire();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                //if you stop chargining reset charging variable
                succTime = 0;
            }
        }

    }
    IEnumerator reloadDelay()
    {
        yield return new WaitForSeconds(1);
        Reloading = false;
        //laserLine.SetPosition(1, transform.position);
        yield break;

    }
    public void Fire()
    {
        if (succTime > succThreshold)
        {
            succLength = 2;
            Reloading = true;
            reloadDelay();
            return;
        }
        CmdRay((transform.forward.normalized * succLength), (succLength));

    }



    [Command]
    public void CmdRay(Vector3 center, float radius)
    {

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);
        int i = 0;
        while (i < hitColliders.Length)
        {
            if (hitColliders[i].CompareTag("Player"))
            {
                //ToDo apply damage
            }
            i++;
        }
        if (succTime < 2f)
        {

            succLength += Time.deltaTime;
        }



  
    }
}
