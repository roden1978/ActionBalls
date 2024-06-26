using System.Collections.Generic;
using System.Linq;
using StaticData;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(BallTypes))]
    public class BallTypesEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            BallTypes ballTypes = (BallTypes)target;

            FindCopies(ballTypes.TypesList);
        }

        private void FindCopies(IEnumerable<string> list)
        {
            IEnumerable<string> enumerable = list as string[] ?? list.ToArray();
            enumerable.Select(x => x.ToUpper()).ToList().Sort();
            for (int i = 1; i < enumerable.Count(); i++)
                if (enumerable.ElementAt(i) == enumerable.ElementAt(i - 1))
                    Debug.LogError(enumerable.ElementAt(i));
        }
    }
}