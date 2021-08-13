using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PuzzleBase))]
public class TestEditor : Editor
{
    private PuzzleBase targetObject;

    void OnEnable()
    {
        targetObject = (PuzzleBase) target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        EditorGUILayout.BeginVertical();
        targetObject.puzzleType = (PuzzleBase.PuzzleType)EditorGUILayout.EnumPopup("Puzzle type", targetObject.puzzleType);

        if (targetObject.puzzleType == PuzzleBase.PuzzleType.PlaceObject)
            targetObject.key = (GameObject) EditorGUILayout.ObjectField(new GUIContent("Object to place"), targetObject.key, typeof(GameObject), true);
        else
        {
            SerializedProperty enemies = serializedObject.FindProperty("enemies");
            if(EditorGUILayout.PropertyField(enemies, includeChildren:true))
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        EditorGUILayout.Separator();
        targetObject.puzzleReward = (PuzzleBase.PuzzleReward)EditorGUILayout.EnumPopup("Puzzle reward", targetObject.puzzleReward);

        if (targetObject.puzzleReward == PuzzleBase.PuzzleReward.SecretDoor)
            targetObject.door = (GameObject)EditorGUILayout.ObjectField(new GUIContent("Door to unlock"), targetObject.door, typeof(GameObject), true);

        EditorGUILayout.EndVertical();

        if (EditorGUI.EndChangeCheck())
            EditorUtility.SetDirty(target);
    }
}