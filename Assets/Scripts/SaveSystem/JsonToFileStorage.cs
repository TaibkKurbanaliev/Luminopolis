using Newtonsoft.Json;
using System;
using System.IO;
using UnityEngine;

public class JsonToFileStorage : IStorage
{
    private string _path;
    private string _extension = ".save";

    public JsonToFileStorage()
    {
        _path = Path.Combine(Application.persistentDataPath, "Saves");
    }

    public void Load<T>(Action<T> callback = null)
    {
        var filePath = Path.Combine(_path, typeof(T).Name + _extension);

        using (var fileStream = new StreamReader(filePath))
        {
            var json = fileStream.ReadToEnd();
            var data = JsonConvert.DeserializeObject<T>(json);
            callback.Invoke(data);
        }
    }

    public void Save(object data, Action<bool> callback = null)
    {
        var json = JsonConvert.SerializeObject(data);
        var filePath = Path.Combine(_path, data.GetType().Name + _extension);

        if (!Directory.Exists(_path))
            Directory.CreateDirectory(_path);

        using (var fileStream = new StreamWriter(filePath))
        {
            fileStream.Write(json);
        }

        callback?.Invoke(true);
    }
}
