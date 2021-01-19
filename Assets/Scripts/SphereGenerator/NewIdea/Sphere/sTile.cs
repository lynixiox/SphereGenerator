using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sTile
{
    //Tile Variables
    [SerializeField]
    public int id;                     //tile ID
    public int edgeCount;              //edge count 
    public Vector3 position;           //tile position
    public List<sTile> tiles;          //pList of tiles
    public List<sCorner> corners;      //pList of corners
    public List<sEdge> edges;          //pList of edges
    public float height;

    public void TileSetup(int tID, int tEdgeCount)
    {
        //Setup Variables
        id = tID;
        edgeCount = tEdgeCount;

        //Create list
        tiles = new List<sTile>();
        corners = new List<sCorner>();
        edges = new List<sEdge>();

        //fill lists with null values so we can access their space without worrying about out of bounds exceptions
        for(int i = 0; i < edgeCount;i++)
        {
            tiles.Add(null);
            corners.Add(null);
            edges.Add(null);
        }

    }

    /*
    public int position(const Tile& t, const Corner* c)
    {
        for (int i = 0; i < t.edge_count; i++)
            if (t.corners[i] == c)
                return i;
        return -1;
    }

    int position(const Tile& t, const Edge* e)
    {
        for (int i = 0; i < t.edge_count; i++)
            if (t.edges[i] == e)
                return i;
        return -1;
    }*/
}
