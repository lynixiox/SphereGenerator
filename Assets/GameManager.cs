using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TerraTile selectedTile;
    
    public float totalOxygen;
    public float totalCo2;
    public float ecoSystemHealth;
    public int lifeVariety;
    public float uiTick;
    public float totalLife;

    float nextTick = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void Create(LifeObjectTypes type)
    {

        //comment//
        Debug.Log("Spawning a mother fucking" + type);
        selectedTile.AddLifeObject(LifeObjectManager.Instance.ReturnSource(type));
        if (type == LifeObjectTypes.Tree || type == LifeObjectTypes.Wheat)
        {
            ResourceAmount newR = new ResourceAmount();
            newR.resourceType = ResourceTypes.CarbonDioxide;
            if (type == LifeObjectTypes.Tree)
                newR.amount = 40;
            else
                newR.amount = 10;
            selectedTile.AddResource(newR);
            if (type == LifeObjectTypes.Tree)
                newR.amount = 20;
            else
                newR.amount = 5;
            foreach(int t in selectedTile.connectedTiles)
            {
                TerraManager.instance.terraTiles[t].AddResource(newR);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
      if(Time.time >= nextTick)
        {
            nextTick = Time.time + uiTick;
            UITick();
        }
    }

    void UITick()
    {
        GetGasses();
    }
    void CalculateHealth(float oxygen, float c02)
    {
        totalCo2 = c02;
        totalOxygen = oxygen;
        totalLife = (totalOxygen + totalCo2) / 100;
    }

    public void GetlifeObjects()
    {
        lifeVariety = 0;
        float tempAnimals = 0;
        float tempTrees = 0;
        List<LifeObjectTypes> Types = new List<LifeObjectTypes>(); 
        foreach(TerraTile t in TerraManager.instance.terraTiles)
        {
            foreach(LifeObject l in t.lifeObjects)
            {
                if(!Types.Contains(l.type))
                {
                    Types.Add(l.type);
                    lifeVariety++;
                }
                if(l.type == LifeObjectTypes.Tree)
                {
                    tempTrees += 1;
                }
                if (l.type == LifeObjectTypes.Cows || l.type == LifeObjectTypes.Pigs || l.type == LifeObjectTypes.Fox || l.type == LifeObjectTypes.Dove)
                {
                    tempAnimals += 1;
                }
            }
            CalculateCanopy();
            //commenting//
        }
    }


    void CalculateCanopy()
    {

    }

    public void GetGasses()
    {
        float tempO2 = 0;
        float tempCO2 = 0;
        foreach(TerraTile t in TerraManager.instance.terraTiles)
        {
            foreach(ResourceAmount r in t.resources)
            {
                if(r.resourceType == ResourceTypes.Oxygen)
                {
                    tempO2 += r.amount;
                   
                }
                else if(r.resourceType == ResourceTypes.CarbonDioxide)
                {
                    tempCO2 += r.amount;
                }
            }
        }

        CalculateHealth(tempO2, tempCO2);
       // return 0.0f;
    }
}
