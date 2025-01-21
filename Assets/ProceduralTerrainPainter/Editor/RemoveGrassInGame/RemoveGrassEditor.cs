using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(RemoveGrassInGame))]
public class RemoveGrassEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RemoveGrassInGame grassRemovalScript = (RemoveGrassInGame)target;

        if (GUILayout.Button("Remove Grass"))
        {
            grassRemovalScript.RemoveGrassUnderWater();
        }
    }
}
