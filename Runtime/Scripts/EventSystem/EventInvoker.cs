using System.Collections.Generic;
using UnityEngine;

namespace Haon.Utils
{
    public class EventInvoker : MonoBehaviour
    {
        [SerializeField] private List<ScriptableEvent> events = new();
        
        /// <summary>
        /// Invoke the Scriptable Events assigned to this game object. 
        /// </summary>
        //[Button("Invoke")]
        public void Invoke()
        {
            if (events == null || events.Count == 0)
            {
                Debug.LogWarning($"No events defined for {name}!");
                return;
            }

            foreach (var @event in events)
            {
                @event?.Invoke();
            }
        }
    }
}
