using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    [SerializeField, Range(0, 1)] private float _switchValue;
    [SerializeField, Range(0, 1)] private float _animationDuration;
    [SerializeField] private AnimationCurve _animationCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);

    private Slider _slider;

    public bool CurrentValue { get; private set; }

    private bool _previousValue;
}
