using System;
using UnityEngine;

public class TimeInvoker : MonoBehaviour
{
    public event Action<float> OneUnscaledDeltaTimeTiked;

    public static TimeInvoker Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject("[ Time Invoker ]");
                _instance = go.AddComponent<TimeInvoker>();
                DontDestroyOnLoad(go);
            }

            return _instance;
        }
    }

    private static TimeInvoker _instance;

    private float _oneSecTimer;

    private void Update()
    {
        OneUnscaledDeltaTimeTiked?.Invoke(Time.unscaledDeltaTime);
    }
}
