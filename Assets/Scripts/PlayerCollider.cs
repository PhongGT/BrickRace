using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] GameObject brickParent;
    [SerializeField] public float count = 0;
    PickColor color;
    private void Awake()
    {
        color = PickColor.Blue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(color.ToString()))
        {
            
            other.transform.SetParent(brickParent.transform);
            other.transform.localPosition = new Vector3(0,count,0);
            count = count + 0.1f;
        }
    }
    protected enum PickColor
    {
        Red,
        Green,
        Blue,
        Yellow,
    }
}
