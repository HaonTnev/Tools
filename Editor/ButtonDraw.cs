using UnityEditor;
using UnityEngine;

namespace Haon.Utils.Editor
{
#if UNITY_EDITOR
    [CustomEditor(typeof(Object), true)]
    [CanEditMultipleObjects]
    public class ButtonDraw : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            var monoTarget = target as MonoBehaviour;
            if (monoTarget != null) DrawButton(monoTarget);
    
            var scriptableTarget = target as ScriptableObject;
            if (scriptableTarget != null) DrawButton(scriptableTarget);
        }

        private void DrawButton(object target)
        {
            var methods = target.GetType().GetMethods(
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.Static |
                System.Reflection.BindingFlags.Public |
                System.Reflection.BindingFlags.NonPublic);

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(ButtonAttribute), true);
      
                if (attributes.Length > 0)
                {
                    var buttonAttribute = attributes[0] as ButtonAttribute;

                    string label = string.IsNullOrEmpty(buttonAttribute.Label) ? method.Name : buttonAttribute.Label;
                    if (buttonAttribute != null && GUILayout.Button(buttonAttribute.Label ?? "Button")) 
                    {
                        method.Invoke(target, null);
                    }
                }
            }
        }
    }
#endif  
}
