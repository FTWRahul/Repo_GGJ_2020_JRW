using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LaunchingGun : NetworkBehaviour
{
    public int projectileAmount;
    public GameObject projectile;
    public Transform shotPoint;
    
    public float shotForce; // force??
    public float reloadTime;
    
    private bool _canAttack = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_canAttack)
            {
                CmdSpawnProjectile();
                StartCoroutine(Reload());
            }
        }
    }

    [Command]
    private void CmdSpawnProjectile()
    {
        Instantiate(projectile, shotPoint.position, Quaternion.identity);
    }

    IEnumerator Reload()
    {
        _canAttack = false;
        yield return new WaitForSeconds(reloadTime);
        _canAttack = true;
    }
}
