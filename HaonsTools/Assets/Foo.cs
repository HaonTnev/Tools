using Haon.Utils;
using UnityEngine;


public class Foo : MonoBehaviour
    {
        public string bla = "bla";
        public Foo()
        {
        }
        
        public void LoadData(Haon.Utils.SaveData data)
        {
            throw new System.NotImplementedException();
        }

        public void SaveData(ref Haon.Utils.SaveData data)
        {
            throw new System.NotImplementedException();
        }
    }


namespace Haon.Utils
{
    public partial class SaveData
    {
        public string bla = ""; 
        
    }
}