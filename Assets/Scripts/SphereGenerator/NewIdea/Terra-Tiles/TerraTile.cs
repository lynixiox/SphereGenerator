using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraTile : MonoBehaviour
{
    //tile info
    public int ID;
    public List<int> connectedTiles;

    //terra info
    public List<ResourceAmount> resources;
    public List<LifeObject> lifeObjects;
    List<LifeObject> removeList;
    
    public bool test;
    public float height;
    public bool water;
    public Material material;
    private void Start()
    {
        removeList = new List<LifeObject>();
        lifeObjects = new List<LifeObject>();
        material = this.gameObject.GetComponent<Renderer>().material;
       // resources = new List<ResourceAmount>();
    }
    private void Update()
    {
        if (test)
        {
          //  Debug.Log("testttt");
            test = false;
            AddLifeObject(LifeObjectManager.Instance.ReturnSource(LifeObjectTypes.Flower));
        }
    }
    public void UpdateTick()
    {
        foreach(LifeObject l in lifeObjects)
        {
            l.UpdateTick();
        }
        foreach(LifeObject l in removeList)
        {
            lifeObjects.Remove(l);
        }
        removeList.Clear();
    }
    public void SetupTerraTile(SoloTile tile)
    {
        connectedTiles = tile.connectedTiles;
        ID = tile.ID;
        height = tile.height;
    }
    public void AddResource(ResourceAmount res)
    {
        bool alreadyInList = false;
        for(int i = 0; i < resources.Count;i++)
        {
            if (resources[i].resourceType == res.resourceType)
            {
                alreadyInList = true;
                resources[i].amount += res.amount;
                if (resources[i].amount > 50)
                    resources[i].amount = 50;
            }
        }
        if(!alreadyInList)
        {
            ResourceAmount newAmount = new ResourceAmount();
            newAmount.resourceType = res.resourceType;
            newAmount.amount = res.amount;
            resources.Add(newAmount);
        }
    }


    public bool AddLifeObject(LifeObject lo)
    {
        if (lifeObjects.Count >= 3)
            return false;
        if (lo.landType != water)
            return false;
        for(int i = 0; i < lifeObjects.Count;i++)
        {
            if (lifeObjects[i].type == lo.type)
                return false;
        }
        LifeObject newLife = new LifeObject();
        newLife.Copy(lo);
        newLife.SetupLifeObject(this);
        newLife.ChangeGrowth(0);
        lifeObjects.Add(newLife);
        return true;
    }
    public bool AddLifeObject(LifeObjectSource lo)
    {
        if (lifeObjects.Count >= 3)
            return false;
        if (lo.waterType != water)
            return false;
        for (int i = 0; i < lifeObjects.Count; i++)
        {
            if (lifeObjects[i].type == lo.type)
                return false;
        }
        Debug.Log(lo.type + ":Type");
        LifeObject newLife = new LifeObject();
        newLife.Copy(lo);
        newLife.SetupLifeObject(this);
        lifeObjects.Add(newLife);
        return true;
    }

    public void RemoveLifeObject(LifeObject lo)
    {
        removeList.Add(lo);
    }
    ///////////////////CHECK AND TAKE FOR SHIT/////////////////
    public bool CheckResource(ResourceAmount res)
    {

        for(int i = 0; i<resources.Count;i++)
        {
            if (resources[i].resourceType == res.resourceType)
            {
                if (resources[i].amount >= res.amount)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public bool HasLifeObject(LifeObject lo)
    {

        for(int i = 0; i < lifeObjects.Count;i++)
        {
            if (lifeObjects[i].type == lo.type)
                return true;
        }
        return false;
    }
    public bool HasLifeObject(List<LifeObject> lo)
    {
        for(int i = 0; i < lo.Count;i++)
        {
            bool temp = false;
            for(int o = 0; o < lifeObjects.Count;o++)
            {
                if (lo[i].type == lifeObjects[o].type)
                    temp = true;
            }
            if (!temp)
                return false;

        }
        return true;
    }
    public bool HasLifeObject(LifeObjectAmount lo)
    {

        for (int i = 0; i < lifeObjects.Count; i++)
        {
            if (lifeObjects[i].type == lo.lifeType)
                if (lifeObjects[i].growth >= lo.amount)
                {
                    return true;
                }
        }
        return false;
    }
    public bool HasLifeObject(List<LifeObjectAmount> lo)
    {

        for (int i = 0; i < lo.Count; i++)
        {
            for (int o = 0; o < lifeObjects.Count; o++)
            {
                if (lo[i].lifeType == lifeObjects[o].type)
                    if (lifeObjects[o].growth >= lo[i].amount)
                    {
                        return true;
                    }
            }
        }
        return false;

    }
    public void TakeResources(ResourceAmount res)
    {
        for (int i = 0; i < resources.Count; i++)
        {
            if (resources[i].resourceType == res.resourceType)
            {
                resources[i].amount -= res.amount;
                if (resources[i].amount > 50)
                    resources[i].amount = 50;
            }
        }
    }
    public void TakeLifeObject(LifeObjectAmount lo)
    {

        for (int i = 0; i < lifeObjects.Count; i++)
        {
            if (lifeObjects[i].type == lo.lifeType)
                if (lifeObjects[i].growth >= lo.amount)
                {
                    lifeObjects[i].ChangeGrowth(-lo.amount);
                    return;
                }
        }
    }
    public void TakeLifeObject(List<LifeObjectAmount> lo)
    {

        for (int i = 0; i < lo.Count; i++)
        {
            for (int o = 0; o < lifeObjects.Count; o++)
            {
                if (lo[i].lifeType == lifeObjects[o].type)
                    if (lifeObjects[o].growth >= lo[i].amount)
                    {
                        lifeObjects[o].ChangeGrowth(-lo[i].amount);
                        return;
                    }
            }
        }

    }


    //public bool Check
}
