using Haon.Utils;
using UnityEngine;

namespace DefaultNamespace
{
    public class Testing : Singleton<Testing>
    {
        public void DestroyFoo()
        {
            Debug.Log("Hello from the singleton realm");
        }
    }
}