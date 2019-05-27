using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handCollision : MonoBehaviour
{
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 Direction = transform.TransformDirection(Vector3.up) * 10;
        Debug.Log("Enter called / hand.");
        Debug.DrawRay(transform.position, Direction, Color.red);
        audioSource.Play();
    }
}
