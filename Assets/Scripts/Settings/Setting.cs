using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Setting : MonoBehaviour
{
    private FullScreenMode _screenMode;
    private Resolution _resolution;
    private bool _vSyncEnabled;
    private bool _hdr;

    public void Awake()
    {
        Screen.fullScreenMode = _screenMode;
        Screen.SetResolution(_resolution.width, _resolution.height, 
            _screenMode == FullScreenMode.FullScreenWindow || _screenMode == FullScreenMode.ExclusiveFullScreen);
        QualitySettings.vSyncCount = _vSyncEnabled ? 1 : 0;
        Camera.main.GetUniversalAdditionalCameraData().allowHDROutput = _hdr;
    }
}

[Serializable]
public class SettingData
{
    public FullScreenMode mode;
}
