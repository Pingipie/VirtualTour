using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerLeft : MonoBehaviour
{
    RaycastHit hit;
    LineRenderer line;

    public bool isHitting;

    LeftHand leftHand;

    protected virtual void Start()
    {
        line = this.GetComponent<LineRenderer>();

        leftHand = GameObject.FindObjectOfType<LeftHand>();
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        line.SetPosition(0, this.transform.position);
        line.SetPosition(1, transform.position + (transform.forward * 1.0f));

        this.transform.position = new Vector3(leftHand.transform.position.x, leftHand.transform.position.y, leftHand.transform.position.z + .1f);
        this.transform.rotation = leftHand.transform.rotation;

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
        {
            //Debug.Log("Hitting: " + hit);
            Debug.DrawRay(transform.position, transform.forward);
            if (hit.collider.GetComponent<InteractableObject>())
            {
                Debug.Log("I'm hitting");
                isHitting = true;
                hit.collider.GetComponent<InteractableObject>().Zoom();
                //line.SetPosition(1, hit.transform.position);
            }
            else
            {
                isHitting = false;
            }
        }
    }
}
