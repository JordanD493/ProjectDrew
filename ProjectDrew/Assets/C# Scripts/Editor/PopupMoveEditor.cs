using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PopupMove))]
public class PopupMoveEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PopupMove popupMove = (PopupMove)target;

        if (GUILayout.Button("Snap to begin limit"))
        {
            popupMove.SnapToBegin();
        }

        if (GUILayout.Button("Snap to end limit"))
        {
            popupMove.SnapToEnd();
        }
    }
}
