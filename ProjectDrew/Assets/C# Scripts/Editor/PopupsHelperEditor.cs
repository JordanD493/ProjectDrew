using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PopupsHelper))]
public class PopupsHelperEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PopupsHelper popupHelper = (PopupsHelper)target;
        
        if (GUILayout.Button("Fold all popups"))
        {
            popupHelper.FoldAllPopups();
        }

        if (GUILayout.Button("Unold all popups"))
        {
            popupHelper.UnfoldAllPopups();
        }
    }
}
