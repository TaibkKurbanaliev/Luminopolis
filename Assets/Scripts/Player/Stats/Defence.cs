using System;
using UnityEngine;

[Serializable]
public class Defence 
{
    [SerializeField] private float _blockAmount;

    public float CurrentBlock {  get; private set; }
    public float MaxBlock {  get; private set; }

    public float BlockAmount { get { return _blockAmount; } set { _blockAmount = value; } }

    public void Reset()
    {
        MaxBlock = _blockAmount;
        CurrentBlock = MaxBlock;
    }
}
