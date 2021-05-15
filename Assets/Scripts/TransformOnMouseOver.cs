using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformOnMouseOver : MonoBehaviour
{
    private GameObject Camera;
    private float weight = 0f;
    private float weightVel = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        weight = Mathf.SmoothDamp(weight, 1f, ref weightVel, .3f);
        this.transform.position = Vector3.Lerp(this.transform.position, Camera.transform.position, weight);
    }
}