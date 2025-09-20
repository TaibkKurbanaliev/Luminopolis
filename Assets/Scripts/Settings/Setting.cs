using System;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Zenject;

public class Setting : MonoBehaviour
{
    
    // Sound Settings
    [SerializeField] private Video _video;
    [SerializeField] private Sound _sound;
    [SerializeField] private LanguageSetting _language;

    // Quality
    public Quality Quality { get; private set; }

    private IStorage _storage;
    private SettingData _settingData = new();

    [Inject]
    private void Constract(IStorage storage)
    {
        _storage = storage;
    }

    private void Start()
    {
        _video.Initialize();
    }

    private void OnDestroy()
    {
        _video.Dispose();
    }

    public void Save()
    {
        _settingData.Mode = _video.ScreenMode;
        _settingData.Resolution = _video.Resolution;
        _settingData.VSync = _video.VSyncEnabled;
        _settingData.HDR = _video.HDR;
        _settingData.QualityLevel = Quality.Level;
        _settingData.QualityData = Quality.QualityData;
        _settingData.GameLanguage = _language.GameLanguage;
        _settingData.SubtitlesLanguage = _language.SubtitlesLanguage;
        _settingData.SubtitlesIsEnabled = _language.SubtitlesIsEnabled;
        
        _storage.Save(_settingData);
    }
}

[Serializable]
public class SettingData
{
    public FullScreenMode Mode { get; set; }
    public Resolution Resolution { get; set; }
    public bool VSync { get; set; }
    public bool HDR { get; set; }
    public QualityLevel QualityLevel { get; set; }
    public QualityData QualityData { get; set; }
    public Language GameLanguage { get; set; }
    public Language SubtitlesLanguage { get; set; }
    public bool SubtitlesIsEnabled { get; set; }
}

public enum Toggle
{
    On,
    Off
}

