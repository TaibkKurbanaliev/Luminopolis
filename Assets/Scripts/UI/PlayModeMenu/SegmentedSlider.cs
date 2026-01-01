using System;
using System.Collections.Generic;
using UnityEditor.Localization.Plugins.XLIFF.V20;
using UnityEngine;
using UnityEngine.UI;

public class SegmentedSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _segmentImage;
    [SerializeField, Range(0.05f,1f)] private float _fromAlpha;
    [SerializeField, Range(0.05f, 1f)] private float _toAlpha;
    [SerializeField] private int _numberOfSegments;
    [SerializeField] private HorizontalLayoutGroup _container;

    private List<Image> _segments = new();

    private void OnValidate()
    {
        if (_fromAlpha > _toAlpha)
            _toAlpha = _fromAlpha;
    }

    private void Awake()
    {
        _slider.wholeNumbers = true;
        _slider.maxValue = _numberOfSegments;

        for (int i = 1; i <= _numberOfSegments; i++)
        {
            var segment = Instantiate(_segmentImage, _container.transform);
            _segments.Add(segment);
            var color = segment.color;
            var alphaRange = _toAlpha - _fromAlpha;
            color.a = _fromAlpha + (alphaRange * ((float)i / _numberOfSegments));
            segment.color = color;
            segment.enabled = false;
            Debug.Log(_fromAlpha + (alphaRange * ((float)i / _numberOfSegments)));
        }
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        if ((int) value == 0)
        {
            foreach (var segment in _segments)
            {
                segment.enabled = false;
            }

            return;
        }

        _segments[(int)value - 1].enabled = true;
    }
}
