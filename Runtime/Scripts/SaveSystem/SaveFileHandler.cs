using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Haon.Utils
{
    public class SaveFileHandler
    {
        private string _dataDirPath = "";
        private string _dataFileName = "";

        public SaveFileHandler(string dataDirPath, string dataFileName)
        {
            _dataDirPath = dataDirPath;
            _dataFileName = dataFileName;
        }

        /// <summary>
        /// Loads a save file.
        /// </summary>
        /// <returns></returns>
        public SaveData Load()
        {
            string fullPath = Path.Combine(_dataDirPath, _dataFileName);
            SaveData loadedData = null;
            if (File.Exists(fullPath))
            {
                try
                {
                    string dataToLoad = "";
                    using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            dataToLoad = reader.ReadToEnd();
                        }
                    }
                    loadedData = JsonUtility.FromJson<SaveData>(dataToLoad);
                }
                catch (Exception e)
                {
                    Debug.LogError($"Error while trying to load data from file: {fullPath} \n {e}" );                    
                    throw;
                }
            }

            return loadedData;
        }

        /// <summary>
        /// Creates a save file. 
        /// </summary>
        /// <param name="data">The data object from which to save</param>
        public void Save(SaveData data)
        {
            string fullPath = Path.Combine(_dataDirPath, _dataFileName);
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

                string dataToStore = JsonConvert.SerializeObject(data, Formatting.Indented);

                using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(stream))
                    {
                        writer.Write(dataToStore);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError($"Error while trying to save data to file: {fullPath} \n {e}" );
                throw;
            }
        }
    }
}

