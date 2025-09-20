using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[Serializable]
public class Quality
{
    public event Action<QualityLevel> OnQualityChanged;

    [SerializeField] private Selector _qualityLevelSelector;
    [SerializeField] private Selector _msaaLevelSelector;
    [SerializeField] private Selector _qualitySelector;

    private UniversalRenderPipelineAsset _currentURP;

    public QualityLevel Level { get; private set; }
    public QualityData QualityData {  get; private set; }

    public void SetLevelSettings(QualityLevel level)
    {
        QualitySettings.SetQualityLevel((int)level);
        Level = level;
        _currentURP = (QualitySettings.renderPipeline as UniversalRenderPipelineAsset);

        if (level == QualityLevel.Custom)
        {
            SetAllQualitySettings();
        }

        OnQualityChanged?.Invoke(level);
    }

    public void CopyPreviousQuality()
    {
        QualityData.RenderScale = _currentURP.renderScale;
        QualityData.MsaaLevel = _currentURP.msaaSampleCount;
        QualityData.ShadowsEnabled = _currentURP.shadowDistance > 0f;
        QualityData.ShadowQuality = _currentURP.shadowCascadeCount;
        QualityData.ShadowDistance = _currentURP.shadowDistance;
        QualityData.TextureQuality = QualitySettings.globalTextureMipmapLimit;
    }

    public void SetRenderScale(float scale)
    {
        if (scale < 0.1f || scale > 2f)
            throw new ArgumentOutOfRangeException(nameof(scale));

        if (Level != QualityLevel.Custom)
            CopyPreviousQuality();

        QualityData.RenderScale = scale;
        SetLevelSettings(QualityLevel.Custom);
    }

    public void SetMsaa(MsaaLevel msaaLevel)
    {
        if (Level != QualityLevel.Custom)
            CopyPreviousQuality();

        QualityData.MsaaLevel = (int) msaaLevel;
        SetLevelSettings(QualityLevel.Custom);
    }

    public void SetShadowsEnabled(bool isEnabled)
    {
        QualityData.ShadowsEnabled = isEnabled;
        
        if (!isEnabled)
            SetShadowDistance(0);

        SetLevelSettings(QualityLevel.Custom);
    }

    public void SetShadowDistance(float distance)
    {
        QualityData.ShadowDistance = distance;
        SetLevelSettings(QualityLevel.Custom);
    }

    public void SetTextureQuality(TextureQuality quality)
    {
        QualityData.TextureQuality = (int) quality;
    }

    private void SetAllQualitySettings()
    {
        _currentURP.renderScale = QualityData.RenderScale;
        _currentURP.msaaSampleCount = QualityData.MsaaLevel;
        _currentURP.shadowDistance = QualityData.ShadowsEnabled ? QualityData.ShadowDistance : 0f;
        _currentURP.shadowCascadeCount = QualityData.ShadowQuality;
        QualitySettings.globalTextureMipmapLimit = QualityData.TextureQuality;
    }
}

[Serializable]
public class QualityData
{
    public float RenderScale { get; set; }
    public int MsaaLevel { get; set; }
    public bool ShadowsEnabled { get; set; }
    public int ShadowQuality { get; set; }
    public float ShadowDistance { get; set; }
    public int TextureQuality { get; set; }
}

public enum QualityLevel
{
    Custom,
    Minimum,
    Medium,
    Maximum
}

public enum MsaaLevel
{
    X0,
    X2 = 2,
    X4 = 4,
    X8 = 8
}

public enum ShadowQuality
{
    Low,
    Medium,
    High
}

public enum TextureQuality
{
    High,
    Medium,
    Low,
}