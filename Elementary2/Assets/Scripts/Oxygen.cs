using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    bool attached = false;
    bool inRange = false;
    int connected = 0;
    const int maxConnections = 2;
    public Material mat;
    public Material lineRendererMaterial;
    public Renderer rend;
    Object atomToConnect;
    Transform origin;
    Transform destination;
    Transform currentPos;
    GameObject Line1;
    LineRenderer lineRenderer1;
    GameObject Line2;
    LineRenderer lineRenderer2;
    bool otherAtomTrue = false;
    Atom otherScript;
    private float dist;
    Color baseColour = Color.red;

    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<Renderer>();
        rend.material.SetColor("_Color", baseColour);

        Line1 = new GameObject("Line");
        Line2 = new GameObject("Line");

        Line1.AddComponent<LineRenderer>();
        Line2.AddComponent<LineRenderer>();

        lineRenderer1 = Line1.GetComponent<LineRenderer>();
        lineRenderer2 = Line2.GetComponent<LineRenderer>();

        lineRenderer1.material = lineRendererMaterial;
        lineRenderer2.material = lineRendererMaterial;
    }

    // Update is called once per frame
    void Update()
    {

        currentPos = this.gameObject.transform;

        if (currentPos != origin)
        {

        }

        if ((OVRInput.GetDown(OVRInput.Button.Two) && attached))
        {
            lineRenderer1.positionCount = 0;
            lineRenderer2.positionCount = 0;
            connected = 0;
        }


        if (OVRInput.GetDown(OVRInput.Button.One) && Connectable() && otherAtomTrue)
        {

            lineRenderer1.positionCount = 1;
            lineRenderer2.positionCount = 1;

            Debug.Log("Press!");
            origin = this.gameObject.transform;
            dist = Vector3.Distance(origin.position, destination.position);

            MakeLine(origin, destination);
            connected++;


        }
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Atom"))
        {
            rend.material.SetColor("_Color", Color.blue);

            otherScript = other.GetComponent<Atom>();

            inRange = true;
            atomToConnect = other;

            destination = other.gameObject.transform;

            if (otherScript.Connectable())
            {
                otherAtomTrue = true;
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Atom"))
        {
            rend.material.SetColor("_Color", baseColour);
        }

        inRange = false;
        atomToConnect = null;
        otherAtomTrue = false;

    }




    public void MakeLine(Transform origin, Transform destination)
    {

        Vector3 pointA = origin.position;
        Vector3 pointB = destination.position;

        Vector3 endPoint = dist * Vector3.Normalize(pointB - pointA) + pointA;

        if (connected == 0)
        {
            Instantiate(lineRenderer1, pointA, Quaternion.identity);
            Debug.Log("Instantiate");
            lineRenderer1.SetPosition(0, endPoint);
        }



        else if (connected == 1)
        {
            Instantiate(lineRenderer2, pointA, Quaternion.identity);
            Debug.Log("Instantiate");
            lineRenderer2.SetPosition(0, endPoint);
        }



    }

    public bool Connectable()
    {
        if (inRange == true && connected < maxConnections)
        {
            return true;
        }

        else return false;

    }





}
