using System;
using System.Collections.Generic;
using System.Linq;
using StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor
{
    public class RowEditor : EditorWindow
    {
        private const int CapacityMinValue = 5;
        private const int CapacityMaxValue = 10;
        private BallType _type;
        private readonly string _ballAssetsPath = string.Empty;
        private string _name = string.Empty;
        private Sprite _icon;
        private BallStaticData _asset;
        private IntegerField _capacityInput;
        private int _capacity;
        //private SerializedProperty _list;
        //private SerializedObject _serializedObject;
        //private BallStaticData _ballStatic;
        private List<BallStaticData>_balls;

        private VisualElement _rightPane;
        private VisualElement _root;
        private List<BallStaticData> _allObjects;
        private DropdownField _dropdown;

        private Image _spriteImage;

        [MenuItem("Window/Row Editor")]
        public static void ShowExample()
        {
            RowEditor wnd = GetWindow<RowEditor>();
            wnd.titleContent = new GUIContent("Row Editor");
        }
        
        void  OnInspectorUpdate()
        {        
            
        }

        public void CreateGUI()
        {
            // Each editor window contains a root VisualElement object
            _allObjects = new List<BallStaticData>();
            _balls = new List<BallStaticData>();
            _root = rootVisualElement;

            _capacityInput = new IntegerField("Value", 2)
            {
                value = CapacityMinValue,
                isReadOnly = true,
                style = { width = 150 },
            };
            _capacityInput.RegisterValueChangedCallback(CapacityInputVerify);
            _root.Add(_capacityInput);

            var slider = new Slider("Capacity", CapacityMinValue, CapacityMaxValue);
            slider.RegisterValueChangedCallback((evt) => _capacityInput.value = (int)evt.newValue);
            slider.style.width = 300;
            _root.Add(slider);

            TextField ballAssetsPath = new("Path to ball assets");
            ballAssetsPath.RegisterValueChangedCallback(OnAssetPathChange);
            _root.Add(ballAssetsPath);


//"Assets/_Project/Data/LevelsData/Balls"
            // Get a list of all sprites in the project
            if (_ballAssetsPath.Length > 0)
            {
                var allObjectGuids =
                    AssetDatabase.FindAssets("t:Object", new[] { _ballAssetsPath });
                foreach (var guid in allObjectGuids)
                {
                    var item = AssetDatabase.LoadAssetAtPath<BallStaticData>(AssetDatabase.GUIDToAssetPath(guid));
                    _allObjects.Add(item);
                    //Debug.Log($"Guid : {guid} name: {item.name}");
                }
            }


            _dropdown = new("Ball types")
            {
                style =
                {
                    width = 250
                }
            };
            _root.Add(_dropdown);

            // Initialize the list view with all sprites' names
            _dropdown.choices = _allObjects.Select(x => x.name).ToList();
            _dropdown.index = 0;
            //dropdown. = new Rect(0, 0, 100, 50);
            _dropdown.RegisterValueChangedCallback(OnChange);

            _spriteImage = new()
            {
                scaleMode = ScaleMode.ScaleToFit,
            };

            _spriteImage.style.height = 50;
            _spriteImage.style.width = 50;
            _spriteImage.style.alignContent = Align.Center;

            // Add the Image control to the right-hand pane.
            _root.Add(_spriteImage);

            VisualElement addButton = new Button(AddBallToRow)
            {
                text = "Add ball"
            };
            _root.Add(addButton);
            
            var count = _capacityInput.value < _balls.Count ? _capacityInput.value : _balls.Count;
            
            //EditorGUILayout.BeginHorizontal();
            for (int i = 0; i < count; i++)
            {
                Texture2D texture = new(50, 50);
                BallStaticData ball = _balls[i];
                
                if(ball != null)
                    texture = AssetPreview.GetAssetPreview(_balls[i].Icon);
                GUILayout.Label("", GUILayout.Height(50), GUILayout.Width(50));
                GUI.DrawTexture(GUILayoutUtility.GetLastRect(), texture);
                Debug.Log($"Window was update");
            }
            //EditorGUILayout.EndHorizontal();

            VisualElement label2 = new Label("End Line");
            _root.Add(label2);

            var savePath = new TextField("Path to save rows");
            _root.Add(savePath);

            VisualElement saveButton = new Button(SaveAsset)
            {
                text = "Save"
            };
            _root.Add(saveButton);
        }

        private void OnAssetPathChange(ChangeEvent<string> evt)
        {
            var allObjectGuids =
                AssetDatabase.FindAssets("t:Object", new[] { evt.newValue });
            foreach (var guid in allObjectGuids)
            {
                var item = AssetDatabase.LoadAssetAtPath<BallStaticData>(AssetDatabase.GUIDToAssetPath(guid));
                _allObjects.Add(item);
                Debug.Log($"Guid : {guid} name: {item.name}");
            }

            if (_allObjects.Count > 0)
            {
                OnChange(new ChangeEvent<string>());
            }
        }

        private void AddBallToRow()
        {
            if(_balls.Count < _capacityInput.value)
            {
                var ballType = _dropdown.value;
                _balls.Add(_allObjects.Find(x => x.BallType == EnumUtils.ParseEnum<BallType>(ballType)));
                Debug.Log("Ball was added");
            }
        }

        private void SaveAsset()
        {
            Debug.Log("Asset was saved");
        }

        private void CapacityInputVerify(ChangeEvent<int> evt)
        {
            if (evt != null)
            {
                int value = evt.newValue;
                if (value is < CapacityMinValue or > CapacityMaxValue)
                {
                    Debug.Log($"Capacity value can be from {CapacityMinValue} to {CapacityMaxValue}");
                    int newValue = Mathf.Clamp(value, CapacityMinValue, CapacityMaxValue);
                    _capacityInput.value = newValue;
                    _capacity = newValue;
                }
            }
        }

        private void OnChange(ChangeEvent<string> evt)
        {
            if (evt != null)
            {
                // Add a new Image control and display the sprite.
                Sprite icon = evt.newValue == null
                    ? _allObjects[0].Icon
                    : _allObjects.Find(x => x.BallType.ToString() == evt.newValue).Icon;
                _spriteImage.sprite = icon;
                
            }

            if (_dropdown.choices.Count <= 0)
            {
                _dropdown.choices = _allObjects.Select(x => x.name).ToList();
                _dropdown.index = 0;
            }
        }
    }
}
