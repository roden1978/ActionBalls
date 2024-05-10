using System.Collections.Generic;
using StaticData;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Test : EditorWindow
{
    private VisualElement _root;
    private List<BallStaticData> _allObjects;
    
    [MenuItem("Window/UI Toolkit/Test")]
    public static void ShowExample()
    {
        Test wnd = GetWindow<Test>();
        wnd.titleContent = new GUIContent("Test");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        _root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        _root.Add(label);
        
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
    }
    
    private void OnChange(ChangeEvent<string> evt)
    {
        if (evt != null)
        {
            // Add a new Image control and display the sprite.
            Sprite icon = _allObjects.Find(x => x.BallType.ToString() == evt.newValue).Icon;
            Image spriteImage = new()
            {
                scaleMode = ScaleMode.ScaleToFit,
                sprite = icon
            };

            // Add the Image control to the right-hand pane.
            _root.Add(spriteImage);
        }
    }
}
