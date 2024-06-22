using StaticData;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(RowStaticData))]
    public class RowStaticDataEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            RowStaticData rowData = (RowStaticData)target;
            GUILayout.Space(20);

            var count = rowData.Capacity < rowData.Balls.Count ? rowData.Capacity : rowData.Balls.Count;
            
            EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < count; i++)
            {
                Texture2D texture = new(50, 50);
                BallStaticData ball = rowData.Balls[i];
                
                if(ball != null)
                    texture = AssetPreview.GetAssetPreview(rowData.Balls[i].Icon);
                GUILayout.Label("", GUILayout.Height(50), GUILayout.Width(50));
                GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
            }
            EditorGUILayout.EndHorizontal();
            
            EditorUtility.SetDirty(target);
        }
    }
}
