using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Haon.Utils
{
    [FilePath("Assets/Settings/HierarchyHighlights.asset", FilePathAttribute.Location.ProjectFolder)]
    public class HierarchyHighlights : ScriptableSingleton<HierarchyHighlights>
    {
        public List<ComponentHighlightSettings> highlightSettings = new List<ComponentHighlightSettings>();
        public Texture2D invokeTexture2D;
        
        protected HierarchyHighlights(){}
        
        /// <summary>
        /// A way to get the instance. Use HierarchyHighlights.instance instead. 
        /// </summary>
        /// <returns>HierarchyHighlights.instance</returns>
        public static HierarchyHighlights GetOrCreateSettings()
        {
            var instance = HierarchyHighlights.instance;
            instance.Save(true);
            return instance;
        }
        /// <summary>
        /// Save changes made to the asset. 
        /// </summary>
        /// <param name="b"></param>
        public void SaveChanges(bool b)
        {
            Save(b);
        }
        // Deprecated 
        // [MenuItem("Tools/Create Hierarchy Highlights Asset")]
        // public static void CreateAsset()
        // {
        //     HierarchyHighlights.instance.Save(true);
        //     Debug.Log("HierarchyHighlights.asset created at Assets/Settings/");
        // }
    }

    [Serializable]
    public class ComponentHighlightSettings
    {
        public MonoScript componentType;
        public Texture2D icon;
        //public Color textColor = new Color(181, 181, 181, 255);
        //public Color backgroundColor = new Color(56, 56, 56,255); 
    }

    [InitializeOnLoad]
    public static class HighlightInHierarchy
    {
        static HighlightInHierarchy()
        {
            EditorApplication.delayCall += () =>
            {

                EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
            };
        }
        
        private static void OnHierarchyGUI(int instanceID, Rect selectionRect) // Call the OnHierachyGUI obj will be all game objects I guess
        {
            if (HierarchyHighlights.GetOrCreateSettings() != null)
            {
                GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject; // Get the current go
                
                for(int i = 0; i < HierarchyHighlights.instance.highlightSettings.Count; i ++)
                {
                    //if(HierarchyHighlights.instance.highlightSettings[i].componentType.GetClass() is MonoScript)
                        
                    if (obj != null && obj.GetComponent(HierarchyHighlights.instance.highlightSettings[i].componentType.GetClass()))
                    {
                        // revision needed to combine with more options of configuration
                        /*// Change background color
                        EditorGUI.DrawRect(selectionRect, HierarchyHighlights.instance.highlightSettings[i].backgroundColor);

                        // Change text color
                        var style = new GUIStyle();
                        style.normal.textColor = HierarchyHighlights.instance.highlightSettings[i].textColor;
                        EditorGUI.LabelField(selectionRect, obj.name, style);*/
                    
                        Rect iconRect = new Rect(selectionRect.xMax - 20, selectionRect.y, 16, 16);
                        GUI.DrawTexture(iconRect, HierarchyHighlights.instance.highlightSettings[i].icon);
                    
                    }
                }
            }
        }
    }
}
