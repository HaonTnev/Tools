using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace Haon.Utils
{
    public class SaveDataManager : MonoSingleton<SaveDataManager>
    {
        [Header("File Storage Config")]
        [SerializeField] private string saveFileName;
        private SaveData _saveData;
        private List<ISaveData> _saveDataObjects;
        private SaveFileHandler _saveFileHandler;

        private void Start()
        {
            _saveFileHandler = new SaveFileHandler(Application.persistentDataPath, saveFileName);
            _saveDataObjects = FindSaveDataObjects();
            LoadGame();
        }

        /// <summary>
        /// Creates a new save file. 
        /// </summary>
        public void NewGame()
        {
            _saveData = new SaveData();
        }
        /// <summary>
        /// Loads a saved file. If there is none it creates a new one. 
        /// </summary>
        public void LoadGame()
        {
            _saveData = _saveFileHandler.Load();
            if (this._saveData == null)
            {
                Debug.LogWarning("No save data was found. Initializing new save data. ");
                NewGame();
            }

            foreach (var saveDataObject in _saveDataObjects)
            {
                saveDataObject.LoadData(_saveData);
            }
        }
        /// <summary>
        /// Saves the current state to a file. 
        /// </summary>
        public void SaveGame()
        {
            foreach (var saveData in _saveDataObjects)
            {
                saveData.SaveData(ref _saveData);
            }

            _saveFileHandler.Save(_saveData);
        }

        private void OnApplicationQuit()
        {
            SaveGame();
        }
        
        private List<ISaveData> FindSaveDataObjects()
        {
            IEnumerable<ISaveData> saveDataObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<ISaveData>();

            return new List<ISaveData>(saveDataObjects);
        }
        
        
        /// <summary>
        /// Use for add non-MonoBehaviours to the list of saved items. 
        /// </summary>
        /// <param name="instance"></param>
        public void Register(ISaveData instance)
        {
            if (!_saveDataObjects.Contains(instance))
            {
                _saveDataObjects.Add(instance);
            }
        }
        /// <summary>
        /// Use for removing non-MonoBehaviours from the list of saved items. 
        /// </summary>
        /// <param name="instance"></param>
        public  void Unregister(ISaveData instance)
        {
            _saveDataObjects.Remove(instance);
        }
    }

    public static class SaveSystemExtensions
    {
        /// <summary>
        /// Use for add non-MonoBehaviours to the list of saved items. 
        /// </summary>
        /// <param name="instance"></param>
        public static void Register(this ISaveData instance)
        {
            SaveDataManager.Instance.Register(instance);
        }
        /// <summary>
        /// Use for removing non-MonoBehaviours from the list of saved items. 
        /// </summary>
        /// <param name="instance"></param>
        public static void Unregister(this ISaveData instance)
        {
            SaveDataManager.Instance.Unregister(instance);
        }
    }
}