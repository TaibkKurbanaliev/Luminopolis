using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class Video : IDisposable
{
    [SerializeField] private Selector _screenModeSelector;
    [SerializeField] private Selector _screenResolutionSelector;
    [SerializeField] private ToggleSwitch _vSyncToggle;
    [SerializeField] private ToggleSwitch _hdrToggle;

    public FullScreenMode ScreenMode { get; private set; }
    public bool VSyncEnabled { get; private set; }
    public bool HDR {  get; private set; }
    private Resolution _resolution;

    public Video()
    {
    }

    public Video(FullScreenMode screenMode, bool vSyncEnabled, bool hDR, Resolution resolution)
    {
        ScreenMode = screenMode;
        VSyncEnabled = vSyncEnabled;
        HDR = hDR;
        _resolution = resolution;
    }

    public Resolution Resolution
    {
        get => _resolution;
        private set
        {
            if (Screen.resolutions.Count(res => res.width == value.width && value.height == res.height) == 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _resolution = value;
        }
    }

    public void Initialize()
    {
        _screenModeSelector.Initialize(Enum.GetNames(typeof(FullScreenMode)).ToList());
        _screenResolutionSelector.Initialize(Screen.resolutions.Select(res => res.ToString().Split("@")[0].Trim()).ToList(), true);
        _hdrToggle.Initialize();
        _vSyncToggle.Initialize();
        
        _screenModeSelector.ValueChanged += OnScreenModeChanged;
        _screenResolutionSelector.ValueChanged += OnScreenResolutionChanged;
        _hdrToggle.Switched += HDRSwitched;
        _vSyncToggle.Switched += vSyncSwitched;
    }

    private void vSyncSwitched(bool value)
    {
        VSyncEnabled = value;
    }

    private void HDRSwitched(bool value)
    {
        HDR = value;
    }

    private void OnScreenResolutionChanged(string value)
    {
        Debug.Log(value);
    }

    private void OnScreenModeChanged(string value)
    {
        var screenMode = Enum.Parse(typeof(FullScreenMode), value);
        ScreenMode = ((FullScreenMode) screenMode) + 1;
        Debug.Log("Значение изменено");
        Debug.Log(ScreenMode);
    }

    public void Dispose()
    {
        _screenModeSelector.ValueChanged -= OnScreenModeChanged;
    }
}
