using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraManager : MonoBehaviour
{
    public static TerraManager instance;

    public float updateTick;
    float nextUpdate;
    public List<TerraTile> terraTiles;
    public List<SoloTile> soloTiles;
    public bool firstUpdate = true;

    public List<Material> materials;
    private void Start()
    {
        instance = this;
        nextUpdate = Time.time + updateTick;
    }
    private void Update()
    {
        if(Time.time >= nextUpdate)
        {
            
            nextUpdate = Time.time + updateTick;
            UpdateTerraTiles();
        }
    }
    public void AddTile(GameObject tile)
    {
        soloTiles.Add(tile.GetComponent<SoloTile>());
        
        TerraTile nTerra = tile.GetComponent<TerraTile>();
        nTerra.SetupTerraTile(tile.GetComponent<SoloTile>());
        if (nTerra.height <= 1000)
        {
            tile.GetComponent<Renderer>().material = materials[0];
            nTerra.water = true;
        }
        else if (nTerra.height <= 1300)
        {
            tile.GetComponent<Renderer>().material = materials[1];
            nTerra.water = false;

        }
        else

        { 
            tile.GetComponent<Renderer>().material = materials[2];
        
            nTerra.water = false;

        }
        terraTiles.Add(nTerra);  
        
    }
    public void UpdateTerraTiles()
    {
        if(firstUpdate)
        {
            firstUpdate = false;
            //terraTiles[0].test = true;
        }
        foreach(TerraTile t in terraTiles)
        {
            t.UpdateTick();
        }
    }

}
