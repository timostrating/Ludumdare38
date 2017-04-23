using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefab;
    public Vector2 SecondsBetweenSpawnsMinMax;
    float nextSpawnTime;

    public Vector2 spawnSizeMinMax = new Vector2(0.1f, 1);
    public Vector2 spawnAngleMinMax = new Vector2(1, 45);

    Vector2 screenHalf;
    


    // on start up
    void Start()
    {
        screenHalf = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    // Update is called once per frame
    void Update()
    {
        if(nextSpawnTime < Time.time)
        {
            float secondsBetweenSpawns = Mathf.Lerp(SecondsBetweenSpawnsMinMax.y, SecondsBetweenSpawnsMinMax.x, Difficulty.GetDiffucultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalf.x, screenHalf.x), screenHalf.y * 2);
            Vector3 spawnAngle = new Vector3(0,0,Random.Range(spawnAngleMinMax.x, spawnAngleMinMax.y));
            GameObject go = (GameObject)Instantiate(prefab, spawnPosition, Quaternion.Euler(spawnAngle));

            go.transform.localScale = Vector3.one * Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
        }
    }
}
