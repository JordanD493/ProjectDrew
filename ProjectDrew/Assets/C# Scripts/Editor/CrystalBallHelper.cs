using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CrystallBallInput))]
public class CrystalBallHelper : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CrystallBallInput script = (CrystallBallInput)target;

        if (GUILayout.Button("min glow - NOT WORKING"))
        {
            script.MinGlow();
        }

        if (GUILayout.Button("max glow - NOT WORKING"))
        {
            script.MaxGlow();
        }
    }
}
