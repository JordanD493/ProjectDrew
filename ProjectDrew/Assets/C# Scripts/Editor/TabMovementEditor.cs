using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TabMovement))]
public class TabMovementEditor : Editor
{

    public override void OnInspectorGUI()
    {

        TabMovement tabMovement = (TabMovement)target;

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Snap to begin"))
        {
            tabMovement.SnapToBegin();
        }

        if (GUILayout.Button("Snap to end"))
        {
            tabMovement.SnapToEnd();
        }

        GUILayout.EndHorizontal();


        base.OnInspectorGUI();
    }
}
