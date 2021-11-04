using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject ObstaclePrefab;
    public float SpawnInterval = 1f;
    // Start is called before the first frame update

    IEnumerator SpawnObstacle_Coroutine;
    void Start()
    {

    }

    public void StartGeneration()
    {
        SpawnObstacle_Coroutine = SpawnObstacle ();
        StartCoroutine (SpawnObstacle_Coroutine);
    }

    private IEnumerator SpawnObstacle()
    {
        var step = Screen.height/10;

        var yPos = step * UnityEngine.Random.Range(0,8);

        var startingPos = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width *5/4, yPos));
        GameObject obstacle = Instantiate(ObstaclePrefab,new Vector3(startingPos.x, startingPos.y, 0), Quaternion.identity);
        obstacle.name += UnityEngine.Random.Range (1, 100);

        yield return new WaitForSeconds (SpawnInterval);
        StartGeneration ();
    }

    public void StopGeneration()
    {
        StopAllCoroutines ();
    }
}
