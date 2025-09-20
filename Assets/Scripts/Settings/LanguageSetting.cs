using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class LanguageSetting
{
    [SerializeField] private Selector _languageSelector;
    [SerializeField] private Selector _subtitlesLanguageSelector;

    public Language GameLanguage { get; set; }
    public Language SubtitlesLanguage { get; set; }
    public bool SubtitlesIsEnabled { get; set; }

    public void Initialize()
    {
        _languageSelector.Initialize(Enum.GetNames(typeof(Language)).ToList());
        _subtitlesLanguageSelector.Initialize(Enum.GetNames(typeof(Language)).ToList());
    }
}

public enum Language
{
    Russian,
    English,
}
