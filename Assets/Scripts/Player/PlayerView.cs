using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerView : MonoBehaviour
{
    private const string Speed = "Speed";

    private Animator _animator;

    public void Initialize() => _animator = GetComponent<Animator>();

    public void SetSpeed(float speed) => _animator.SetFloat(Speed, speed);


}
