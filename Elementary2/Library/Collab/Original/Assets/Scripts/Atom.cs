using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atom : MonoBehaviour
{

    Rigidbody m_Rigidbody;
    bool attachable;
    bool inRange = false;
    int connected = 0;
    const int maxConnections = 2;
    public Material mat;
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Material>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void OnCollisionEnter(Collision collision)
    {

        rend.material.SetColor("_Color", Color.blue);

        if (connected < maxConnections) {
            if (inRange) {
                attachable = true;

            }
        }




    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Atom") {
            rend.material.SetColor("_Color", Color.blue);
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Atom")
        {
            rend.material.SetColor("_Color", Color.white);
        }

    }

    public void OnCollisionExit(Collision collision)
    {
        mat.color = Color.black;
        rend.material.SetColor("_Color", Color.black);
    }


    public void Connect()
    {
        if (attachable == true) {
            while (inRange = true) {
                
            }

            m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        }
    }


}
