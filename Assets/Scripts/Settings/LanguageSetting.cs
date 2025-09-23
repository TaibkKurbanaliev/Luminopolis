using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class LanguageSetting : IDisposable
{
    [SerializeField] private Selector _textLanguageSelector;
    [SerializeField] private Selector _voiceLanguageSelector;
    [SerializeField] private ToggleSwitch _subtitlesToggle;

    public Language TextLanguage { get; set; }
    public Language VoiceLanguage { get; set; }
    public bool SubtitlesIsEnabled { get; set; }

    public void Initialize()
    {
        _textLanguageSelector.Initialize(Enum.GetNames(typeof(Language)).ToList());
        _voiceLanguageSelector.Initialize(Enum.GetNames(typeof(Language)).ToList());
        _subtitlesToggle.Initialize(SubtitlesIsEnabled);

        _textLanguageSelector.ValueChanged += OnTextLanguageChanged;
        _voiceLanguageSelector.ValueChanged += OnVoiceLanguageChanged;
        _subtitlesToggle.Switched += OnSubtitlesEnabledSwitched;
    }

    private void OnSubtitlesEnabledSwitched(bool value)
    {
        SubtitlesIsEnabled = value;
    }

    private void OnVoiceLanguageChanged(string value)
    {
        VoiceLanguage = Enum.Parse<Language>(value);
    }

    private void OnTextLanguageChanged(string value)
    {
        TextLanguage = Enum.Parse<Language>(value);
    }

    public void Dispose()
    {
        _textLanguageSelector.ValueChanged -= OnTextLanguageChanged;
        _voiceLanguageSelector.ValueChanged -= OnVoiceLanguageChanged;
        _subtitlesToggle.Switched -= OnSubtitlesEnabledSwitched;
    }

}

public enum Language
{
    Russian,
    English,
}
