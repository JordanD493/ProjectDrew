using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PopupMove))]
public class PopupMoveEditor : Editor
{
    public override void OnInspectorGUI()
    {

        PopupMove popupMove = (PopupMove)target;
        
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Snap to begin"))
        {
            popupMove.SnapToBegin();
        }

        if (GUILayout.Button("Snap to end"))
        {
            popupMove.SnapToEnd();
        }

        GUILayout.EndHorizontal();

        base.OnInspectorGUI();
    }
}
