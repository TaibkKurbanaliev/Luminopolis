using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public WalkStateConfig WalkStateConfig {  get; private set; }
}
