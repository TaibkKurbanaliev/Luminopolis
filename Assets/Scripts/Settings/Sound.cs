using System;
using UnityEngine;

[Serializable]
public class Sound
{
    private int _musicVolume;
    private int _volume;
    public bool IsMuted { get; private set; }

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
}
