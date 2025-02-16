namespace Haon.Utils
{
    /// <summary>
    /// Pure c# singleton to inherit from. 
    /// </summary>
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        protected Singleton(){}// Prevent instancing from outside of the class
        private static T _instance;

        /// <summary>
        /// Readonly. The field to access the singleton. 
        /// </summary>
        public static T Instance {
            get
            {
                if (_instance == null)
                    _instance = new T();
                
                return _instance;
            }
        }
    }
}