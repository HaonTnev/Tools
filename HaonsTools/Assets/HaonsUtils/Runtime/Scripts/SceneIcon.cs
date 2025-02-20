using UnityEditor;
using UnityEngine;


namespace Haon.Utils
{
#if UNITY_EDITOR
    public class SceneIcon : MonoBehaviour
    {

        [SerializeField] private Texture2D icon;
        [SerializeField] private bool showOnlyWhenSelected;
        [SerializeField] private bool allowScaling; 
    
        private void OnDrawGizmos()
        {
            if (icon == null) return;
        
            if (!showOnlyWhenSelected)
                Gizmos.DrawIcon(transform.position, AssetDatabase.GetAssetPath(icon), allowScaling );
        }

        private void OnDrawGizmosSelected()
        {
            if (icon == null) return;
        
            Gizmos.DrawIcon(transform.position, AssetDatabase.GetAssetPath(icon), allowScaling );
        }
    }
#endif
}



