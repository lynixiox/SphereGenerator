using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGen : MonoBehaviour
{
    List<_hexagon> hex;
    Vector3 pnt;
    public Vector3[] vertices;
    public int[] indices;
    Vector3 s = new Vector3(36, 10, 6);

    // Start is called before the first frame update
    void Start()
    {
        hex = new List<_hexagon>();
        CreateSphereMesh(10, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(s.normalized + "norm");
    }
    void CreateSphereMesh(int N, double R)
    {
        double c = Mathf.Cos((float)(60.0 * Mathf.Deg2Rad));
        double s = Mathf.Sin((float)(60.0 * Mathf.Deg2Rad));
        double sy = R / (N + N - 2);
        double sz = sy / s;
        double sx = sz * c;
        double sz2 = 0.5 * sz;

        int na = 5 * (N - 2);
        int nb = N;
        int b0 = N;
        double q, ang, len, l, l0, ll;
        double[] p = new double[3];
        int j, n, a, b;

        Vector3 ix;
        _hexagon ph;
        _hexagon h = new _hexagon();



        pnt.Normalize();
        b = 0; a = 0;

        for (b = 1; b < N - 1; b++)                             // skip first line b=0
        {
            for (a = 1; a < b; a++)                              // skip first and last line
            {
                h = new _hexagon();
                p[0] = (double)(a) * (sx + sz);
                p[1] = (double)(b - (a >> 1)) * (sy * 2.0);
                p[2] = 0.0;
                if ((int)(a & 1) != 0) p[1] -= sy;
                h.index[0] = new Vector3((float)(p[0] + sz2 + sx), (float)p[1], (float)p[2]);//  2 1
                h.index[1] = new Vector3((float)(p[0] + sz2), (float)(p[1] + sy), (float)p[2]);
                h.index[2] = new Vector3((float)(p[0] - sz2), (float)(p[1] + sy), (float)p[2]);
                h.index[3] = new Vector3((float)(p[0] - sz2 - sx), (float)p[1], (float)p[2]);
                h.index[4] = new Vector3((float)(p[0] - sz2), (float)(p[1] - sy), (float)p[2]);
                h.index[5] = new Vector3((float)(p[0] + sz2), (float)(p[1] - sy), (float)p[2]);
                h.a = a;
                h.b = N - 1 - b;
                hex.Add(h);
            }
        }
        n = hex.Count; // remember number of hexs for the first triangle
        for (int i = 0; i < hex.Count; i += 3)
        {
            for(int o = 0; o < hex[i].index.Length;o++)
            {
                ang = Mathf.Atan2(hex[i].index[o].y, hex[i].index[0].x);// atan2(q[1], q[0]);
                len = hex[i].a + hex[i].b;
                ang -= 60.0f * 0.0f;
                while (ang > +60.0f * 0.0f)
                    ang -= Mathf.PI*2;
                while (ang < -60 * 0.0f)
                    ang += Mathf.PI * 2;

                len *= Mathf.Cos(0) / Mathf.Cos(30.0f * 0.0f);

                ang *= 72.0f / 60.0f;
                hex[i].index[o].x = (float)(len * Mathf.Cos(0.0f));
                hex[i].index[o].y = (float)(len * Mathf.Sin(0.0f));
                Debug.Log("X: " + hex[i].index[o]);
            }
        }



     //   Debug.Log(hex.Count);
        //idk anymore
        vertices = new Vector3[hex.Count*6];
        for(int i = 0; i < hex.Count;i++)
        {
            for(int o = 0; o < 6; o++)
            {
                vertices[(i * 6) + o] = hex[i].index[o];
            }
        }
        indices = new int[12 * hex.Count];
        for(int i = 0;i < hex.Count ;i++)
        {
            indices[(i * 12) + 0] = (i*6) + 5;
            indices[(i * 12) + 1] = (i*6) + 0;
            indices[(i * 12) + 2] = (i*6) + 1;

            indices[(i * 12) + 3] = (i*6) + 1;
            indices[(i * 12) + 4] = (i*6) + 2;
            indices[(i * 12) + 5] = (i*6) + 5;

            indices[(i * 12) + 6] = (i*6) + 5;
            indices[(i * 12) + 7] = (i*6) + 2;
            indices[(i * 12) + 8] = (i*6) + 4;

            indices[(i * 12) + 9] = (i*6) + 4;
            indices[(i * 12) + 10] = (i*6) + 2;
            indices[(i * 12) + 11] = (i*6) + 3;


        }

        Mesh mesh = new Mesh();
        transform.GetComponent<MeshFilter>();

        if (!transform.GetComponent<MeshFilter>() || !transform.GetComponent<MeshRenderer>()) //If you havent got any meshrenderer or filter
        {
            transform.gameObject.AddComponent<MeshFilter>();
            transform.gameObject.AddComponent<MeshRenderer>();
        }

        transform.GetComponent<MeshFilter>().mesh = mesh;

        mesh.name = "MyOwnObject";

        mesh.vertices = vertices;
        mesh.triangles = indices;
        // mesh.uv = UV_MaterialDisplay;
        mesh.RecalculateNormals();
        mesh.Optimize();



    }

}
