using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    protected bool isMoving;
    protected float hDir;
    protected float vDir;
    [SerializeField]protected float speed = 2f;
    [SerializeField]protected Rigidbody rb;
    void Start()
    {
        
    }
    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Moving();
    }
    public void Moving()
    {
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
        Debug.Log(hDir.ToString()+" " +  vDir.ToString());
        Vector3 dir = new Vector3(hDir, 0f ,vDir);
        dir.Normalize();

        if (dir.x > 0)
        {
            rb.velocity = Vector3.right * speed;
        }
        else if (dir.x < 0) { rb.velocity = Vector3.left * speed; }


        if (dir.z > 0) {
            rb.velocity = new Vector3(0, 0, 1) * speed;
        }
        else if (dir.z < 0) { rb.velocity = new Vector3(0, 0, -1) * speed; }
    }
}
