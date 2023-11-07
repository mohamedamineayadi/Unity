using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;

    bool gameStarted = false;

    public TextMeshProUGUI scoreText;

    int score =0;

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
        {
            StartSpawning();
            gameStarted = true;
        }
    }

    private void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", 0.5f, spawnRate);
    }

    private void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(block,spawnPos,Quaternion.identity);
        score++;
        scoreText.text = score.ToString();

    }
}
