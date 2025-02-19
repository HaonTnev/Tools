using System;
using Haon.Utils;
using UnityEngine;

namespace Haon.Utils
{
    public class MakePoolObject : MonoBehaviour
    {
        public void AddToPool(string newTag)
        {
            if (ObjectPool.Instance != null)
            {
                //Tag
                var newPoolItem = new PoolItem();
                newPoolItem.prefab = this.gameObject;
                gameObject.tag = newTag;
                ObjectPool.Instance.items.Add(newPoolItem);
            }
            Debug.Log("Pool Object made ");
        
        }
    }
}
