using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType
{
    Land,
    Water,
    Coast,
}
public enum LifeObjectTypes
{
    Flower, Pigs, Cows, Fox, Eagle, Dove, Tree, Bees, Locust, Wheat

}

public enum ResourceTypes
{
    Oxygen,
    CarbonDioxide,
}

[System.Serializable]
public class LifeObjectSource
{
    public LifeObjectTypes type;
    public float growthSpread;
    public float growthSpreadNeeded;
    public float growth;
    public float growthGained;
    public float growthLost;
    public bool waterType;
    public bool foliaged;

    public List<Consumeables> consumables;
    public List<ResourceAmount> producables;
}

[System.Serializable]
public class FoliageStats
{
    public LifeObjectTypes lifeType;
    public float maxGrowth;
    public List<GameObject> foliagePrefabs;
    public int prefabAmount;
    public float heightOffGround;
}

[System.Serializable]
public class LifeObjectAmount
{
    public LifeObjectTypes lifeType;
    public float amount;
    public void Copy(LifeObjectAmount l)
    {
        lifeType = l.lifeType;
        amount = l.amount;
    }

}

[System.Serializable]
public class ResourceAmount
{
    public ResourceTypes resourceType;
    public int amount;
    public void Copy(ResourceAmount r)
    {
        resourceType = r.resourceType;
        amount = r.amount;
    }
}

[System.Serializable]
public class Consumeables
{
    public bool resource;
    public bool done;
    public int tileID;
    public ResourceAmount resources;
    public List<LifeObjectAmount> lifeObjects;
    public void Copy(Consumeables c)
    {
        resource = c.resource;
        if (resource)
        {
            resources = new ResourceAmount();
            resources.Copy(c.resources);
        }
        else
        {
            lifeObjects = new List<LifeObjectAmount>();
            for(int i = 0; i < c.lifeObjects.Count;i++)
            {
                LifeObjectAmount lo = new LifeObjectAmount();
                lo.Copy(c.lifeObjects[i]);
                lifeObjects.Add(lo);
            }
        }

    }
}
public class TerraEnums
{

}
