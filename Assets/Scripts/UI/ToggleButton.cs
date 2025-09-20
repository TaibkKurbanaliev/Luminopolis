using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToggleButton : MonoBehaviour
{
    [SerializeField] private Color _switchColor;

    private Button _button;
    private Text _buttonText;

    private void Start()
    {
        _button = GetComponent<Button>();
        _buttonText = GetComponentInChildren<Text>();
    }

    public void Select()
    {
    }
}
