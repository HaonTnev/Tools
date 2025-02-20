namespace Haon.Utils
{
    [System.Serializable]
    public partial class SaveData // this being partial allows users of the package to extend this class by whatever they want to store
    {
        public string TimeAndDate;
        public SaveData()
        {
            TimeAndDate = System.DateTime.Now.ToString();
        }
    }
}

