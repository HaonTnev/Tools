using UnityEditor;

namespace Haon.Utils
{

    public class HierarchyHighlightsEditor : EditorWindow 
    {
        private HierarchyHighlights settings;
        
        [MenuItem("Tools/Hierarchy Highlights Settings")] 
        public static void OpenWindow() 
        { 
            HierarchyHighlightsEditor window = GetWindow<HierarchyHighlightsEditor>("Hierarchy Highlights"); 
            window.LoadSettings();
        }
        private void LoadSettings() 
        { 
            settings = HierarchyHighlights.GetOrCreateSettings();
        }

        private void OnGUI() 
        { 
            if (settings == null) 
            { 
                LoadSettings();
            }
            
            SerializedObject serializedObject = new SerializedObject(settings);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("highlightSettings"), true); 

            if (serializedObject.ApplyModifiedProperties())
            {
                settings.SaveChanges(true);
            }
        }
    }
}
