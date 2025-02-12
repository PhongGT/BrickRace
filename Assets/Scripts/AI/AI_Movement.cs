using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class AI_Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent nav;
    public Mode mode;
    protected Vector3 end;
    public MapRenderer map;
    public bool isLimited;
    internal float limitZ;

    private void Awake()
    {
        map = FindObjectOfType<MapRenderer>();
        end = new Vector3(5.60482645f, 2.80999994f, 33.7960014f);
    }
    public void Start()
    {
        mode = Mode.Find;
        nav = GetComponent<NavMeshAgent>();
        SwitchTarget(new Vector3(UnityEngine.Random.Range(0, 11), this.transform.position.y, UnityEngine.Random.Range(0, 11)));
    }
    // Update is called once per frame
    void Update()
    {
        if (!nav.hasPath && mode == Mode.Find) { SwitchTarget(new Vector3(UnityEngine.Random.Range(0, 11), this.transform.position.y, UnityEngine.Random.Range(0, 11))); }

        if (isLimited) { SwitchTarget(new Vector3(UnityEngine.Random.Range(0, 11), this.transform.position.y, UnityEngine.Random.Range(0, 11))); }
    }

    public void Move()
    {
        mode = Mode.Build;
        nav.SetDestination(end); 
    }

    public void ChangeMode()
    {
        Debug.Log("Change");
        if (mode == Mode.Find)
        {
            mode = Mode.Build;
        }
        else
            mode = Mode.Find;
    }
    public void SwitchTarget(Vector3 target)
    {
        nav.SetDestination(target);
    }
    public enum Mode
    {
        Build,
        Find
    } 
}
