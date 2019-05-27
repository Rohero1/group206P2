using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    bool attached = false;
    bool inRange = false;
    int connected = 0;
    const int maxConnections = 2;
    public Material mat;
    public Renderer rend;
    Object atomToConnect;
    Transform origin;
    Transform destination;
    LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();


        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attached == true) {

        }


        if (OVRInput.GetDown(OVRInput.Button.One) && inRange == true && attached == false && connected < maxConnections) {
            origin = this.gameObject.transform;
            MakeLine(destination);


        }
    }




    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Atom") {
            rend.material.SetColor("_Color", Color.blue);

            inRange = true;
            atomToConnect = other;

            destination = other.gameObject.transform;

        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Atom") {
            rend.material.SetColor("_Color", Color.white);
        }

        inRange = false;
        atomToConnect = null;

    }




    public void MakeLine(Transform destination)
    {
        Vector3 pointA = origin.position;
        Vector3 pointB = destination.position;

        lineRenderer.SetPosition(1, pointB);

    }






}
