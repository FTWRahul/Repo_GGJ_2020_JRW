using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type
{
    FEET,
    WEAPON,
    HEAD,
}
public class Equipment : MonoBehaviour
{
    public Type type;
    public int id;
}
