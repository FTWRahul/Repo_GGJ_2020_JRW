using System;
using System.Collections;
using UnityEngine;

public class CatApult : MonoBehaviour
{
    public GameObject catProjectile;
    public Transform shotPoint;

    public float reloadTime;
    
    private bool _canAttack = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_canAttack)
            {
                Instantiate(catProjectile, shotPoint.position, Quaternion.identity);
                
                StartCoroutine(Reload());
            }
        }
    }

    IEnumerator Reload()
    {
        _canAttack = false;
        yield return new WaitForSeconds(reloadTime);
        _canAttack = true;
    }
}
