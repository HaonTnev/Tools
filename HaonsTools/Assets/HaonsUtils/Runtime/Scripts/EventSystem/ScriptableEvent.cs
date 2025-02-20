using System.Collections.Generic;
using UnityEngine;

namespace Haon.Utils
{
    public interface IEvent
    {
        void AddListener(IEventListener listener);
        void RemoveListener(IEventListener listener);
        void Invoke();
    }
    
    [CreateAssetMenu(fileName = "Event", menuName = "Event/ScriptableObjectEvent")]
    public class ScriptableEvent : ScriptableObject, IEvent
    {
        [SerializeField] protected string inspectorName = "Event";
    
        [SerializeReference] private /*readonly*/ List<IEventListener> listeners = new();
    
        public IEnumerable<IEventListener> Listeners => listeners; // short version
    
        public string Name => name;
    
        public void AddListener(IEventListener listener)
        {
            listeners.Add(listener);
        }
        public void RemoveListener(IEventListener listener)
        {
            listeners.Remove(listener);
        }
    
        public static ScriptableEvent operator +(ScriptableEvent instance, IEventListener listener)
        {
            instance.AddListener(listener);
            return instance;
        }
        public static ScriptableEvent operator -(ScriptableEvent instance, IEventListener listener)
        {
            instance.RemoveListener(listener);
            return instance;
        }
    
        public void Invoke()
        {
            foreach (var listener in Listeners)
            {
                listener.OnInvoke();
            }
        }
        private void OnValidate()
        {
            inspectorName = name;
        }
    }

}
