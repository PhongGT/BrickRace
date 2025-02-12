using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai_Collider : MonoBehaviour
{
    [SerializeField] GameObject brickParent;
    [SerializeField] public float count = 0;
    public Stack<GameObject> bricks = new Stack<GameObject>();
    public PickColor color;
    [SerializeField] protected AI_Movement aiMovement;

    private void Awake()
    {
        aiMovement = GetComponent<AI_Movement>();
       
      
    }
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(color.color.ToString()))
        {
            other.transform.SetParent(brickParent.transform);
            other.transform.localPosition = new Vector3(0, count * 0.1f, 0);
            other.transform.localRotation = Quaternion.Euler(0, 0, 0);
            bricks.Push(other.gameObject);
            count = count + 1f;
            if (count < 7)
            {
                aiMovement.SwitchTarget(new Vector3(Random.Range(0,11) , this.transform.position.y, Random.Range(0,11)));
            }
            else
            {
                aiMovement.Move();
            }
        } 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bridge"))
        {
            if (bricks.Count != 0)
            {
                aiMovement.isLimited = false;
                BridgeCollider thisBridge = collision.gameObject.GetComponent<BridgeCollider>();
                if (thisBridge.ChangeColor(color.color.ToString()))
                {
                    GameObject brick = bricks.Pop();
                    count = count - 1f;
                    Destroy(brick);

                }
                if (bricks.Count == 0)
                {
                    aiMovement.limitZ = collision.gameObject.transform.position.z;
                    aiMovement.isLimited = true;
                    aiMovement.ChangeMode();
                }
            }



        }
    }
}
