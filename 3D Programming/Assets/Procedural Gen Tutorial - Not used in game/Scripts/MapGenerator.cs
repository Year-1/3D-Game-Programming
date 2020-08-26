using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour{

    public enum DrawMode { NoiseMap, ColourMap, DrawMesh};
    public DrawMode drawMode;

    //  This is to make chunks have less vertices in the distance. 240 is divisible by 2,4,6,8,10,12.
    const int mapChunkSize = 241;
    [Range(0,6)] // This is because of 240 divisible. Simplification of vertices. 0 being none and 6 being max.
    public int levelOfDetail;
    public float noiseScale;

    public int octaves;

    [Range(0,1)] // Make the persistance a slider in the editor between 0-1 values
    public float persistance;
    public float lacunarity;

    public int seed;
    public Vector2 offset;

    //  Gives the height multipler to the mesh so its actually like a map.
    public float meshHeightMultiplier;

    //  Used so the water isnt so hilly.
    public AnimationCurve meshHeightCurve;

    public TerrainType[] regions;

    public bool autoUpdate;

    public void GenerateMap()    {
        float[,] noiseMap = Noise.GenerateNoiseMap(mapChunkSize, mapChunkSize,seed, noiseScale, octaves, persistance, lacunarity, offset);

        Color[] colourMap = new Color[mapChunkSize * mapChunkSize];
        for (int y = 0; y < mapChunkSize; y++) {
            for (int x = 0; x < mapChunkSize; x++) {
                float currentHeight = noiseMap[x, y];
                for (int i = 0; i < regions.Length; i++) {
                    if(currentHeight <= regions[i].height) {
                        colourMap[y * mapChunkSize + x] = regions[i].colour;
                        break;
                    }
                }
            }
        }
        MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.NoiseMap) {
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));
        }
        else if (drawMode == DrawMode.ColourMap) {
            display.DrawTexture(TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize, mapChunkSize));
        } else if (drawMode == DrawMode.DrawMesh) {
            //  Meshes can only have 65000 vertices.
            display.DrawMesh(MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, meshHeightCurve, levelOfDetail), TextureGenerator.TextureFromColourMap(colourMap, mapChunkSize, mapChunkSize));
        }
    }

    //  This is to clamp the values so that they will always be within their range. So persistance is always between 0-1 for example.
    private void OnValidate()
    {
        if (lacunarity < 1) {
            lacunarity = 1;
        }
        if(octaves < 0) {
            octaves = 0;
        }
    }
}


[System.Serializable]   //  So these show up in the editor.
public struct TerrainType
{
    public string name;
    public float height;
    public Color colour;
}
