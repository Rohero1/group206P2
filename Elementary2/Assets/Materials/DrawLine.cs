using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{

    private LineRenderer lineRenderer;
    private float dist;

    public Transform origin;
    public Transform destination;

    public GameObject newLine;



    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetWidth(.45f, .45f);

        dist = Vector3.Distance(origin.position, destination.position);

    }

    // Update is called once per frame
    void Update()
    {
        // If line origin != sphere origin, update



    }


    public void MakeLine(Transform origin, Transform destination) {




        Vector3 pointA = origin.position;
        Vector3 pointB = destination.position;

        lineRenderer.SetPosition(1, pointB);


        Instantiate(newLine, new Vector3(0, 0, 0), Quaternion.identity);

    }
}
