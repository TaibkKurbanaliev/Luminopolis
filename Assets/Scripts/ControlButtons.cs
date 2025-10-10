using UnityEngine;

[CreateAssetMenu(fileName = "ControlButtons", menuName = "Settings/ControlButtons")]
public class ControlButtons : ScriptableObject
{
    [field: SerializeField] public KeyCode Interact {  get; private set; }
    [field: SerializeField] public KeyCode LeftJab { get; private set; }
}
