using System.Collections.Generic;
using System.Linq;
using StaticData;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private int _rowsCount;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LevelStaticData levelData = (LevelStaticData)target;
            levelData.LevelKey = target.name;

            if (levelData.Circular)
                _rowsCount = levelData.Rows.Count;
            else
                _rowsCount = levelData.Capacity < levelData.Rows.Count ? levelData.Capacity : levelData.Rows.Count;
           
            for (int i = 0; i < _rowsCount; i++)
            {
                if (levelData.Rows[i] is null) return;

                EditorGUILayout.BeginHorizontal();
                var ballsCount = levelData.Rows[i].Balls.Count;
                for (int j = 0; j < ballsCount; j++)
                {
                    Texture2D texture = new(levelData.Size, levelData.Size);
                    BallStaticData ball = levelData.Rows[i].Balls[j];

                    if (ball != null)
                        texture = AssetPreview.GetAssetPreview(levelData.Rows[i].Balls[j].Icon);
                    EditorGUILayout.BeginHorizontal();
                    GUILayout.Label("", GUILayout.Height(levelData.Size), GUILayout.Width(levelData.Size));
                    GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);

                    EditorGUILayout.EndHorizontal();
                }

                EditorGUILayout.EndHorizontal();
            }

            IEnumerable<RowStaticData> wrongRow = levelData.Rows.Where(x => x.Balls.Count != levelData.Capacity);

            foreach (RowStaticData rowStaticData in wrongRow.ToList())
            {
                levelData.Rows.Remove(rowStaticData);
            }

            EditorUtility.SetDirty(target);
        }

        private void DestroyTemporary(IEnumerable<GameObject> list)
        {
            foreach (var gameObject in list)
            {
                DestroyImmediate(gameObject);
            }
        }
    }
}