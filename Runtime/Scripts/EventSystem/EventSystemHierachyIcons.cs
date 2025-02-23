using System;
using UnityEditor;
using UnityEngine;

namespace Haon.Utils
{
#if UNITY_EDITOR
    [InitializeOnLoad]
    public static  class EventSystemHierachyIcons
    {
        static EventSystemHierachyIcons()
        {
            EditorApplication.hierarchyWindowItemOnGUI += (instanceID, selectionRect) =>
            {
                GameObject obj = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
                int counter = 1;
                
                if (obj != null &&  obj.GetComponent<EventInvoker>())
                {
                    var eventsInvoker = obj.GetComponent<EventInvoker>();
                    var path = Application.dataPath + "Packages/com.haon.tnev.haonstools/Editor/Editor Default Resources/TrumpetI_icon.png";
                    DrawIcon(path,ref counter,  100, selectionRect, eventsInvoker.Invoke);
                }
            };
        }
    
        static void DrawIcon(string path, ref int counter, int iconSize, Rect selectionRect, Action buttonMethod = null)
        {
            Texture2D icon = AssetDatabase.LoadAssetAtPath<Texture2D>(path);//HierarchyHighlights.instance.invokeTexture2D);
            
            if (icon != null)
            {
                iconSize = Mathf.Min(iconSize, (int)selectionRect.height);
                Rect iconRect = new Rect(selectionRect.x + selectionRect.width - iconSize -(iconSize*counter+3), selectionRect.y, 
                    iconSize,
                    iconSize);
                
                if (buttonMethod != null && GUI.Button(iconRect, string.Empty))
                {
                    buttonMethod.Invoke();
                }
                GUI.DrawTexture(iconRect, icon);
                counter++;
            }
            else
            {
                Debug.LogWarning($"Ichon at: {path} \n could not be found");
            }
        }
    }
#endif
}

