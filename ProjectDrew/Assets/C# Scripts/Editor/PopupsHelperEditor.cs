using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PopupsManager))]
public class PopupsHelperEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        PopupsManager popupHelper = (PopupsManager)target;
        
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
