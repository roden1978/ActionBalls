using Infrastructure.AssetManagement;
using StaticData;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(SoLevelsSet))]
    public class SoLevelSetEditor : UnityEditor.Editor
    {
        private SoLevelsSet _levels;
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            _levels = (SoLevelsSet)target;

            if (GUILayout.Button("Update levels set"))
            {
                _levels.LevelsSet.Clear();
                
                var allObjectGuids =
                    AssetDatabase.FindAssets("t:Object", new[] { _levels.Path });
                foreach (var guid in allObjectGuids)
                {
                    var item = AssetDatabase.LoadAssetAtPath<LevelStaticData>(AssetDatabase.GUIDToAssetPath(guid));
                    _levels.LevelsSet.Add(item.name);
                    
                    Debug.Log($"Guid : {guid} name: {item.name}");
                }
            }
            
            EditorUtility.SetDirty(target);
        }

        private void OnValidate()
        {
            _levels.Path = AssetPaths.LevelsPath;
        }
    }
}