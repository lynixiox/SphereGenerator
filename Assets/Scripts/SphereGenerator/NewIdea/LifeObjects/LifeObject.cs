using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LifeObject
{
    public TerraTile parent;

    public LifeObjectTypes type;
    public float growthSpread;
    public float growthSpreadNeeded;
    public float growth;
    public float growthGained;
    public float growthLost;
    public bool landType;
    public List<Consumeables> consumables;
    public List<ResourceAmount> producables;

    public FoliageCreator foliageCreator;
    public bool foliaged;

    public void SetupLifeObject(TerraTile tile)
    {
        parent = tile;
        if(foliaged)
        {
            foliageCreator = parent.gameObject.AddComponent<FoliageCreator>();
            foliageCreator.Setup(type);
            foliageCreator.ChangeGrowth(growth);
        }
    }

    public void UpdateTick()
    {
        Consume();
    }
    public void Copy(LifeObject lo)
    {
        type = lo.type;
        landType = lo.landType;
        growthSpread = lo.growthSpread;
        growthSpreadNeeded = lo.growthSpreadNeeded;
        growth = growthSpread;
        growthLost = lo.growthLost;
        growthGained = lo.growthGained;
        foliaged = lo.foliaged;
        consumables = new List<Consumeables>();
        for(int i = 0; i < lo.consumables.Count;i++)
        {
            Consumeables co = new Consumeables();
            co.Copy(lo.consumables[i]);
            consumables.Add(co);
        }
        producables = new List<ResourceAmount>();
        for(int i = 0; i < lo.producables.Count;i++)
        {
            ResourceAmount pr = new ResourceAmount();
            pr.Copy(lo.producables[i]);
            producables.Add(pr);
        }
    }
    public void Copy(LifeObjectSource lo)
    {
        type = lo.type;
        growthSpread = lo.growthSpread;
        growthSpreadNeeded = lo.growthSpreadNeeded;
        growth = lo.growth;
        growthLost = lo.growthLost;
        growthGained = lo.growthGained;
        foliaged = lo.foliaged;


        consumables = new List<Consumeables>();
        for (int i = 0; i < lo.consumables.Count; i++)
        {
            Consumeables co = new Consumeables();
            co.Copy(lo.consumables[i]);
            consumables.Add(co);
        }
        producables = new List<ResourceAmount>();
        for (int i = 0; i < lo.producables.Count; i++)
        {
            ResourceAmount pr = new ResourceAmount();
            pr.Copy(lo.producables[i]);
            producables.Add(pr);
        }
    }
    public void ChangeGrowth(float g)
    {
        growth += g;
        if (growth > 1.0f)
            growth = 1.0f;
        if (growth < 0.0f)
        {
            Die();
            return;
        }
        if(foliaged)
        {
            foliageCreator.ChangeGrowth(growth);
        }
        
    }
    public void Consume()
    {
        //check can consume
        for (int i = 0; i < consumables.Count;i++) 
        {
            consumables[i].done = false;
            if(consumables[i].resource)
            {
                //check same Tile
                if (parent.CheckResource(consumables[i].resources))
                {
                    consumables[i].done = true;
                    consumables[i].tileID = parent.ID;
                }
                //check neighbouring tiles
                else
                {
                    for(int o = 0; o < parent.connectedTiles.Count;o++)
                    {
                        if(TerraManager.instance.terraTiles[parent.connectedTiles[o]].CheckResource(consumables[i].resources))
                        {
                            consumables[i].done = true;
                            consumables[i].tileID = parent.connectedTiles[o];
                            break;
                        }
                    }
                }

            }
            else
            {
                if(parent.HasLifeObject(consumables[i].lifeObjects))
                {
                    consumables[i].done = true;
                    consumables[i].tileID = parent.ID;
                }
                else
                {
                    for(int o = 0; o < parent.connectedTiles.Count;o++)
                    {
                        if(TerraManager.instance.terraTiles[parent.connectedTiles[o]].HasLifeObject(consumables[i].lifeObjects))
                        {
                            consumables[i].done = true;
                            consumables[i].tileID = parent.connectedTiles[o];
                            break;
                        }
                    }
                }
            }
        }
        bool mustEat = false;
        bool tempEatCheck = false;
        for(int i = 0; i < consumables.Count;i++)
        {
            if(!consumables[i].done && consumables[i].resource)
            {
                DieABit();
                return;
            }
            if(!consumables[i].resource)
            {
                mustEat = true;
                if (consumables[i].done)
                    tempEatCheck = true;
            }

        }
        if(mustEat && !tempEatCheck)
        {
            DieABit();
            return;
        }

        //actually consume
        for(int i = 0; i < consumables.Count;i++)
        {
            if(consumables[i].resource)
            {
                TerraManager.instance.terraTiles[consumables[i].tileID].TakeResources(consumables[i].resources);
            }
            else if(consumables[i].done)
            {
                TerraManager.instance.terraTiles[consumables[i].tileID].TakeLifeObject(consumables[i].lifeObjects);
            }
        }
        Grow();
        Produce();

    }
    public void Grow()
    {
        ChangeGrowth(growthGained);
        if(growth >= growthSpreadNeeded)
        {
            //spread
            Spread();
        }
    }
    public void DieABit()
    {
        ChangeGrowth(-growthLost);
        if(growth <= 0.0f)
        {
            Die();
        }
    }
    public void Produce()
    {
        for(int i = 0; i < producables.Count;i++)
        {
            parent.AddResource(producables[i]);
        }
    }
    public void Spread()
    {
        for(int i = 0; i < parent.connectedTiles.Count;i++)
        {
            if(TerraManager.instance.terraTiles[parent.connectedTiles[i]].AddLifeObject(this))
            {
                break;
            }
        }
    }
    public void Die()
    {

        if (foliaged)
            foliageCreator.Die();



        parent.RemoveLifeObject(this);
    }

}
