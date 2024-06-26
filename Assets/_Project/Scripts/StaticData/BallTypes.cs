using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace StaticData
{
    [CreateAssetMenu(fileName = "New BallTypes", menuName = "StaticData/BallTypes")]
    public class BallTypes : ScriptableObject
    {
        public List<string> TypesList;

        
        
        private void OnEnable()
        {
            TypesList.Select(x => x.ToUpper()).ToList().Sort();
            for(int i = 1; i < TypesList.Count; i++)
                if (TypesList[i] == TypesList[i-1]) 
                    Debug.LogError(TypesList[i]);
        }
    }
}