using System.Collections.Generic;
using System.Linq;
using GameObjectsScripts;
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
                    IEnumerable<RowStaticData> rows;
                    var item = AssetDatabase.LoadAssetAtPath<LevelStaticData>(AssetDatabase.GUIDToAssetPath(guid));
                    //if(item.Circular == false && item.Rows.Count > item.Capacity)
                        
                    _levels.LevelsSet.Add(new LevelData
                    {
                        Capacity = item.Capacity,
                        RowsData = item.Rows.Select(x =>
                            string.Join("|", x.Balls.Select(z => z == null ? "None" : z.BallType))).ToList(),
                        TargetScores = item.TargetScores,
                        Circular = item.Circular,
                        UniqueTypes = GetUniqueTypes(item.Rows),

                    });

                    Debug.Log($"Guid : {guid} name: {item.name}");
                }
            }

            EditorUtility.SetDirty(target);
        }

        private string GetUniqueTypes(IEnumerable<RowStaticData> data)
        {
            string allTypes = string.Join("|", data.Select(x =>
                string.Join("|", x.Balls.Select(z => z == null ? "None" : z.BallType))));
            IEnumerable<string> uniqueTypes = allTypes.Split("|")
                .Where(x => x != "None")
                .Distinct();
            return string.Join("|", uniqueTypes);
        }

        private void OnValidate()
        {
            _levels.Path = AssetPaths.LevelsPath;
        }
    }
}