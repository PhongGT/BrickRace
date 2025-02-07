using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeCollider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected MeshRenderer mRenderer;
    [SerializeField] protected Material rMaterial;
    [SerializeField] protected Material bMaterial;
    [SerializeField] protected Material yMaterial;
    [SerializeField] protected Material gMaterial;
    public PickColor curColor;
    private void Awake()
    {
        mRenderer = GetComponent<MeshRenderer>();
        curColor = new PickColor();
    }

    public bool ChangeColor(string color)

    {
        if(color == curColor.color.ToString())
        { return false; }
        switch (color)
        {
            case "Red": { mRenderer.material = rMaterial; curColor.color = PickColor.Color.Red; return true; }

            case "Yellow": { mRenderer.material = yMaterial; curColor.color = PickColor.Color.Yellow; return true; }

            case "Blue": { mRenderer.material = bMaterial; curColor.color = PickColor.Color.Blue; return true; }

            case "Green": { mRenderer.material = gMaterial; curColor.color = PickColor.Color.Green; return true; }
                 
            default: return false;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Character") {

            
    //    }
    //}

}
