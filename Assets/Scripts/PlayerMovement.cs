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
    public float limitZ = 0f;
    public bool isLimited = false;
    public float maxZ = 99999;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    public void Moving()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        { 
        hDir = Input.GetAxisRaw("Horizontal");
        vDir = Input.GetAxisRaw("Vertical");
        //Debug.Log(hDir.ToString() + " " + vDir.ToString());
        Vector3 dir = new Vector3(hDir, 0f, vDir);
        dir.Normalize();
        Vector3 vector3;
        vector3 = new Vector3(dir.x * speed, dir.y * speed, dir.z * speed)  * Time.fixedDeltaTime + rb.position;
            if (isLimited)
            {
               
                rb.MovePosition(new Vector3(vector3.x, vector3.y, Mathf.Clamp(vector3.z, -99, limitZ)));
            }
            else
            {
                rb.MovePosition(vector3);
            }
           
      
            float angle = Vector3.Angle(Vector3.forward, dir);
        
            if (hDir >= 0)
            {
                transform.localRotation = Quaternion.Euler(0, angle, 0);
            }

            else if (hDir < 0) { transform.localRotation = Quaternion.Euler(0, -angle, 0); }

         
       
    }
    }
}
