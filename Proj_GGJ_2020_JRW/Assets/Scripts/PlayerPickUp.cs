using System;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    public float pickupRange;
    public float timeToCollect;
    public LayerMask pickupLayerMask;
    
    
    /*public delegate void OnPickUpDelegate();
    public event OnPickUpDelegate OnPickUpEvent = delegate { };*/
    private float _holdTime; 
    
    private PlayerAim _playerAim;
    private Camera _camera;
    private Equipment _toCollect;

    private void Start()
    {
        _playerAim = GetComponent<PlayerAim>();
        _camera = Camera.main;
    }

    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(_playerAim.aim);

        if (Physics.Raycast(ray, out RaycastHit hit, pickupRange, pickupLayerMask))
        {
            _toCollect = hit.collider.GetComponent<Equipment>();
        }
        else
        {
            _toCollect = null;
        }

        if (Input.GetKey(KeyCode.E) && _toCollect)
        {
            _holdTime += Time.deltaTime;

            if (_holdTime >= timeToCollect)
            {
                //TODO:: Collect
            }
        }
        else
        {
            _holdTime = 0;
        }
    }
}

public class PlayerAim : MonoBehaviour
{
    public Vector3 aim;
    private Camera _camera;
    
    
}
