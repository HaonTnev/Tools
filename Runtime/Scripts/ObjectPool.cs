using System.Collections.Generic;
using UnityEngine;

namespace Haon.Utils
{
    [System.Serializable]
    public class PoolItem
    {
        public GameObject prefab;
        public int amount;
    }
    
    public sealed class ObjectPool : MonoSingleton<ObjectPool>
    {
        [Header("Assign prefab and amount of objects here.\nIf amount is insufficient the pool will grow during runtime.")]
        [SerializeField] private List<PoolItem> items;
        private readonly List<GameObject> _pool = new();

        private void Start()
        {
            foreach (var item in items)
            {
                for (int i = 0; i < item.amount; i++)
                {
                    var obj = Instantiate(item.prefab, transform, true);
                    obj.SetInactive();
                    _pool.Add(obj);
                }
            }
        }
        /// <summary>
        /// Finds and returns an object of Tag tag from the pool. 
        /// </summary>
        /// <param name="tag">Tag searched for.</param>
        /// <returns>Game Object with Tag tag.</returns>
        public GameObject GetItemByTag(string tag)
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].activeInHierarchy && _pool[i].CompareTag(tag))
                {
                    _pool[i].SetActive();
                    return _pool[i];
                }
            }
            // No valid item in pool. So we add a new one
            foreach (var item in items)
            {
                if (item.prefab.CompareTag(tag))
                {
                    item.amount++;
                    var obj = Instantiate(item.prefab);
                    _pool.Add(obj);
                    return obj;
                }
            }
            Debug.LogError($"The pool does not contain a valid item of the tag: {tag}. A new one could not be added. Consider checking the prefab for the right tag.");
            return null;
        }

        // It did not seem like this was doing anything even with a huge list
        /*public async Task<GameObject> GetItemAsync(string tag)
        {
            return await GetAsyncFromPool(tag);
        }

        private async Task<GameObject> GetAsyncFromPool(string tag)
        {
            await Task.Yield();
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].activeInHierarchy && _pool[i].CompareTag(tag))
                {
                    _pool[i].SetActive();
                    return _pool[i];
                }
            }
            // No valid item in pool. So we add a new one

            foreach (var item in items)
            {
                if (item.prefab.CompareTag(tag))
                {
                    item.amount++;
                    var obj = Instantiate(item.prefab);
                    _pool.Add(obj);
                    return obj;
                }   
            }
            Debug.LogError($"The pool does not contain a valid item of the tag: {tag}. A new one could not be added. Consider checking the prefab for the right tag.");
            return null;
        }*/
    }
}