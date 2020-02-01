using System;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public float forwardSpeed;
    public float backwardSpeed;
    public float jumpForce;
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
        if (isLocalPlayer)
        {
            Vector3 normalizedDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            if (normalizedDir.z < 0)
            {
                normalizedDir.z *= backwardSpeed;
            }
            else
            {
                normalizedDir.z *= forwardSpeed;
            }

            Vector3 dir = normalizedDir * Time.deltaTime;
            dir = transform.rotation * normalizedDir;

            if (_characterController.isGrounded && Input.GetButtonDown("Jump") && Physics.Raycast(transform.position, Vector3.down, rayLength)) //In case Revert to -Vector3.up//
            {
                _verticalSpeed = jumpForce;
            }
            else if (!_characterController.isGrounded)
            {
                _verticalSpeed -= gravity * Time.deltaTime;
            }

            dir.y = _verticalSpeed;
            _characterController.Move(normalizedDir);
        }
    }
}
