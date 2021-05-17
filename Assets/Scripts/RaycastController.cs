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

        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f))
        {
            //Debug.Log("Hitting: " + hit);
            Debug.DrawRay(transform.position, transform.forward);
            if (hit.collider.GetComponent<InteractableObject>())
            {
                Debug.Log("I'm hitting");
                isHitting = true;
                hit.collider.GetComponent<InteractableObject>().Zoom();
                line.SetPosition(1, hit.transform.position);
            }
            else
            {
                isHitting = false;
                line.SetPosition(1, transform.position + (transform.forward * 1.0f));
            }
        }
    }
}
