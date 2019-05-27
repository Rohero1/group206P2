using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public GameObject RayOrigin;
    //public GameObject RayDestination;
    //public float MaxDist;
    //public LineRenderer laserLineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Direction = transform.TransformDirection(Vector3.forward)*10;
        //RaycastHit outInfo;
       // bool hit = Physics.Raycast(RayOrigin.transform.position, RayDestination.transform.position, out outInfo, MaxDist);
        Debug.DrawRay(transform.position, Direction, Color.green);
    }
}