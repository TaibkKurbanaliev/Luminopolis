using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[Serializable]
public class Quality
{
    public event Action<QualityLevel> OnQualityChanged;

    [SerializeField] private MainMenuSelector _qualityLevelSelector;
    [SerializeField] private MainMenuSelector _msaaLevelSelector;
    [SerializeField] private MainMenuSelector _qualitySelector;

    private UniversalRenderPipelineAsset _currentURP;

    public QualityLevel Level { get; private set; }
    public QualityData QualityData {  get; private set; }

    public void SetLevelSettings(QualityLevel level)
    {
        QualitySettings.SetQualityLevel((int)level);
        Level = level;
        _currentURP = (QualitySettings.renderPipeline as UniversalRenderPipelineAsset);
        OnQualityChanged?.Invoke(level);
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
    Low,
    Medium,
    Maximum
}

