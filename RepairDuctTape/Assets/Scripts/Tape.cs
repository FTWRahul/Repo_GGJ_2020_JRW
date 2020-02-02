using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tape : MonoBehaviour
{
    private Vector2 minMaxHeight;

    private void Awake()
    {
        throw new NotImplementedException();
    }

    private void Update()
    {
        var pos = transform.position;
        pos.y = Mathf.Clamp(transform.position.y, minMaxHeight.x, minMaxHeight.y);
        transform.position = pos;
    }
}
