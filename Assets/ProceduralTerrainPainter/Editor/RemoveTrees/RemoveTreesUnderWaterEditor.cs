using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RemoveTreesInGame))]
public class RemoveUnderwaterTreesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        RemoveTreesInGame underwaterTreesScript = (RemoveTreesInGame)target;

        if (GUILayout.Button("Remove Trees"))
        {
            underwaterTreesScript.RemoveTreesUnderWater();
        }
    }
}