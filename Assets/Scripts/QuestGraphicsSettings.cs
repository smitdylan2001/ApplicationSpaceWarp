using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Supported refresh rates on Quest 2
public enum RefreshRates
{
    r72 = 72,
    r90 = 90,
    r120 = 120
}

//Tools for Oculus Quest
public class QuestGraphicsSettings : MonoBehaviour
{
    [SerializeField] private bool _enableSpacewarpOnStart = true, _useDynamicFFR = false;
    [SerializeField] private OVRManager.FixedFoveatedRenderingLevel _ffrLevelOnStart = OVRManager.FixedFoveatedRenderingLevel.Off;
    [SerializeField] private RefreshRates _standardFramerate = RefreshRates.r90;

    void Start()
    {
        //Set spacwarp
        if(_enableSpacewarpOnStart) SetSpaceWarp(true);

        //Set FFR. Recommended to enable Subsampled Layout in Oculus Android settings for better visuals
        if (OVRManager.fixedFoveatedRenderingSupported)
        {
            SetFFR(_ffrLevelOnStart, _useDynamicFFR);
        }

        //Set framerate
        SetRefreshRate(_standardFramerate);

        //Extra performance tools
        //OVRManager.suggestedCpuPerfLevel = OVRManager.ProcessorPerformanceLevel.SustainedHigh;
        //OVRManager.suggestedGpuPerfLevel = OVRManager.ProcessorPerformanceLevel.SustainedHigh;
    }

    static public void SetSpaceWarp(bool enable)
    {
        OVRManager.SetSpaceWarp(enable);
    }

    static public void SetFFR(OVRManager.FixedFoveatedRenderingLevel ffrLevel, bool useDynamic = false)
    {
        OVRManager.fixedFoveatedRenderingLevel = ffrLevel;
        OVRManager.useDynamicFixedFoveatedRendering = useDynamic;
    }

    static public void SetRefreshRate(RefreshRates refreshRate)
    {
        OVRPlugin.systemDisplayFrequency = (int)refreshRate;
    }
}
