using System;
using UnityEngine;

public class Boots : MonoBehaviour
{
    public float forwardMultiplier;
    public float backwardMultiplier;
    public float jumpMultiplier;
    
    private PlayerController _playerController;
    
    private void Start()
    {
        _playerController = GetComponentInParent<PlayerController>();
        
        _playerController.forwardMultiplier = forwardMultiplier;
        _playerController.backwardMultiplier = backwardMultiplier;
        _playerController.jumpMultiplier = jumpMultiplier;
    }

    private void OnDisable()
    {
        _playerController.forwardMultiplier = 1;
        _playerController.backwardMultiplier = 1;
        _playerController.jumpMultiplier = 1;
    }
}
