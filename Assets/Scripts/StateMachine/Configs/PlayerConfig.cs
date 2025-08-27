using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "Player/PlayerConfig")]
public class PlayerConfig : ScriptableObject
{
    [field: SerializeField] public MovementStateConfig MovementStateConfig {  get; private set; }
}
