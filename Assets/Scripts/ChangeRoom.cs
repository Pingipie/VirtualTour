using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ChangeRoom : MonoBehaviour
{
    Volume globalVolume;
    LensDistortion lensDistortion;
    DepthOfField depthOfField;

    public EventHandler switchRoom;

    private void Awake()
    {
        globalVolume = FindObjectOfType<Volume>();
        //Debug.Log(globalVolume.profile.components.Count);
        globalVolume.profile.TryGet<DepthOfField>(out depthOfField);
        globalVolume.profile.TryGet<LensDistortion>(out lensDistortion);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("I'm in");
            StartCoroutine(ChangeLensDistortion());
        }
    }

    IEnumerator ChangeLensDistortion()
    {
        yield return new WaitForSeconds(.1f);

        depthOfField.active = true;

        float intensityLens = lensDistortion.intensity.value;
        float intensityDepth = depthOfField.focusDistance.value;

        if(intensityLens == 0)
        {
            while(intensityLens >= -1f)
            {
                if (intensityDepth > .1f)
                {
                    intensityDepth -= .05f;
                    depthOfField.focusDistance.value = intensityDepth;
                }

                intensityLens -= .05f;
                lensDistortion.intensity.value = intensityLens;
                yield return new WaitForSeconds(.005f);
            }

            if (switchRoom != null)
                switchRoom(this, EventArgs.Empty);

            intensityLens = -1f;
            lensDistortion.intensity.value = intensityLens;

        }
        
        if(intensityLens == -1f)
        {
            while(intensityLens <= 0f)
            {

                if (intensityDepth < 1f)
                {
                    intensityDepth += .05f;
                    depthOfField.focusDistance.value = intensityDepth;
                }

                intensityLens += .05f;
                lensDistortion.intensity.value = intensityLens;
                yield return new WaitForSeconds(.005f);
            }

            depthOfField.active = false;
            intensityLens = 0f;
            lensDistortion.intensity.value = intensityLens;
        }
    }
}
