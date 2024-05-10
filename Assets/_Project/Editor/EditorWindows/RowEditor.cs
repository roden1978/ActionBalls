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
        private string _path = string.Empty;
        private string _name = string.Empty;
        private Sprite _icon;
        private BallStaticData _asset;
        private IntegerField _capacityInput;
        private int _capacity;
        private SerializedProperty _list;
        private BallStaticData[] _balls;
        private SerializedObject _serializedObject;
        private BallStaticData _ballStatic;

        private VisualElement _rightPane;
        private VisualElement _root;
        private List<BallStaticData> _allObjects;

        private Image _spriteImage;

        [MenuItem("Window/Row Editor")]
        public static void ShowExample()
        {
            RowEditor wnd = GetWindow<RowEditor>();
            wnd.titleContent = new GUIContent("Row Editor");
        }

        public void CreateGUI()
        {
            // Each editor window contains a root VisualElement object
            _root = rootVisualElement;

            // VisualElements objects can contain other VisualElement following a tree hierarchy.
            /*VisualElement label = new Label("Capacity can be from 5 to 10");
            _root.Add(label);*/

            _capacityInput = new IntegerField("Value", 2)
            {
                value = CapacityMinValue,
                isReadOnly = true,
                style = { width = 150},
            };
            _capacityInput.RegisterValueChangedCallback(CapacityInputVerify);
            _root.Add(_capacityInput);

            var slider = new Slider("Capacity", CapacityMinValue, CapacityMaxValue);
            slider.RegisterValueChangedCallback((evt) => _capacityInput.value = (int)evt.newValue);
            slider.style.width = 300;
            _root.Add(slider);

            // Get a list of all sprites in the project
            var allObjectGuids =
                AssetDatabase.FindAssets("t:Object", new[] { "Assets/_Project/Data/LevelsData/Balls" });
            _allObjects = new List<BallStaticData>();
            foreach (var guid in allObjectGuids)
            {
                var item = AssetDatabase.LoadAssetAtPath<BallStaticData>(AssetDatabase.GUIDToAssetPath(guid));
                _allObjects.Add(item);
                Debug.Log($"Guid : {guid} name: {item.name}");
            }
            
           
            
            DropdownField dropdown = new("Ball types")
            {
                style =
                {
                    width = 250
                }
            };
            _root.Add(dropdown);
            
            // Initialize the list view with all sprites' names
            dropdown.choices = _allObjects.Select(x => x.name).ToList();
            dropdown.index = 0;
            //dropdown. = new Rect(0, 0, 100, 50);
            dropdown.RegisterValueChangedCallback(OnChange);
            
            _spriteImage = new()
            {
                scaleMode = ScaleMode.ScaleToFit,
                sprite = _allObjects[0].Icon,
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
           
            VisualElement label2 = new Label("End Line");
            _root.Add(label2);

            var path = new TextField("Path");
            _root.Add(path);

            VisualElement saveButton = new Button(SaveAsset)
            {
                text = "Save"
            };
            _root.Add(saveButton);
        }

        private void AddBallToRow()
        {
            Debug.Log("Ball was added");
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
                Sprite icon = _allObjects.Find(x => x.BallType.ToString() == evt.newValue).Icon;
                _spriteImage.sprite = icon;
            }
        }
    }
}