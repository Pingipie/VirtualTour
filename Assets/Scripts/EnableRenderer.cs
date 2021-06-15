using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableRenderer : MonoBehaviour
{
    private bool meshRenderer;
    private PointerRight pointerRight;
    private PointerLeft pointerLeft;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = false;
        if (GameObject.FindObjectOfType<PointerRight>())
            pointerRight = GameObject.FindObjectOfType<PointerRight>();

        if (GameObject.FindObjectOfType<PointerLeft>())
            pointerLeft = GameObject.FindObjectOfType<PointerLeft>();
    }

    private void FixedUpdate()
    {
        if (meshRenderer)
            this.GetComponent<MeshRenderer>().enabled = true;
        else
            this.GetComponent<MeshRenderer>().enabled = false;

        //meshRenderer = false;

    }

    public void AbleRenderer(bool value)
    {
        meshRenderer = value;
    }
}
