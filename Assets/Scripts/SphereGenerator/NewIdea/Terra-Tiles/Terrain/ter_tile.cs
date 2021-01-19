using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ter_tile : MonoBehaviour
{
    public float height;
    bool water;
    TerrainTypes type;

    public bool IsLand()
    {
        if (type == TerrainTypes.land)
            return true;
        else
            return false;
    }
    public bool IsWater()
    {
        if (type == TerrainTypes.water)
            return true;
        return false;
    }
    public bool IsCoast()
    {
        if (type == TerrainTypes.coast)
            return true;
        return false;
    }
}
