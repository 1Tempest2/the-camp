using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TerrainTransformerInGame))]
public class TerrainTransformerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        TerrainTransformerInGame underwaterTreesScript = (TerrainTransformerInGame)target;

        if (GUILayout.Button("Remove Terrain Objects"))
        {
            underwaterTreesScript.RemoveTerrainObjects();
        }
    }
 }

