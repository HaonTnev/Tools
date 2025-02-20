namespace Haon.Utils
{
    public interface ISaveData
    {
        void LoadData(SaveData data);
        void SaveData(ref SaveData data);
    }
}

