using System.Collections;
using DG.Tweening;
using UnityEngine;

public class CrossFade : SceneTransition
{
    [SerializeField] private CanvasGroup _mainMenu;
    [SerializeField] private CanvasGroup _loadMenu;

    public override IEnumerator AnimationIn()
    {
        _mainMenu.DOFade(0f, 1f);
        _mainMenu.blocksRaycasts = false;
        _loadMenu.gameObject.SetActive(true);
        var tweener = _loadMenu.DOFade(1f, 1f);
        yield return tweener.WaitForCompletion();
    }

    public override IEnumerator AnimationOut()
    {
        var tweener = _loadMenu.DOFade(0f, 2f);
        yield return tweener.WaitForCompletion();
    }
}
