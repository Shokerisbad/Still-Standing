using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WaveManagerScript : MonoBehaviour
{
    public Transform player;
    public Vector2 spawnPointN = Vector2.zero;
    public Vector2 spawnPointS = Vector2.zero;
    public Vector2 spawnPointW = Vector2.zero;
    public Vector2 spawnPointE = Vector2.zero;
    public TextMeshProUGUI waveText = null;
    public GameObject[] gameObjects = null;

    public int wave = 1;
    private int nrEnemiesOnScreen = 0;
    [HideInInspector]
    public int nrEnemiesKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nrEnemiesKilled == wave)
            NewWave();
        else if (nrEnemiesOnScreen < Mathf.Ceil(wave / 2f))
            SpawnNewEnemy();
    }

    void SpawnNewEnemy()
    {
        nrEnemiesOnScreen++;
        int x = (int)UnityEngine.Random.Range(0, 4);
        int n = (int)UnityEngine.Random.Range(0, gameObjects.Length);
        GameObject enemy = null;

        switch (x)
        {
            case 0:
                enemy = Instantiate(gameObjects[n], spawnPointN, Quaternion.identity, transform);
                break;
            case 1:
                enemy = Instantiate(gameObjects[n], spawnPointS, Quaternion.identity, transform);
                break;
            case 2:
                enemy = Instantiate(gameObjects[n], spawnPointW, Quaternion.identity, transform);
                break;
            case 3:
                enemy = Instantiate(gameObjects[n], spawnPointE, Quaternion.identity, transform);
                break;
        }

        enemy.GetComponent<AIDestinationSetter>().target = player;
    }

    public void EnemyKilled()
    {
        nrEnemiesOnScreen--;
        nrEnemiesKilled++;
    }

    void NewWave()
    {
        wave++;
        nrEnemiesKilled = 0;

        if (waveText == null)
            return;
        waveText.text = "Wave: " + wave;
    }
}
