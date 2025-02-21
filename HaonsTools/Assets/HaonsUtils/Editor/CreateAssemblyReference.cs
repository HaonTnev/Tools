using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Haon.Utils.Editor
{
    
    public static class CreateAssemblyReference
    {
        /// <summary>
        /// Checks if a assembly reference to "Haon.Utils" exists and creates one if it dosn't.
        /// </summary>
        [MenuItem("Tools/CreateAssemblyReference")]
        public static void CreateAssemblyReferenceFromTools() // Thought this might work as a constructor. But it did not 
        {
            string assemblyName = "Haon.Utils.asmref"; // Hardcoded name of the asset
            string assetFolderPath = Application.dataPath; // get the path to the Assets folder
            string fullPath = Path.Combine(assetFolderPath,assemblyName); // Combine the two
            
            if (File.Exists(fullPath)) // it already has been created 
            {
                Debug.LogError($"The assembly definition reference: '{assemblyName}' already exists.");
                return;
            }
            
            string asmrefContent = $"{{\n    \"reference\": \"{assemblyName}\"\n}}";// Define the JSON structure for the .asmref file

            
            File.WriteAllText(fullPath, asmrefContent);
            AssetDatabase.Refresh();

            Debug.Log($"Created Assembly Definition Reference at: {fullPath}");
        }
    }
}
