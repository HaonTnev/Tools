using UnityEngine;

namespace Haon.Utils
{
    public class MakePoolObject : MonoBehaviour
    {
        public void AddToPool(string newTag)
        {
            if (ObjectPool.Instance != null)
            {
                //Thought I would make the Pool cool by giving you the option to add new items at runtime.
                //But unity does not allow the creation of tags during runtime. 
                var newPoolItem = new PoolItem();
                newPoolItem.prefab = this.gameObject;
                gameObject.tag = newTag;
                ObjectPool.Instance.items.Add(newPoolItem);
            }
            Debug.Log("Pool Object made ");
        
        }
    }
}
