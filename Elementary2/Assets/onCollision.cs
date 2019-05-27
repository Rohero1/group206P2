using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollision : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 Direction = transform.TransformDirection(Vector3.up) * 10;
        Debug.Log("Enter called / element.");
        Debug.DrawRay(transform.position, Direction, Color.red);
        audioSource.Play();
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = transform.position;
    }

    
    /*void OnCollisionStay(Collision collision)
    {
        Debug.Log("Stay occuring..");
        
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exit called..");
        
    }*/
}