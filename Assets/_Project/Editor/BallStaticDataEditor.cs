using System.Collections.Generic;
using Infrastructure.AssetManagement;
using StaticData;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(BallStaticData))]
    public class BallStaticDataEditor : UnityEditor.Editor
    {
        private List<string> _typesList = new();
        private int _index;

        public override void OnInspectorGUI()
        {
            if (_typesList.Count <= 0)
                _typesList = LoadTypesList();
            
            GUILayout.Label("Select ball type if empty or new. Check asset file name");
            _index = EditorGUILayout.Popup("Ball type", _index, _typesList.ToArray());
            
            GUILayout.Space(20);
            
            GUILayout.Label("Ball data");
            base.OnInspectorGUI();
            BallStaticData ballData = (BallStaticData)target;

            if (_index != 0)
                ballData.BallType = _typesList[_index];

            if (target.name != ballData.BallType)
                target.name = ballData.BallType;
            
            Texture2D texture = new(50, 50);
                
            if(ballData.Icon != null)
                texture = AssetPreview.GetAssetPreview(ballData.Icon);
            
            GUILayout.Space(20);
            GUILayout.Label("Ball icon", new GUIStyle
            {
                fontStyle = FontStyle.Bold,
                fontSize = 14,
            });
            GUILayout.Label("",  GUILayout.Height(50), GUILayout.Width(50));
            GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);

            EditorUtility.SetDirty(target);
        }

        private List<string> LoadTypesList()
        {
            var allObjectGuids =
                AssetDatabase.FindAssets("BallsTypes", new[] { AssetPaths.BallsTypesListPath });

            return AssetDatabase.LoadAssetAtPath<BallTypes>(AssetDatabase.GUIDToAssetPath(allObjectGuids[0])).TypesList;
        }
    }
}