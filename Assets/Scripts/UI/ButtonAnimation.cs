using DG.Tweening;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class ButtonAnimation : MonoBehaviour
{
    public event Action Clicked;

    [SerializeField] private float _fadeTime = 0.2f;
    [SerializeField] private float _scale = 0.9f;
    [SerializeField] private float _hoverScale = 0.95f;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private AudioClip _hoverSound;
    [SerializeField] private Color _hoverColor = Color.white;

    private AudioSource _audioSource;
    private Button _button;
    private Vector3 _originalScale;
    private Color _originalColor;
    private TMP_Text _text;

    public bool IsHighlighted { get; private set; }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
        _text = GetComponentInChildren<TMP_Text>();

        _originalScale = transform.localScale;
        _originalColor = _text.color;
    }

    public virtual void Highlight()
    {
        _text.DOColor(_hoverColor, _fadeTime);
        _button.transform.DOScale(_originalScale * _hoverScale, _fadeTime);
        _audioSource.PlayOneShot(_hoverSound);
        IsHighlighted = true;
    }

    public virtual void UnHighlight()
    {
        _text.DOColor(_originalColor, _fadeTime);
        _button.transform.DOScale(_originalScale, _fadeTime);
        IsHighlighted = false;
    }

    public virtual void Select()
    {
        _text.color = _hoverColor;
        _button.transform.DOScale(_originalScale * _scale, _fadeTime);
        _audioSource.PlayOneShot(_clickSound);
        Clicked?.Invoke();
    }

    public virtual void DeSelect()
    {
        _text.color = _originalColor;
        _button.transform.DOScale(_originalScale, _fadeTime);
    }
}
