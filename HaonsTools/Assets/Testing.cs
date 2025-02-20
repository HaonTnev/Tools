using System;
using DefaultNamespace;
using Haon.Utils;
using UnityEngine;


    public class Testing : MonoBehaviour, ISaveData
    {
        [SerializeField] private int[] ints = new[] { 1, 2, 3 };

        private Foo foo;
        private void Awake()
        {
            foo = new Foo();
            Debug.Log(foo.bla);
            transform.RotateToCamera();
        }

        public void LoadData(SaveData data)
        {
            ints[0] = data.counter;
        }
        

        public void SaveData(ref SaveData data)
        {
            data.counter = ints[2];
        }
    }

    namespace Haon.Utils
    {
        public partial class SaveData
        {
            public int counter = 0;
        }
    }
    