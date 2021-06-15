using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour
{
    RaycastHit hit;
    LineRenderer line;

    public bool isHitting;

    //RightHand rightHand;

    protected virtual void Start()
    {
        //line = this.GetComponent<LineRenderer>();

        //rightHand = GameObject.FindObjectOfType<RightHand>();
        //this.transform.parent = rightHand.transform;
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        //line.SetPosition(0, this.transform.position);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 3.0f))
        {
            //Debug.Log("Hitting: " + hit);
            Debug.DrawRay(transform.position, transform.forward, Color.red);
            if (hit.collider.GetComponent<InteractableObject>())
            {
                Debug.Log("I'm hitting");
                isHitting = true;
                hit.collider.GetComponent<InteractableObject>().Zoom(true);
                //line.SetPosition(1, hit.transform.position);
            }
            else
            {
                isHitting = false;
                //line.SetPosition(1, transform.position + (transform.forward * 1.0f));
            }
        }
    }

    private Gradient SetInitialGradient()
    {
        Gradient temporalGradient = new Gradient();
        GradientColorKey[] colorKey = new GradientColorKey[2];
        GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];

        colorKey[0].color = Color.white;
        colorKey[0].time = 0.0f;
        colorKey[1].color = Color.white;
        colorKey[1].time = 1.0f;

        alphaKey[0].alpha = .5f;
        alphaKey[0].time = 0.0f;
        alphaKey[1].alpha = 0.0f;
        alphaKey[1].time = 1.0f;

        temporalGradient.SetKeys(colorKey, alphaKey);

        return temporalGradient;
    }
}
