﻿using System;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float speed;
    public float forwardMultiplier;
    public float backwardMultiplier;
    public float jumpForce;
    public float jumpMultiplier;
    public float gravity;
    public float rayLength;

    private float _verticalSpeed;
    
    private CharacterController _characterController;
    private PlayerAnimationController _playerAnimation;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimation = GetComponent<PlayerAnimationController>();
    }

    void Update()
    {
        if (hasAuthority)
        {
            Vector3 normalizedDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            if (normalizedDir.z < 0)
            {
                normalizedDir.z *=  speed * backwardMultiplier;
            }
            else
            {
                normalizedDir.z *= speed * forwardMultiplier;
            }

            Vector3 dir = normalizedDir * Time.deltaTime;
            dir = transform.rotation * normalizedDir;

            if (_characterController.isGrounded && Input.GetButtonDown("Jump")) //In case Revert to -Vector3.up//  && Physics.Raycast(transform.position, -Vector3.up, rayLength)
            {
                _verticalSpeed = jumpForce * jumpMultiplier;
            }
            else if (!_characterController.isGrounded)
            {
                _verticalSpeed -= gravity * Time.deltaTime;
            }

            dir.y = _verticalSpeed;
            _characterController.Move(dir);
        }
    }

    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        Debug.Log("Ya boi gots Authority! On the controller!");
    }
}
