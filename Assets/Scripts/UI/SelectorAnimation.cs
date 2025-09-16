using System.Collections;
using TMPro;
using UnityEngine;

public class SelectorAnimation : MonoBehaviour
{
    public enum Direction { LeftToRight, RightToLeft }

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private OptionsSO _options;
    [SerializeField] private float _swapTimeBetweenCharacters;
    [SerializeField] private float _swapTimeBetweenOptions;
    [SerializeField] private float _vertexStepDelay = 0.015f;

    private string _currentSelect;
    private int _currentIndex = 0;
    private bool _isSwitching = false;
    private Direction _direction = Direction.LeftToRight;

    private void Awake()
    {
        _currentSelect = _options.SelectedOptions[_currentIndex];
        _text.text = _currentSelect;
    }

    public void LeftSelect()
    {
        if (_isSwitching) return;
        _currentIndex = _currentIndex == 0 ? _options.SelectedOptions.Count - 1 : _currentIndex - 1;
        _currentSelect = _options.SelectedOptions[_currentIndex];
        _direction = Direction.RightToLeft;
        StartCoroutine(PlayScrollAnimation());
    }

    public void RightSelect()
    {
        if (_isSwitching) return;
        _currentIndex = _currentIndex == _options.SelectedOptions.Count - 1 ? 0 : _currentIndex + 1;
        _currentSelect = _options.SelectedOptions[_currentIndex];
        _direction = Direction.LeftToRight;
        StartCoroutine(PlayScrollAnimation());
    }

    public IEnumerator PlayScrollAnimation()
    {
        _isSwitching = true;

        string oldText = _text.text;
        _text.text = oldText;
        _text.ForceMeshUpdate();
        TMP_TextInfo oldInfo = _text.textInfo;
        int oldCount = oldInfo.characterCount;

        _text.text = _currentSelect;
        _text.ForceMeshUpdate();
        TMP_TextInfo newInfo = _text.textInfo;
        int newCount = newInfo.characterCount;

        for (int i = 0; i < newCount; i++)
        {
            if (!newInfo.characterInfo[i].isVisible) continue;
            var meshIndex = newInfo.characterInfo[i].materialReferenceIndex;
            var vertexIndex = newInfo.characterInfo[i].vertexIndex;
            var colors = newInfo.meshInfo[meshIndex].colors32;
            for (int j = 0; j < 4; j++)
                colors[vertexIndex + j].a = 0;
        }
        _text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);

        int start = _direction == Direction.LeftToRight ? 0 : Mathf.Max(oldCount, newCount) - 1;
        int end = _direction == Direction.LeftToRight ? Mathf.Max(oldCount, newCount) : -1;
        int step = _direction == Direction.LeftToRight ? 1 : -1;

        for (int i = start; i != end; i += step)
        {
            yield return new WaitForSeconds(_swapTimeBetweenCharacters);

            if (i < newCount && newInfo.characterInfo[i].isVisible)
            {
                var meshIndex = newInfo.characterInfo[i].materialReferenceIndex;
                var vertexIndex = newInfo.characterInfo[i].vertexIndex;
                var colors = newInfo.meshInfo[meshIndex].colors32;
                for (int j = 0; j < 4; j++)
                    colors[vertexIndex + j].a = 255;
            }

            _text.UpdateVertexData(TMP_VertexDataUpdateFlags.Colors32);
        }

        _isSwitching = false;
    }
}

