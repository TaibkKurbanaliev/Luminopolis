using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

[Serializable]
public class Sound : IDisposable
{
    [SerializeField] private Slider _volumeSlider;
    [SerializeField] private Slider _effectsSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _voiceSlider;

    private int _effectsVolume;
    private int _musicVolume;
    private int _voiceVolume;
    private int _volume;

    public Sound()
    {
    }

    public Sound(int effectsVolume, int musicVolume, int voiceVolume, int volume)
    {
        _effectsVolume = effectsVolume;
        _musicVolume = musicVolume;
        _voiceVolume = voiceVolume;
        _volume = volume;
    }

    public int Volume
    {
        get => _volume;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value));

            _volume = value;
        }
    }
    public int MusicVolume
    {
        get => _musicVolume;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value));

            _musicVolume = value;
        }
    }
    public int EffectsVolume
    {
        get => _effectsVolume;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value));

            _effectsVolume = value;
        }
    }
    public int VoiceVolume
    {
        get => _voiceVolume;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(value));

            _voiceVolume = value;
        }
    }

    public void Initialize()
    {
        _volumeSlider.value = _volume;
        _musicSlider.value = _musicVolume;
        _effectsSlider.value = _effectsVolume;
        _voiceSlider.value = _voiceVolume;

        _volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        _voiceSlider.onValueChanged.AddListener(OnVoiceVolumeChanged);
        _musicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        _effectsSlider.onValueChanged.AddListener(OnEffectsVolumeChanged);
    }

    private void OnEffectsVolumeChanged(float value)
    {
        EffectsVolume = (int)value;
    }

    private void OnMusicVolumeChanged(float value)
    {
        MusicVolume = (int)value;
    }

    private void OnVoiceVolumeChanged(float value)
    {
        VoiceVolume = (int)value;
    }

    public void Dispose()
    {
        _volumeSlider.onValueChanged.RemoveListener(OnVolumeChanged);
        _voiceSlider.onValueChanged.RemoveListener(OnVoiceVolumeChanged);
        _musicSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
        _effectsSlider.onValueChanged.RemoveListener(OnEffectsVolumeChanged);
    }

    private void OnVolumeChanged(float value)
    {
        Volume = (int) value;
    }
}
