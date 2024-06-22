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
        //private List<TemporarySceneObject> _temporarySceneObjects = new();

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            LevelStaticData levelData = (LevelStaticData)target;
            levelData.LevelKey = target.name;

            var rowsCount = levelData.Capacity < levelData.Rows.Count ? levelData.Capacity : levelData.Rows.Count;
            //if (levelData.Rows.Count <= 2) return;
            for (int i = 0; i < rowsCount; i++)
            {
                if (levelData.Rows[i] is null) return;
                
                EditorGUILayout.BeginHorizontal();
                var ballsCount = levelData.Rows[i].Balls.Count;
                for (int j = 0; j < ballsCount; j++)
                {
                    Texture2D texture = new(50, 50);
                    BallStaticData ball = levelData.Rows[i].Balls[j];

                    if (ball != null)
                        texture = AssetPreview.GetAssetPreview(levelData.Rows[i].Balls[j].Icon);
                    EditorGUILayout.BeginHorizontal();
                    GUILayout.Label("", GUILayout.Height(50), GUILayout.Width(50));
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

            /*if (GUILayout.Button("Collect"))
            {
                levelData.EnvironmentObjectsSpawnData = FindObjectsOfType<EnvironmentObjectMarker>()
                    .Select(x =>
                        new EnvironmentObjectSpawnData(x.GetComponent<UniqueId>().Id,
                            x.EnvironmentObjectStaticData.GameObjectsTypeId, x.transform.position,
                            x.transform.rotation))
                    .ToList();

                levelData.StuffSpawnData = FindObjectsOfType<StuffSpawnerMarker>()
                    .Select(x =>
                        new StuffSpawnData(x.GetComponent<UniqueId>().Id,
                            x.StuffStaticData.StuffSpecies, x.transform.position))
                    .ToList();

                levelData.LevelKey = SceneManager.GetActiveScene().name;
            }

            if (GUILayout.Button("Clear level data"))
            {
                levelData.EnvironmentObjectsSpawnData.Clear();
                levelData.StuffSpawnData.Clear();
            }

            GUILayout.Space(20);
            GUILayout.Label("Markers position");

            if (GUILayout.Button("Instantiate prefabs"))
            {
                TemporarySceneObject[] list = FindObjectsOfType<TemporarySceneObject>();
                if (list.Length != 0)
                {
                    DestroyTemporary(list.Select(x => x.gameObject));
                }

                if (levelData.EnvironmentObjectsSpawnData.Count == 0)
                {
                }

                if (levelData.StuffSpawnData.Count == 0)
                {
                
                }

                foreach (EnvironmentObjectSpawnData objectSpawnData in levelData.EnvironmentObjectsSpawnData)
                {
                    string tmpName = objectSpawnData.GameObjectsTypeId.ToString();
                    GameObject tmpGo =
                        await Addressables.InstantiateAsync(tmpName, objectSpawnData.Position, Quaternion.identity);
                    tmpGo.AddComponent<TemporarySceneObject>();
                    tmpGo.name = tmpName.ToUpper();

                    TemporarySceneObject tmp = tmpGo.GetComponent<TemporarySceneObject>();
                    tmp.Id = objectSpawnData.Id;
                    tmp.Type = objectSpawnData.GameObjectsTypeId;
                    Transform[] componentsInChildren = tmpGo.gameObject.GetComponentsInChildren<Transform>(true);

                    foreach (Transform transform in componentsInChildren)
                    {
                        transform.gameObject.SetActive(true);
                    }
                }

                foreach (StuffSpawnData stuffSpawnData in levelData.StuffSpawnData)
                {
                    GameObject markerView = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    markerView.transform.position = stuffSpawnData.Position;
                    markerView.transform.localScale = new Vector3(.3f, .3f, .3f);
                    markerView.AddComponent<StuffTemporaryObject>();
                    StuffTemporaryObject tmpStuff = markerView.GetComponent<StuffTemporaryObject>();
                    tmpStuff.Id = stuffSpawnData.Id;
                    tmpStuff.Species = stuffSpawnData.StuffSpecies;

                    UniqueId stuffSceneMarker = FindObjectsOfType<UniqueId>()
                        .First(m => m.Id == stuffSpawnData.Id);
                    Transform parent = stuffSceneMarker.transform.parent;
                    string parentUniqueId = parent.gameObject.GetComponent<UniqueId>().Id;

                    TemporarySceneObject tmpParent = FindObjectsOfType<TemporarySceneObject>()
                        .First(x => x.Id == parentUniqueId);

                    markerView.name = stuffSceneMarker.name.ToUpper();
                    markerView.transform.parent = tmpParent.transform;
                }
            }

            if (GUILayout.Button("Delete prefabs"))
            {
                TemporarySceneObject[] objList = FindObjectsOfType<TemporarySceneObject>();
                StuffTemporaryObject[] stuffList = FindObjectsOfType<StuffTemporaryObject>();
                IEnumerable<GameObject> list = objList.Select(x => x.gameObject)
                    .Concat(stuffList.Select(x => x.gameObject));
                DestroyTemporary(list);
            }

            if (GUILayout.Button("Set new marker position"))
            {
                List<TemporarySceneObject> list = FindObjectsOfType<TemporarySceneObject>().ToList();
                List<StuffTemporaryObject> listStuff = FindObjectsOfType<StuffTemporaryObject>().ToList();

                list.ForEach(x =>
                {
                    EnvironmentObjectSpawnData marker =
                        levelData.EnvironmentObjectsSpawnData.First(z => z.GameObjectsTypeId == x.Type && z.Id == x.Id);
                    Debug.Log($"Marker: {marker.GameObjectsTypeId}");
                    Vector3 tsoPosition = x.transform.position;
                    marker.Position = tsoPosition;

                    EnvironmentObjectMarker sceneMarker = FindObjectsOfType<EnvironmentObjectMarker>()
                        .First(m => m.GetComponent<UniqueId>().Id == marker.Id);

                    sceneMarker.transform.position = tsoPosition;
                });

                listStuff.ForEach(x =>
                {
                    StuffSpawnData stuffMarker =
                        levelData.StuffSpawnData.First(z => z.StuffSpecies == x.Species && z.Id == x.Id);
                    Vector3 smPosition = x.transform.position;
                    stuffMarker.Position = smPosition;
                });
            }*/

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