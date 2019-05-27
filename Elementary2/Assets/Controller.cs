using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {
        go = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
        //Ray raydirection = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if (hit.collider != null)
            {
                if (go != hit.collider.gameObject)
                {
                    go.transform.SendMessage("onVRExit");
                    go = hit.transform.gameObject;
                    go.transform.SendMessage("onVREnter");
                    Debug.Log("On VR Raycast");
                    
                }
            }
        }
        else
        {
            if (go != null)
            {
                go.transform.SendMessage("onVRExit");
                go = null;
            }
        }
        Debug.DrawRay(transform.position, transform.forward, Color.red, 1);
    }
}
