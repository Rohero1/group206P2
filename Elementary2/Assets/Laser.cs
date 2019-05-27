using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public float laserMaxLength = 5f;

    // Update is called once per frame
    void Update()
    {
        Vector3 Direction = transform.TransformDirection(Vector3.forward)*10;
        laserLineRenderer.SetPosition(0, transform.position);
        laserLineRenderer.SetPosition(1, transform.position*10);
    }

    Vector3 DetectHit(Vector3 startPos, float distance, Vector3 direction)
    {
        Ray ray = new Ray(startPos, direction);
        RaycastHit hit;
        Vector3 endPos = startPos + (distance * direction);

        if(Physics.Raycast(ray, out hit, distance))
        {
            endPos = hit.point;
            return endPos;
        }

        return endPos;
    }
}
