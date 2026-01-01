using UnityEngine;
using UnityEngine.UI;

public class SelectedIndicator : MonoBehaviour
{
    [SerializeField] private HorizontalLayoutGroup _containerSize;

    private int _numberOfContainerElements;

    private void Awake()
    {
        _numberOfContainerElements = GetComponentsInChildren<Transform>().Length;
    }
}
