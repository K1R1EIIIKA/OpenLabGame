using System;
using System.Collections.Generic;
using UnityEngine;

namespace EventBus
{
    public class EventBus : MonoBehaviour
    {
        /* Нужно будет накинуть эту шину на пустой объект в сцене
     * Я обычно использую _eventBus = FindObjectOfType<EventBus>();*/

        private Dictionary<string, List<object>> _signalCallbacks = new();

        public void Subscribe<T>(Action<T> callback)
        {
            string key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
                _signalCallbacks[key].Add(callback);
            else
                _signalCallbacks.Add(key, new List<object>() { callback });
        }

        public void Unsubscribe<T>(Action<T> callback)
        {
            string key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
                _signalCallbacks[key].Remove(callback);
            else
                Debug.LogErrorFormat("XD");
        }

        public void Invoke<T>(T signal)
        {
            string key = typeof(T).Name;
            if (_signalCallbacks.ContainsKey(key))
            {
                foreach (var obj in _signalCallbacks[key])
                {
                    var callback = obj as Action<T>;
                    callback?.Invoke(signal);
                }
            }
        }
    }
}
