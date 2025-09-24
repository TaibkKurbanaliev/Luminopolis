using System;
using UnityEngine;

public class StateMachineData 
{
    public Vector3 Velocity;
    public Vector3 TargetPosition;
    public float Acceleration;
    public bool IsMoving;

    private float _speed;
    private float _rotationSpeed;
    private float _drag;
    private Vector2 _input;

    public Vector2 Input
    {
        get => _input;
        set
        {
            if (value.x < -1 || value.x > 1 || value.y < -1 || value.y > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _input = value;
        }
    }

    public float Speed
    {
        get => _speed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speed = value;
        }
    }
    public float RotationSpeed
    {
        get => _rotationSpeed;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _rotationSpeed = value;
        }
    }

    public float Drag
    {
        get => _drag;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _drag = value;
        }
    }
}
