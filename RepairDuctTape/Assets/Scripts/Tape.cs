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
    public static bool stopTape;
    public Vector3 spawnPoint;

    public GameObject endPoint;
    public GameObject startPoint;
    
    private void Update()
    {
        if (stopTape)
        {
            return;
        }
        var pos = startPoint.transform.position;
        pos.y = Mathf.Clamp(startPoint.transform.position.y, minMaxHeight.x, minMaxHeight.y);
        startPoint.transform.position = pos;
        
        startPoint.transform.Translate(0, Input.GetAxis("Mouse Y") * movementSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stopTape = true;
        }
        DropPiece();
    }

    public void DropPiece()
    {
        if (!stopTape)
        {
            return;
        }

        startPoint.transform.parent = endPoint.transform.parent;
        startPoint.transform.localPosition = endPoint.transform.localPosition;

    }
}
