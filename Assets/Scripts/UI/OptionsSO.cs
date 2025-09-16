using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OptionsCFG", menuName = "SO/Options")]
public class OptionsSO : ScriptableObject
{
    [SerializeField] private string[] _options;

    public IReadOnlyList<string> SelectedOptions => _options;
}
