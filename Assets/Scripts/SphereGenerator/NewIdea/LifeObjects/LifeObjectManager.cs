using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeObjectManager : MonoBehaviour
{
    public static LifeObjectManager Instance;
    public List<LifeObjectSource> sourceObjects;

    private void Start()
    {
        Instance = this;

    }

    public LifeObjectSource ReturnSource(LifeObjectTypes type)
    {
        for(int i = 0; i < sourceObjects.Count;i++)
        {
            if(sourceObjects[i].type == type)
            {
                return sourceObjects[i];
            }
        }

        //errrorrrrrr
        Debug.Log("FFS type not known");
        return null;
    }
}
