using UnityEngine;

namespace Haon.Utils
{
    /// <summary>
    /// A singleton pattern applied to a MonoBehaviour inheritor 
    /// </summary>
    public abstract class MonoSingleton : MonoBehaviour
    {
        protected MonoSingleton(){} // Prevent instancing from outside of the class
        
        /// <summary>
        /// Readonly. The field to access the singleton. 
        /// </summary>
        public static MonoSingleton Instance { get; private set; }
        
        /// <summary>
        /// Overridable. Always call base.Awake to not loose singleton functionality in derived class. 
        /// </summary>
        protected virtual void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
                Destroy(this.gameObject);
        }
        
        /// <summary>
        /// Destroys the game object the instance is attached to.
        /// Be careful with this. 
        /// </summary>
        public void Destroy()
        {
            Destroy(this.gameObject);
        }
    }
}