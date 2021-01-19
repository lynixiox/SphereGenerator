using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoliageManager : MonoBehaviour
{
    public static FoliageManager Instance;

    public List<FoliageStats> foliageStats;


    private void Start()
    {
        Instance = this;
    }
    public FoliageStats FindAndCopy(LifeObjectTypes type)
    {
        for(int i = 0; i < foliageStats.Count;i++)
        {
            if(foliageStats[i].lifeType == type)
            {
                return foliageStats[i];
            }
        }

        //errooooor
        Debug.Log("Woopsie, couldnt find type");
        return null;
    }
}
