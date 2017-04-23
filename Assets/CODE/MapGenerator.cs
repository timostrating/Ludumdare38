using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public Renderer textureRenderer;
    public MapColor[] mapColors;

    public Vector2 scrollSpeedMinMax;
    public float seed = 999;


    private void Start() {
        textureRenderer = gameObject.GetComponent<Renderer>();
        Display();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
            Display();

        float offset = Mathf.Lerp(scrollSpeedMinMax.x, scrollSpeedMinMax.y, Difficulty.GetDiffucultyPercent()) * Time.time;
        textureRenderer.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }


    private void Display() {
        Debug.Log("GenerateNoiseMap()");
        DrawNoiseMap(GenerateNoiseMap(128, 4096, 25f));
    }

    private void DrawNoiseMap(float[,] noiseMap) {
        int width = noiseMap.GetLength(0);
        int height = noiseMap.GetLength(1);

        Texture2D texture = new Texture2D(width, height);
        Color[] colorMap = new Color[width * height];
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                colorMap[y * width + x] = GetColor(noiseMap[x,y]);
                //Debug.Log(noiseMap[x, y]);
            }
        }

        texture.SetPixels(colorMap);
        texture.filterMode = FilterMode.Point;
        texture.Apply();

        textureRenderer.sharedMaterial.mainTexture = texture;
    }

    private Color GetColor(float range) {
        for (int i = 0; i < mapColors.Length; i++) {
            if (mapColors[i].threshold < Mathf.Clamp01(range))
                return mapColors[i].color;
        }

        return Color.clear;
    }


    private float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale) {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        for (int x = 0; x < mapWidth; x++) {
            for (int y = 0; y < mapHeight; y++) {
                float sampleX = x / scale;
                float sampleY = y / scale;
                noiseMap[x, y] = Mathf.PerlinNoise(seed + sampleX, seed + sampleY);
            }
        }

        return noiseMap;
    }
}


[System.Serializable]
public class MapColor {
    public float threshold;
    public Color color;
}