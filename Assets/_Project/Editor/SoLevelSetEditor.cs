using System;
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

                string[] allObjectGuids =
                    AssetDatabase.FindAssets("t:Object", new[] { _levels.Path });
                foreach (string guid in allObjectGuids)
                {
                    IEnumerable<RowStaticData> rows;
                    
                    LevelStaticData item = AssetDatabase.LoadAssetAtPath<LevelStaticData>(AssetDatabase.GUIDToAssetPath(guid));
                    if (item.Circular == false && item.Rows.Count > item.Capacity)
                        rows = item.Rows.Take(item.Capacity);
                    else
                        rows = item.Rows;
                    
                    IEnumerable<RowStaticData> rowStaticData = rows as RowStaticData[] ?? rows.ToArray();

                    _levels.LevelsSet.Add(new LevelData($"{item.LevelKey}|{int.Parse(item.LevelKey.Split("L")[1])}",
                        item.Capacity,
                        rowStaticData.Select(x =>
                            string.Join("|", x.Balls.Select(z => z == null ? "None" : z.BallType))).ToList(),
                        item.TargetScores,
                        item.Circular,
                        GetUniqueTypes(rowStaticData))
                    );
                    
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