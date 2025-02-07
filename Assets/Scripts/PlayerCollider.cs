using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] GameObject brickParent;
    [SerializeField] public float count = 0;
    public Stack<GameObject> bricks = new Stack<GameObject>();
    public PickColor color;
    protected PlayerMovement playerMovement;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        color = new PickColor();
        color.color = PickColor.Color.Blue;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(color.color.ToString()))
        {
            
            other.transform.SetParent(brickParent.transform);
            other.transform.localPosition = new Vector3(0,count*0.1f,0);
            other.transform.localRotation = Quaternion.Euler(0,0,0);
            bricks.Push(other.gameObject);
            count = count + 1f;
        }

        //if(other.CompareTag("Bridge"))
        //{

            

        //}    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bridge") )
            {
            //Ray ray = new Ray(transform.position + new Vector3(0,0,5), this.transform.forward);
            //if (Physics.Raycast(ray, out RaycastHit hitInfo, 20f, 1))

            //{

            //    Debug.Log(hitInfo.collider);
            //    Debug.DrawRay(transform.position, transform.forward * 20f, Color.red);
            //}
            //else
            //    Debug.DrawRay(transform.position, transform.forward * 20f, Color.green);

            if (bricks.Count != 0)
            {
                playerMovement.isLimited = false;
                BridgeCollider thisBridge = collision.gameObject.GetComponent<BridgeCollider>();
                if (thisBridge.ChangeColor(color.color.ToString()))
                {
                    GameObject brick = bricks.Pop();
                    count = count - 1f;
                    Destroy(brick);

                }
                if(bricks.Count == 0)
                {
                    playerMovement.limitZ = collision.gameObject.transform.position.z;
                    playerMovement.isLimited = true;
                }
            }
            


        }
    }
   

}
