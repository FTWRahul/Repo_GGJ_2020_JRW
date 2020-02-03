using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectRotater : MonoBehaviour
{
    public List<GameObject> itemsToSpawn;
    public float speed;
    public GameObject backEndRope;

    public static  GameObject _currentObj;

    private void Start()
    {
        int rand = Random.Range(0, itemsToSpawn.Count);
        _currentObj = Instantiate(itemsToSpawn[rand]);
        _currentObj.transform.parent = this.transform;
        FindObjectOfType<Tape>().endPoint.transform.position = _currentObj.transform.position + new Vector3(0, 0, -.05f);
        FindObjectOfType<Tape>().endPoint.transform.parent = _currentObj.transform;
//        backEndRope.transform.position = _currentObj.transform.position;
//        backEndRope.transform.parent = _currentObj.transform;
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
