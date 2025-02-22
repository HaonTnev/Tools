using UnityEngine;
using Haon.Utils.Editor;

namespace Haon.Utils
{
    public class GetObjectFromPool : MonoBehaviour
    {
        /// <summary>
        /// Gets the "Ball" game object from the pool and sets its position to the position of this game object.
        /// </summary>
        [Button("Get 'Ball' from pool.")]
        public void GetBallFromPool()
        {
            var ball = ObjectPool.Instance.GetItemByTag("Ball");
            ball.transform.position = transform.position;
        }
    }
}

