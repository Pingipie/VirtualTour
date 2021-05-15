using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    RaycastHit hit;
    LineRenderer line;

    public bool isHitting;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.GetComponent<InteractableObject>())
            {
                isHitting = true;
                hit.collider.GetComponent<InteractableObject>().Zoom();               
            }
            else
            {
                isHitting = false;
            }
        }
    }
}
