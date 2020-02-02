using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class Projectile : NetworkBehaviour
{
    public float damageRange;
    public float force;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.AddForce(Vector3.forward * force, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision other)
    {
       //TODO: 
       CmdCheckForPlayer();
       //Destroy
    }

    [Command]
    private void CmdCheckForPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, damageRange);
        
        PlayerController player = colliders.Where(x => x.tag == " Player ").First().GetComponent<PlayerController>();
        if (player)
        {
            //TODO:: deal damage
        }
    }
}
