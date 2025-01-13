using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        MoveCam();
    }
    public void MoveCam()
    {
        //float change = gameObject.transform.position.x;
        float height = player.transform.position.x + -2f;
        float width = player.transform.position.z + -10f;
        Debug.Log(height);
        this.gameObject.transform.position = new Vector3(height, 2f, width);
    }
}
