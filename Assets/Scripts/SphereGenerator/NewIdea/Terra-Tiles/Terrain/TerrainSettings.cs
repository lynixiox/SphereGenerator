using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TerrainSettings
{
    /// <summary>
    /// User settings
    /// </summary>
    public int seed;
    public int gridSize;
    public int iterations; //better world
    [Range(0.0000f, 1.0f)]
    public double waterRatio;
    /// <summary>
    /// Planetery Settings
    /// </summary>
    public Vector3 axis = new Vector3();
    public double axial_tilt;
    public double radius = 40000000;
    public double sea_level;


    public void GenerateRandomSeed()
    {
        int rSeed = 0;
        
        rSeed = Random.Range(10000000, 99999999);
        seed = rSeed;
    }
}

