using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tape : MonoBehaviour
{
    public Vector2 minMaxHeight;
    public float movementSpeed;
    private List<GameObject> _tapePieces;
    public GameObject tapePrefab;

    public float timeBeforeLastTape;
    public static bool shouldDropTape;
    public Vector3 spawnPoint;
    
    private void Update()
    {
        var pos = transform.position;
        pos.y = Mathf.Clamp(transform.position.y, minMaxHeight.x, minMaxHeight.y);
        transform.position = pos;
        
        transform.Translate(0, Input.GetAxis("Mouse Y") * movementSpeed * Time.deltaTime, 0);

        if (Input.GetKey(KeyCode.Mouse0))
        {
            DropPiece();
        }
    }

    public void DropPiece()
    {
        if (!shouldDropTape)
        {
            return;
        }
        GameObject go = Instantiate(tapePrefab, spawnPoint, Quaternion.identity);
        
    }
}
