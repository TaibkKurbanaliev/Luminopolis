using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Attack
{
    [SerializeField] private int _strikingSpeed;
    [SerializeField] private int _power;
    [SerializeField] private int _accuracy;
    [SerializeField] private int _blocking;
    [SerializeField] private int _headMoving;
    [SerializeField] private int _footWork;
    [SerializeField] private int _switchStance;

    public int StrikingSpeed { get => _strikingSpeed; set => _strikingSpeed = value; }
    public int Power { get => _power; set => _power = value; }
    public int Accuracy { get => _accuracy; set => _accuracy = value; }
    public int Blocking { get => _blocking; set => _blocking = value; }
    public int HeadMoving { get => _headMoving; set => _headMoving = value; }
    public int FootWork { get => _footWork; set => _footWork = value; }
    public int SwitchStance { get => _switchStance; set => _switchStance = value; }


}
