using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sEdge
{
    //Edge Variables
    public int id;                 //edge ID
    public sTile[] tiles;          //two connected tiles
    public sCorner[] corners;        //two connected corners

    public void SetupEdge(int eID)
    {
        //setup arrays 
        id = eID;                       
        tiles = new sTile[2];
        corners = new sCorner[2];
    }
}
