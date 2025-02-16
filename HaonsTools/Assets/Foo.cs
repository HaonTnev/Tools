using System;
using Haon.Utils;
using UnityEngine;

namespace DefaultNamespace
{
    public class Foo : MonoSingleton
    {
        protected override void Awake()
        {
            base.Awake();
        }
        private void Start()
        {
            Debug.Log("Hi");
            //Testing.DestroyFoo();
            Testing.Instance.DestroyFoo();
        }
    }
}