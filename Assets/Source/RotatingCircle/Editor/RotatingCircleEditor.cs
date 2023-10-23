using UnityEditor;
using UnityEngine;


public class RotatingCircleEditor : Editor
{
    private SerializedProperty _rotateTransforms;

    private void OnEnable()
    {
        _rotateTransforms = serializedObject.FindProperty("_rotateTransforms");
    }

    private void OnSceneGUI()
    {
        for (int i = 0; i < _rotateTransforms.arraySize; i++)
        {
            SerializedProperty a = _rotateTransforms.GetArrayElementAtIndex(i);
            Handles.DrawSolidRectangleWithOutline(a.FindPropertyRelative("_triggerZone").rectValue, 
                new Color(0, 0, 0, 0), Color.green);
        }
    }

    public override void OnInspectorGUI()
    {
        serializedObject.UpdateIfRequiredOrScript();

        EditorGUILayout.PropertyField(_rotateTransforms, new GUIContent("Rotate transforms"));

        serializedObject.ApplyModifiedProperties();
    }
}