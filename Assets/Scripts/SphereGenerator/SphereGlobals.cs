using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGlobals 
{
   
}
public class _hexagon
{
    public Vector3[] index;      // index of 6 points, last point duplicate for pentagon
    public int a, b;        // spherical coordinate

    public _hexagon()
    {
        index = new Vector3[6];
    }
}
