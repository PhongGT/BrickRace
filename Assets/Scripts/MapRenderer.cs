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
        if (type == 0)
        {
            Instantiate(brickRPrefab, new Vector3(x, 0, z), this.transform.rotation, this.transform);
        }
        else if (type == 1)
        {
            Instantiate(brickGPrefab, new Vector3(x, 0, z), this.transform.rotation, this.transform);
        }
        else if (type == 2)
        {
            Instantiate(brickBPrefab, new Vector3(x, 0, z), this.transform.rotation, this.transform);
        }
        else if (type == 3)
        {
            Instantiate(brickYPrefab, new Vector3(x, 0, z), this.transform.rotation, this.transform);
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
