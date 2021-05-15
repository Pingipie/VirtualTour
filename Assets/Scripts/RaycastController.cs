using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    RaycastHit hit;
    LineRenderer line;

    public bool isHitting;

    public void Start()
    {
        line = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        line.SetPosition(0, this.transform.position);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            if (hit.collider.GetComponent<InteractableObject>())
            {
                isHitting = true;
                hit.collider.GetComponent<InteractableObject>();               
            }
            else
            {
                isHitting = false;
            }
        }
    }
}
