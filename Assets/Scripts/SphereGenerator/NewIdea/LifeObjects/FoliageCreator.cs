using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoliageCreator : MonoBehaviour
{
    public List<GameObject> prefab;
    public int amount;
    public float maxGrowth;
    public Renderer r;
    public bool test;
    public float heightOffGround;

    public List<GameObject> spawnedPrefabs;
    float initialScale;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Setup(LifeObjectTypes type)
    {
        r = GetComponent<Renderer>();

        FoliageStats stats = FoliageManager.Instance.FindAndCopy(type);
        prefab = stats.foliagePrefabs;
        amount = stats.prefabAmount;
        maxGrowth = stats.maxGrowth;
        heightOffGround = stats.heightOffGround;
        spawnedPrefabs = new List<GameObject>();
        Populate();
    }
    // Update is called once per frame
    void Update()
    {
        if(test)
        {
            test = false;
            Populate();
        }
    }
    public void Populate()
    {
        
        for(int i = 0; i < amount; i++)
        {
            int randomNumber = Random.Range(0, prefab.Count);
            GameObject go = GameObject.Instantiate(prefab[randomNumber]);
            go.transform.position = r.gameObject.transform.position;
            Vector3 scaleTemp = go.transform.localScale;
            go.transform.parent = r.transform;
            go.transform.rotation = r.GetComponent<SoloTile>().rotation;

            go.transform.Rotate(new Vector3(90, 180, 0));


            //  go.transform.position += Vector3.up * 0.7f;
            float maxX = ((r.bounds.max.x - r.bounds.min.x) / 4.5F) / 10f;
            float maxY = ((r.bounds.max.z - r.bounds.min.z) / 4.5F) / 10f;
            float randomx = Random.Range(-0.2f, 0.2f) / 2.3f;
            float randomz = Random.Range(-0.2f, 0.2f) / 2.3f;
            go.transform.localPosition += r.GetComponent<SoloTile>().rotation * Vector3.up * (-randomz);
            go.transform.localPosition += r.GetComponent<SoloTile>().rotation * Vector3.right * (-randomx);
            go.transform.localPosition += r.GetComponent<SoloTile>().rotation * Vector3.forward * (-0.02f+heightOffGround);
            go.transform.parent = null;
            go.transform.localScale = scaleTemp;
            go.transform.parent = r.transform;
            initialScale = go.transform.localScale.x;
            spawnedPrefabs.Add(go);
        }
    }
    public void ChangeGrowth(float amount)
    {
        float scale = maxGrowth * amount * initialScale;
        foreach(GameObject go in spawnedPrefabs)
        {
            go.transform.localScale = new Vector3(scale, scale,scale);
        }
    }
    public void Die()
    {
        for(int i = 0; i < spawnedPrefabs.Count;i++)
        {
            Destroy(spawnedPrefabs[i]);
        }
        spawnedPrefabs.Clear();

    }
}
