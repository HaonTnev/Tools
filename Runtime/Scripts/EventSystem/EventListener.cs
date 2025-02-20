using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Haon.Utils
{
    public interface IEventListener
    {
        void Subscribe();
        void Unsubscribe();
    
        void OnInvoke();
    }
    
    [Serializable]
    public class EventListenerData : IEventListener
    {
        [SerializeField] private ScriptableEvent @event;
        [SerializeField] private UnityEvent response;
    
        public ScriptableEvent Event { get => @event; set => @event = value; }
        
        public void Subscribe()
        {
            Event += this;
        }
        public void Unsubscribe()
        {
            Event -= this;
        }
    
        public void OnInvoke()
        {
            response?.Invoke();
        }
    }
    
    
    public class EventListener : MonoBehaviour, IEventListener
    {
        [SerializeField] private List<EventListenerData> eventListeners = new();
        [SerializeField] private UnityEvent response;
    
        private void OnEnable()
        {
            if (eventListeners == null || eventListeners.Count == 0)
            {
                Debug.LogWarning($"No events defined for {name}! " +
                            "The listener will not be added.");
                return;
            }
    
            Subscribe();
        }
        private void OnDisable()
        {
            Unsubscribe();
        }
    
        public void Subscribe()
        {
            if (eventListeners == null || eventListeners.Count == 0)
            {
                Debug.LogWarning($"No events defined for {name}! " +
                            "The listener will not be added.");
                return;
            }
    
            foreach (var listener in eventListeners)
            {
                listener.Event += this;
                listener.Subscribe();
            }
        }
        public void Unsubscribe()
        {
            foreach (var listener in eventListeners)
            {
                listener.Event -= this;
                listener.Unsubscribe();
            }
        }
    
        public void OnInvoke()
        {
            response?.Invoke();
        }
    }
}

