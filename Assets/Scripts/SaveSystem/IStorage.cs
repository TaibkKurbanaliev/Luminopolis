using Cysharp.Threading.Tasks;
using System;
using System.IO;
using UnityEngine;

public interface IStorage
{
    void Save(object data, Action<bool> callback = null);
    void Load<T>(Action<T> callback = null);
}
