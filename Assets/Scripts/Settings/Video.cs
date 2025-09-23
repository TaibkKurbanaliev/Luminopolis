using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Video : IDisposable
{
    [SerializeField] private Selector _screenModeSelector;
    [SerializeField] private Selector _screenResolutionSelector;
    [SerializeField] private Selector _qualityLevelSelector;
    [SerializeField] private Slider _brightness;
    [SerializeField] private ToggleSwitch _vSyncToggle;
    [SerializeField] private ToggleSwitch _hdrToggle;

    public FullScreenMode ScreenMode { get; private set; }
    public QualityLevel QualityLevel { get; private set; }
    public bool VSyncEnabled { get; private set; }
    public bool HDR {  get; private set; }
    public int Brightness { get; private set; }
    private Resolution _resolution;

    public Video()
    {
        _resolution.width = 640;
        _resolution.height = 480;
        ScreenMode = FullScreenMode.FullScreenWindow;
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
        _screenResolutionSelector.Initialize(Screen.resolutions
            .Where(res => res.refreshRateRatio.value == Screen.currentResolution.refreshRateRatio.value)
            .Select(res => res.ToString().Split("@")[0].Trim()).ToList(), true);
        _qualityLevelSelector.Initialize(Enum.GetNames(typeof(QualityLevel)).ToList());
        _brightness.value = Brightness;
        _hdrToggle.Initialize();
        _vSyncToggle.Initialize();
        
        _screenModeSelector.ValueChanged += OnScreenModeChanged;
        _screenResolutionSelector.ValueChanged += OnScreenResolutionChanged;
        _qualityLevelSelector.ValueChanged += OnQualityLevelChanged;
        _brightness.onValueChanged.AddListener(OnBrightnessChanged);
        _hdrToggle.Switched += HDRSwitched;
        _vSyncToggle.Switched += vSyncSwitched;


        _resolution.refreshRateRatio = Screen.currentResolution.refreshRateRatio;
        Screen.SetResolution(_resolution.width, _resolution.height, ScreenMode);
        Debug.Log(_resolution);
    }

    private void OnQualityLevelChanged(string value)
    {
        QualityLevel = Enum.Parse<QualityLevel>(value);
    }

    private void OnBrightnessChanged(float value)
    {
        Brightness = (int)value;
    }

    private void vSyncSwitched(bool value)
    {
        VSyncEnabled = value;
        QualitySettings.vSyncCount = VSyncEnabled ? 1 : 0;
    }

    private void HDRSwitched(bool value)
    {
        HDR = value;
    }

    private void OnScreenResolutionChanged(string value)
    {
        var properties = value.Split(" x ");
        _resolution.width = int.Parse(properties[0]);
        _resolution.height = int.Parse(properties[1]);
        Screen.SetResolution(Resolution.width, Resolution.height, ScreenMode);
    }

    private void OnScreenModeChanged(string value)
    {
        var screenMode = Enum.Parse(typeof(FullScreenMode), value);
        ScreenMode = ((FullScreenMode) screenMode) + 1;
        Screen.SetResolution(Resolution.width,Resolution.height, ScreenMode);
    }

    public void Dispose()
    {
        _screenModeSelector.ValueChanged -= OnScreenModeChanged;
    }
}
