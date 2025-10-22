using UnityEngine;

[CreateAssetMenu(fileName = "BaseStatConfig", menuName = "Stats/BaseStatConfig")]
public class BaseStatConfig : ScriptableObject
{
    [field: SerializeField] public StatType StatType { get; private set; }
    [field: SerializeField, Range(0,60)] public int BaseValue { get; private set; }
    [field: SerializeField] public string Description {  get; private set; }
}
