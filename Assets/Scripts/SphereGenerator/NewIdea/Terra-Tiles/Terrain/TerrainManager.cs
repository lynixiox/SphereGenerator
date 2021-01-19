using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public static TerrainManager Instance;
    public TerrainSettings tSettings;
    public TerrainCreation tCreation;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        tSettings.GenerateRandomSeed();
        tCreation = new TerrainCreation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
