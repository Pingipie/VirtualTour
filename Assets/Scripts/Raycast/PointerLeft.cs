using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerLeft : MonoBehaviour
{
    RaycastHit hit;
    LineRenderer line;
    Gradient initialGradient;

    public bool isHitting;

    LeftHand leftHand;

    protected virtual void Start()
    {
        line = this.GetComponent<LineRenderer>();
        initialGradient = SetInitialGradient();
        line.colorGradient = initialGradient;

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
            if (hit.collider.CompareTag("InteractableObj"))
            {
                Debug.Log("is hitting");
                isHitting = true;
                hit.collider.GetComponentInParent<InteractableObject>().Zoom();

                Gradient temporalGradient = new Gradient();
                GradientColorKey[] colorKey = new GradientColorKey[2];
                GradientAlphaKey[] alphaKey = new GradientAlphaKey[2];

                colorKey[0].color = Color.white;
                colorKey[0].time = 0.0f;
                colorKey[1].color = Color.white;
                colorKey[1].time = 1.0f;

                alphaKey[0].alpha = .8f;
                alphaKey[0].time = 0.0f;
                alphaKey[1].alpha = 0.5f;
                alphaKey[1].time = 1.0f;

                temporalGradient.SetKeys(colorKey, alphaKey);
                line.colorGradient = temporalGradient;
                //line.SetPosition(1, hit.transform.position);
            }
        }
        else
        {
            line.colorGradient = initialGradient;
            isHitting = false;
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
