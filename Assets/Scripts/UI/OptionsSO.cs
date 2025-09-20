using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionsCFG", menuName = "SO/Options")]
public class OptionsSO : ScriptableObject
{
    [SerializeField] private List<string> _options;

    public IReadOnlyList<string> SelectedOptions => _options;

    public void SetOptionsValue(List<string> options)
    {
        _options = options;
    }
}
