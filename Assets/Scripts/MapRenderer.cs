using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRenderer : MonoBehaviour
{
    public static MapRenderer instance;

    [SerializeField] GameObject brickRPrefab;
    [SerializeField] GameObject brickGPrefab;
    [SerializeField] GameObject brickBPrefab;
    [SerializeField] GameObject brickYPrefab;

    public List<GameObject> y = new List<GameObject>();

    public List<GameObject> r = new List<GameObject>();
    public List<GameObject> b = new List<GameObject>();
    public List<GameObject> g = new List<GameObject>();
    private void Start()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }
        GenMap();
    }

    private void RendererMap(int type, int x, int z)
    {
        GameObject gameObject;
        if (type == 0)
        {
            gameObject = Instantiate(brickRPrefab, new Vector3(x, 0, z), this.transform.rotation, this.transform);
            r.Add(gameObject);
        }
        else if (type == 1)
        {
            gameObject = Instantiate(brickGPrefab, new Vector3(x, 0, z), this.transform.rotation, this.transform);
            g.Add(gameObject);
        }
        else if (type == 2)
        {
            gameObject = Instantiate(brickBPrefab, new Vector3(x, 0, z), this.transform.rotation, this.transform);
            b.Add(gameObject);
        }
        else if (type == 3)
        {
            gameObject = Instantiate(brickYPrefab, new Vector3(x, 0, z), this.transform.rotation, this.transform);
            y.Add(gameObject);
        }

    }
    public void GenMap()
    {
        for (int i = 0; i < 10; i++)
        {
            
                for (int j = 0; j < 10; j++)
                {
                    RendererMap(GameManager.Instance.RandomColor(), i, j);
                }
            
        }
        
    }
}
