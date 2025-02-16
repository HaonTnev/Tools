using Haon.Utils;
using UnityEngine;

namespace DefaultNamespace
{
    public class Testing : MonoSingleton<Testing>
    {
        [ContextMenu("Spawn Ball")]
        public void GetBallFromPool()
        {
            Debug.Log("start");
            var ball = ObjectPool.Instance.GetItemByTag("Ball");
            ball.transform.position = transform.position;
            Debug.Log("finish");
        }
   
    }
}