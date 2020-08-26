using UnityEngine;

public static class Noise
{

    //  mapChunkSize and mapChunkSize are ints. 
    //  Scale turns the int into float so the noise map doesnt use the same int numbers. 
    //  Scale can not be 0 or lower as it is a division and itll raise a division by 0 error
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        //  Pesduo random number. The starting number will make the following number the same everytime its run.
        System.Random prgn = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++) {
            //  -100000 and 100000 is used as numbers greater for some reason always return the same number for next.
            //  Offset allows for scrolling through the noise.
            float offsetX = prgn.Next(-100000,100000) + offset.x;
            float offsetY = prgn.Next(-100000,100000) + offset.y;
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }

        if (scale <= 0) {
            scale = 0.0001f;
        }

        //  Keep reference to the maxheight and min so it can be normalised back to 0-1
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        
        //  Noise zooming was into corner, these floats make float scale zoom into center.
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {

                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for (int i = 0; i < octaves; i++) {
                    //  The higher the frequency the further apart sample points means height value will change more rapidly.
                    float sampleX = (x-halfWidth) / scale * frequency + octaveOffsets[i].x;
                    float sampleY = (y-halfHeight) / scale * frequency + octaveOffsets[i].y;
                    //  The value at 0,0 is equal to perlin noise, then 1,0. Cycles through x before going to y
                    //  To make the perlin noise not 0-1 and -1 to 1 *2 and -1. For negative heights
                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY * 2 - 1);
                    noiseHeight += perlinValue * amplitude;
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }

                if(noiseHeight > maxNoiseHeight) {
                    maxNoiseHeight = noiseHeight;
                }else if (noiseHeight < minNoiseHeight) {
                    minNoiseHeight = noiseHeight;
                }
                noiseMap[x, y] = noiseHeight;
            }
        }

        for (int y = 0; y < mapHeight; y++) {
            for (int x = 0; x < mapWidth; x++) {
                //  If the noisemap height is equal to minheight it will be zero, equal to max will be 1.
                noiseMap[x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }
        return noiseMap;
    }
}
