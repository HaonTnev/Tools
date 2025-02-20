
using Haon.Utils;

namespace DefaultNamespace
{
    public class Foo : ISaveData
    {
        public string bla = "bla";
        public Foo()
        {
            this.Register();
            
        }

        public void LoadData(SaveData data)
        {
            bla = data.bla;
        }

        public void SaveData(ref SaveData data)
        {
            data.bla = bla;
        }
    }
}

namespace Haon.Utils
{
    public partial class SaveData
    {
        public string bla = ""; 
        
    }
}