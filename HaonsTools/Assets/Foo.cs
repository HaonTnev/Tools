using System;
using Haon.Utils;
using UnityEngine;

namespace DefaultNamespace
{
    public class Foo : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            other.gameObject.SetInactive();
        }
    }
}