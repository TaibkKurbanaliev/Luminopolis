using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _completeText;
    [SerializeField] private TMP_Text _progressValue;
    [SerializeField] private GameObject _loader;
    [SerializeField] private float _fadeTime;
    [SerializeField] private float _fadeValue;

    public void SetProgress(int progress)
    {
        _progressValue.text = progress.ToString() + "%";
    }

    public void ShowCompleteButton()
    {
        _progressValue.gameObject.SetActive(false);
        _loader.SetActive(false);
        _completeText.gameObject.SetActive(true);
        _completeText.DOColor(new Color(_completeText.color.r, _completeText.color.g, _completeText.color.b, _fadeValue), _fadeTime).SetLoops(-1, LoopType.Yoyo);
    }
}
