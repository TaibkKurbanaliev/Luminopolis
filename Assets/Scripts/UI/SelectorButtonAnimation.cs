using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SelectorButtonAnim : MonoBehaviour
{
    [SerializeField] private float _changeColorTime;
    [SerializeField] private float _changeSizeTime;
    [SerializeField] private float _scale = 0.9f;
    [SerializeField] private AudioClip _clickSound;
    [SerializeField] private Color _hoverColor;

    private AudioSource _audioSource;
    private Image _image;
    private Vector3 _originalScale;
    private Color _originalColor;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _image = GetComponent<Image>();

        _originalScale = transform.localScale;
        _originalColor = _image.color;
    }

    public void Highlight()
    {
        _image.DOColor(_hoverColor, _changeColorTime);
    }

    public void UnHighlight()
    {
        _image.DOColor(_originalColor, _changeColorTime);
    }

    public void ClickDown()
    {
        transform.DOScale(_originalScale * _scale, _changeSizeTime);
    }

    public void ClickUp()
    {
        transform.DOScale(_originalScale, _changeSizeTime);
    }
}