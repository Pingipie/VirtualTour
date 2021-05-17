using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private bool zooming;

    private float weight = 0f;
    private float weightVel = .01f;
    private float distance;

    private Vector3 initialPosition;

    private RaycastController[] rayCastControllers;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        zooming = false;
        
        if(GameObject.FindObjectOfType<RaycastController>())
            rayCastControllers = GameObject.FindObjectsOfType<RaycastController>();

        distance = Vector3.Distance(this.transform.position, Vector3.zero);

        Debug.Log(distance);

        initialPosition = this.transform.position;  

        distance *= .95f;

        Debug.Log("99/100: " + distance);
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        if (zooming)
        {
            if (Vector3.Distance(this.transform.position, Vector3.zero) >= distance)
            {
                this.transform.position = Vector3.Lerp(this.transform.position, Vector3.zero, 0.001f);
            }
        }
        else
        {
            this.transform.position = Vector3.Lerp(this.transform.position, initialPosition, .03f);
        }

        if(rayCastControllers != null)
            if (!rayCastControllers[0].isHitting && !rayCastControllers[1].isHitting)
                zooming = false;
    }

    public virtual void Zoom()
    {
        zooming = true;
    }

    /*private void OnMouseOver()
    {
        zooming = true;
    }

    private void OnMouseExit()
    {
        zooming = false;
    }
    */
}
