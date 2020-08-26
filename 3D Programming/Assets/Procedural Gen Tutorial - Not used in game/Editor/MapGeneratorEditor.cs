using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//  Make a little button so the map can be created in the editor.
[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mapGen = (MapGenerator)target;

        if (DrawDefaultInspector()) {
            if (mapGen.autoUpdate) {
                mapGen.GenerateMap();
            }
        }

        if(GUILayout.Button("Generate")) {
            mapGen.GenerateMap();
        }
    }
}
