using Haon.Utils;
using UnityEngine;

public class SaveAdditionalData : MonoBehaviour, ISaveData
{
    [Header("These values are added to the sava data class by extending it inside the script. \n " +
            "If you change the values in play mode the changes will be saved when you exit and loaded the next time you enter play mode.\n" +
            "To see hao wo extend the save data class look inside this script.")]
    public int customInt = 42;
    //public Vector3 customVector3 = Vector3.zero;

    public void LoadData(SaveData data)
    {
        this.customInt = data.customInt;
        //this.customVector3 = data.customVector3;
    }

    public void SaveData(ref SaveData data)
    {
        data.customInt = this.customInt;
        //data.customVector3 = this.customVector3;
    }
}

namespace Haon.Utils
{
    public partial class SaveData
    {
        public int customInt = 42; // make the default value match the default value of the class who wants to save. 
        //public Vector3 customVector3 = Vector3.zero; 
        
        
    }
}
