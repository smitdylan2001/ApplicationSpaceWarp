using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGraphicsSettings : MonoBehaviour
{
    [SerializeField] private bool _enableSpacewarpOnStart = true, _useDynamicFFR = false;
    [SerializeField] private OVRManager.FixedFoveatedRenderingLevel _ffrLevelOnStart = OVRManager.FixedFoveatedRenderingLevel.Off;

    void Start()
    {
        //Set spacwarp
        if(_enableSpacewarpOnStart) OVRManager.SetSpaceWarp(true);

        //Set FFR. Recommended to enable Subsampled Layout in Oculus Android settings for better visuals
        if (OVRManager.fixedFoveatedRenderingSupported)
        {
            OVRManager.fixedFoveatedRenderingLevel = _ffrLevelOnStart;
            OVRManager.useDynamicFixedFoveatedRendering = _useDynamicFFR;
        }

        //Extra performance tools
        //OVRManager.suggestedCpuPerfLevel = OVRManager.ProcessorPerformanceLevel.SustainedHigh;
        //OVRManager.suggestedGpuPerfLevel = OVRManager.ProcessorPerformanceLevel.SustainedHigh;
    }

    static public void SetSpaceWarp(bool enable)
    {
        OVRManager.SetSpaceWarp(enable);
    }

    static public void SetFFR(OVRManager.FixedFoveatedRenderingLevel ffrLevel)
    {
        OVRManager.fixedFoveatedRenderingLevel = ffrLevel;
    }
}
