using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainCreation
{
    public void CreateTerrain()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Setup(sHexGrid grid)
    {
        SetHeight(grid);
    }
    public void SetHeight(sHexGrid grid)
    {
        List<List<Vector3>> heightVecs = HeightVectors();
        foreach(sTile s in grid.tiles)
        {
            s.height = HeightAtPoint(s.position, heightVecs);
        }
        foreach(sCorner s in grid.corners)
        {
            s.height = HeightAtPoint(s.position, heightVecs);
        }
        ScaleHeight(grid);

    }
    void ScaleHeight(sHexGrid grid)
    {
        float lowest = grid.tiles[0].height;
        float highest = lowest;
        float scale = 3000;
        foreach(sTile t in grid.tiles)
        {
            lowest = Mathf.Min(lowest, t.height);
            highest = Mathf.Max(highest, t.height);
        }
        foreach(sCorner c in grid.corners)
        {
            lowest = Mathf.Min(lowest, c.height);
            highest = Mathf.Max(highest, c.height);
        }

        highest = Mathf.Max(1.0f, highest - lowest);
        foreach(sTile t in grid.tiles)
        {
            t.height -= lowest;
            t.height *= scale / highest;


        }
        foreach (sCorner c in grid.corners)
        {
            c.height -= lowest;
            c.height *= scale / highest;
        }

    }
    List<List<Vector3>> HeightVectors()
    {
        Random.InitState(TerrainManager.Instance.tSettings.seed);
        List<List<Vector3>> list = new List<List<Vector3>>();
        for(int i = 0; i < TerrainManager.Instance.tSettings.iterations;i++)
        {
            List<Vector3> nList = new List<Vector3>();
            nList.Add(PointUniform(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)));
            nList.Add(PointUniform(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)));
            nList.Add(PointUniform(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)));
            list.Add(nList);
        }
        return list;
    }
    Vector3 PointUniform(float a, float b)
    {
        double x = 2 * Mathf.PI * (a);
        double y = Mathf.Acos(2 * (b) - 1) - (0.5 * Mathf.PI);
        return new Vector3(Mathf.Sin((float)x) * Mathf.Cos((float)y), Mathf.Sin((float)y), Mathf.Cos((float)x) * Mathf.Cos((float)y));
    }
    float HeightAtPoint(Vector3 point, List<List<Vector3>> heightVecs)
    {
        float height = 0;
        foreach(List<Vector3> i in heightVecs)
        {
            if((Vector3.Distance(point, i[0]) * Vector3.Distance(point, i[0])) <2.0f &&
               (Vector3.Distance(point, i[1]) * Vector3.Distance(point, i[1])) <2.0f &&
               (Vector3.Distance(point, i[2]) * Vector3.Distance(point, i[2])) < 2.0f)
            {
                height++;
            }
        }
        return height;
    }
}
