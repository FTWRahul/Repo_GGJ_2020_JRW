using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectRotater : MonoBehaviour
{
    public List<GameObject> itemsToSpawn;
    public float speed;

    public static  GameObject _currentObj;

    private void Awake()
    {
        int rand = Random.Range(0, itemsToSpawn.Count);
        _currentObj = Instantiate(itemsToSpawn[rand]);
        _currentObj.transform.parent = this.transform;
    }

    private void Update()
    {
        float x = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float y = -Input.GetAxis("Horizontal")* speed * Time.deltaTime;
        
        RotateObj(x,y);
    }

    public void RotateObj(float x, float y)
    {
        _currentObj.transform.Rotate(x, y, 0, Space.World);
    }
}
